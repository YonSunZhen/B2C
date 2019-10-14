/* 
 * Bugs
 ** Center marquee does not disable autoplay when panel is clicked

/**
 * @file
 * Marquee 
 * An interactive element for displaying information.
 * Code by Scott Munn
 * @version 0.7.3
 *
 * @description Marquee elements, similar to tabs, are able to slide, allowing for animated effects. While tab panels are usually hidden (display:none), marquee panels are hidden in the overflow area, so that while the user does not see them, they are easy to move around for visual effects.
 *
 * $(".marquee").marqueeGoTo(2); -- Makes all .marquee elements go to slide 3 (index 2)
 * Clicking a ".marquee-nav LI" element -- Gets the index of this element, then makes its container marquee go to that (click the third LI, go to slide 3)
 *
 * Use class="marquee fade" for fade transitions; class="marquee" or class="marquee slide" for sliding transition
 **/

var settings;
var global_marquee_settings = {
    'css_active_name': "current", // string, name of settings.css_active_name css class    
    'fade_text' : true, // bool, fades out/in text when changing panels
    'fade_text_selectors' : "h1,.summary", // jQuery selectors, CSS selectors of text that will fade in/out, fade_text must be true
    'hide_transitions' : false, // bool.  True = "fade" transition.  False = "slide" transition
    'transition_speed': 500, // int, millisecond speed of panel transition
    'marquee_caption' : 'marquee_current_description', // CSS selector of the "marquee's caption".  This will be automatically updated by either finding .caption in the .marquee-nav LI (these will be automatically hidden on load) or by attaching a TITLE attribute to the LI
    'autoplay' : false, // bool, makes slides automatically transition.  
    'autoplay_slide_duration' : 4000, // determines length of slideshow in milliseconds when autoplaying
    'resizable' : true, // If true, the .marquee and .marquee-viewport elements will resizable to the exact size of the active .marquee-panel
    'touchstartevent' : ('ontouchstart' in document.documentElement) ? 'touchstart' : 'mousedown',	// Auto-detects touch event.  Set to one or the other to disable the remainder
    'touchmoveevent' : ('ontouchmove' in document.documentElement) ? 'touchmove'   : 'mousemove', // Auto-detects touch event.  Set to one or the other to disable the remainder
	'touchendevent' : ('ontouchend' in document.documentElement) ? 'touchend'   : 'mouseup', // Auto-detects touch event.  Set to one or the other to disable the remainder
	'touchMode': "swipe", // Determines the touch behavior.  "Swipe" only listens for swipes, while "drag" will move elements to follow user action
	"enableTouch": true, // Determines whether to allow swiping	
	"hoverActivate": false, // Determine whether hovering over LI should auto-activate
	"swipeThreshold":30, // Minimum pixel threshold to activate a swipe
	"autosize": false, // Whether to automatically size the marquee panels based on window / parent size
	"orientationevent": "onorientationchange" in window ? "orientationchange" : "resize", // Sets up orientation change
	"autoselect": true, // Whether the first panel should be selected
	get current_class() {return "."+this.css_active_name;}, // Has to be outside selector object
	"selector" : {
		"slider":".marquee",
		"nav": ".marquee-nav",
		"panel":".marquee-panel",
		"panels":".marquee-panels",
		"viewport":".marquee-viewport"
	}
};

/**
 * @function marqueeize(options)
 *
 * Initializes marquee elements
 **/
 

$.fn.marqueeize = function(options) {
	settings = new cloneObject(global_marquee_settings);
	// Makes this function watch the #hash on the browser URL bar
	if ("onhashchange" in window) { $(window).bind("hashchange",function(){ activate_marquee_hashchange(); }); }

	// Auto-initialize if a hash exists    
    if (window.location.hash) {
        var hash = window.location.hash;
        var link = $(settings.selector.nav).find('li a[href="'+hash+'"]');
        if (link.length == 1) {
            index = link.parent("li").index();
            link.parent("li").addClass(settings.css_active_name).siblings().removeClass(settings.css_active_name);
            update_current_hashlinks(hash);
        }
    }

    // Assign the marquee function to any number of marquees returned by the jQuery function
    return this.each(function(){
        var marquee = $(this);
        var settings = new cloneObject(global_marquee_settings);
        settings._m = $(marquee);
        settings._id = marquee.attr("id");
        
		if (marquee.hasClass("hasBeenMarqueed")) { /*// console.log("The following marquee has already received instruction and will not receive further instruction."); // console.log(marquee); */}
		else {
			marquee.trigger("init");
	        marquee.addClass("hasBeenMarqueed");
	        
	        if (options) { $.extend(settings,options); } // Merge provided options with defaults

			if (marquee.hasClass("fixed")) { settings.resizable = false; } 
			if (marquee.hasClass("hover-activate")) { settings.hoverActivate = true; } else { settings.hoverActivate = false;}
			if (marquee.hasClass("autosize")) { settings.autosize = true; } else { settings.autosize = false; }
			if (marquee.hasClass("no-autoselect")) { settings.autoselect = false; } else { settings.autoselect = true; }
			
			setup_marquee_autocenter(marquee,settings);
			setup_marquee_autosize(marquee,settings);
			setup_marquee_controls(marquee,settings) 
			setup_marquee_swiping(marquee,settings);

	        
	        marquee.each(function(){
	            var marquee_instance = $(this),
	            	index = 0;

		        // Determine if panel should not be first
		            var current = marquee_instance.find(settings.selector.nav).first().find(settings.current_class); // If the settings.css_active_name class is on one of the panels, auto-select it
		            if (current.length > 0) { // Go to the pre-selected settings.css_active_name panel
		                index = current.index();
		            }
	            
	            // Activate this marquee
		            if (index == 0) {
		                marquee_instance.marqueeGoTo("initialize", null, settings); 
		            } else {
		                marquee_instance.marqueeGoTo(index, null, settings);    
		            }
	
		        // Setup infinite carousel
		            var total = marquee_instance.find(settings.selector.panels).first().children(settings.selector.panel).length; // Used by infinite rotation
		            marquee_instance.attr("data-original-length", total);	// Used by infinite rotation
	            
		            		//if (marquee_instance.find(".counter .total").length > 0) { marquee_instance.find(".counter .total").html(total);  } // Update the counter (1 of 6) if it exists
	            
	            // Setup resizablility
					if (settings.resizable) {
						var panel_height = marquee_instance.find(settings.selector.panel).is(settings.css_active_name).clientHeight; // Get the height of this panel
						marquee_instance.css({"height": panel_height+"px"}); 
		            	marquee_instance.find(settings.selector.viewport).css({"height": panel_height+"px"});
					}
	        });         
		}
    });
}
/** @end $.fn.marqueeize **/
 
$.fn.marqueeClick = function(options) {
    var settings = new cloneObject(global_marquee_settings);
    
    return this.each(function(){
        if (options) { $.extend(settings,options); } // Merge provided options with defaults
        if ($(this).hasClass(settings.css_active_name)) { return; } // When true, don't do anything 
    
        // Let's get a lot of stats and elements
        var item = $(this),
            marquee = $(this).parents(settings.selector.slider).first(), // The containing marquee
            index = $(this).index(); // Figure out numeric value of element clicked

        item.addClass(settings.css_active_name);
        $(marquee).marqueeGoTo(index, null, settings);
    }); 
} 

$.fn.marqueeAutoplay = function() {

    return this.each(function(){    
		var marquee_instance = $(this);

	    // Prevents autoplay from continuing if the user is hovering over the marquee
	    marquee_instance.hover(
	        function() {$.data(this,'hover',true); },
	        function() {$.data(this,'hover',false); }
	    ).data('hover',false).data('autoplay',true);
	
		marquee_instance.find(settings.selector.nav).click(function() { marquee_instance.data('autoplay', false); }); // Stops autoplay on click of slide number

        var this_autoplay = setInterval(function(){
        if (!marquee_instance.data('hover') && marquee_instance.data('autoplay')) { marquee_instance.marqueeGoTo("next", null, settings); }
    },global_marquee_settings.autoplay_slide_duration);
    
	    marquee_instance.removeClass("autoplay-off").addClass("autoplay-on").hover(
	        function(){ clearInterval(this_autoplay); },
	        function(){ 
	            this_autoplay = setInterval(function(){
	                if (!marquee_instance.data('hover') && marquee_instance.data('autoplay')) { marquee_instance.marqueeGoTo("next", null, settings); }
	            },global_marquee_settings.autoplay_slide_duration);
	        }
	    );
    });
}


/**
 * Tells a marquee to go to a selected slide
 *
 * @param index - The slide number to go to
 * @param options - Settings array
 **/
$.fn.marqueeGoTo = function(index,force_panel,my_settings) {

	if (my_settings == undefined) {
		var settings = new cloneObject(global_marquee_settings);
	} else {
		var settings = my_settings;
	}
    if (index == null) { index = 0; }
    
    var instance = $(this); 

    return this.each(function(){
        var marquee = $(this),
        	force_refresh = false,
            current_index = marquee.find(settings.selector.panels).first().children(settings.current_class).index(),
            total_index = marquee.find(settings.selector.panels).first().children(settings.selector.panel).length - 1;
        if (current_index == -1) { current_index = 0; } // -1 is given when none exists

        // Parse the index value    
        switch(index) {
            case "initialize": // This is used when initializing a marquee.  Prevents fade effect from occuring on load.
            	if (settings.autoselect) {
            		// console.log(settings);
	            	current_index = -1;
	                index = 0;
	                settings.fade_text = false;
	                var temp_hide_trans = true;
	                var fix_height = true;
            	} else {
	            	index = null;
            	}
            break;
            
            case settings.css_active_name:
            	index = current_index;
            	force_refresh = true;
            break;
        
            case "next":
            	if (marquee.hasClass("multiple")) {
	            	var fit = Math.floor(marquee.width() / marquee.find(settings.selector.panel).width());
	            	index = parseInt(current_index + fit);	
	            	
	            	if (total_index-fit <= index) {
		            	index = total_index-fit+1;
		            	marquee.addClass("current-page-last");
	            	}
            	} else {
	            	index = parseInt(current_index + 1);	
            	}
                
            break;
            
            case "prev":
            case "previous":
            	if (marquee.hasClass("multiple")) {
	            	var fit = Math.floor(marquee.width() / marquee.find(settings.selector.panel).width());
	            	index = parseInt(current_index - fit);	
	            	if (index < 0) { index = 0;}
	            	marquee.addClass("current-page-first");
            	} else {
	            	index = parseInt(current_index - 1);	
            	}
            break;
            
            case "first": index = 0; break;
            case "last": index = total_index; break;
            
            case "random":
                index = current_index; 
                while (index == current_index) { // Always change the pane so it doesn't appear broken
                    index = Math.floor(Math.random()*(parseInt(total_index)+1));
                }
            break;
        }
        
        if (index == null) { return false; }
        
        marquee.addClass("has-selection").removeClass("current-page-first current-page-last");
	
		setup_marquee_infinite(marquee,settings,index,total_index);
 
    	if (force_panel != null) { index = force_panel; }

		if (current_index != index || force_refresh) { // Only do the transition if we want a different panel 
			// Map necessary variables 
            var container	= marquee.find(settings.selector.panels).first(), 			// UL - holds panels
            	viewport	= marquee.find(settings.selector.viewport).first(), 		// Container's viewport
            	nav			= marquee.find(settings.selector.nav).first(),				// Container's controls
                margin		= container.css("margin-left").replace('px',''), 	// Container's left margin
                panels 		= container.find(settings.selector.panel),					// All panels
            	panel		= $(panels.get(index)),					 			// Current panel
                panel_height= panel.outerHeight(), 								// Current panel's height
                coordinates = panel.position(), 								// Current panel's coordinates
                travelTo	= parseInt(coordinates.left,10) - parseInt(margin,10), // Left + inverse of margin
                leftOffset = marquee.attr("data-left-offset");					
                // leftOffset - An optional left offset used when 
                // 				calculating margin-left for marquees that 
                // 				are slightly off center with visible 
                // 				exterior panels


    
            // Update travelTo
				if (leftOffset) { travelTo = travelTo - leftOffset;}

            // Fix padding
	            var padding_left = marquee.css("padding-left").replace('px','');
	            travelTo = parseInt(travelTo,10) - parseInt(padding_left,10);
            
            // Update navigation
	            nav.find(settings.current_class).removeClass(settings.css_active_name); // Remove current from direct nav
	            nav.find("li:eq("+index+")").addClass(settings.css_active_name); // Give new current item the current class

	        // Update marquee classes & trigger event
	        	if (index == 0) {
	        		var trigger = "first";
	        		var add_me = "current-panel-first";
	        		var remove_me = "current-panel-last";
	            } else if (index == total_index) {
	            	var trigger = "last";
	            	var add_me = "current-panel-last";
	            	var remove_me = "current-panel-first";
	            } else {
	            	var remove_me = "current-panel-first current-panel-last";
	            }
	        
	        	marquee
	        		.removeClass(remove_me + " current-panel-"+ marquee.attr("data-current-panel"))
	        		.attr("data-current-panel", (parseInt(index)+1))
	        		.addClass(add_me + " current-panel-"+(parseInt(index)+1));
	        	
	        	if (trigger) { marquee.trigger(trigger); }
	        	
	        // Update panel classes
	            container.children(settings.current_class).removeClass(settings.css_active_name); // Remove current from nav
	            panel.addClass(settings.css_active_name);  // Give new current panel the current class

            // Update child elements
            	marqueeClick_update_caption(marquee,nav,settings,index);
	            // marquee.find(".counter .index").html(parseInt(index)+1); // Update a counter (1 of 6) if it exists

			// Make the transition
				travelTo = travelTo * -1;
	
	            if ((settings.hide_transitions && current_index != -1) || temp_hide_trans == true) {
	            	var transitionSpeed = 1;
	            } else {
	            	var transitionSpeed = settings.transition_speed
	            }
	            
	            marquee_move_margin_left_to_here(travelTo,container,settings,panel_height,transitionSpeed,viewport);
        		        
	        if (fix_height) { fix_marquee_height(viewport,container,settings,panel_height); }
	        if (nav) { update_current_hashlinks(nav.find(settings.current_class).find("a").attr("href")); } // Update onpage links that link here
	        
	        setTimeout(function(){ marquee.trigger("newPanel"); },300);
        }
    });
}


/**
 * Runs whenever the hash changes on the address bar
 **/

function activate_marquee_hashchange() {
    var new_hash = window.location.hash;
    var link = $(settings.selector.nav).find('li a[href*="'+new_hash+'"]');

    $("._autoCurrentHash").removeClass("_autoCurrentHash");
    $.each(link,function(){
        var link_instance = $(this),
            new_index = link_instance.parent("li").index(),
            hash_change_instance = link_instance.parents(settings.selector.slider).first();
        hash_change_instance.trigger("hashUpdate").marqueeGoTo(new_index);
    });
    update_current_hashlinks(new_hash);
}

function update_current_hashlinks(hash) {
    $("._autoCurrentHash").removeClass("_autoCurrentHash");
	if (hash != "" && hash != "#") {
	    $('a[href*="'+hash+'"]').not(settings.selector.nav+' li a[href*="'+hash+'"]').addClass("_autoCurrentHash"); // Since these links already give themselves a current class
	}
}


////////////////////
// INITIALIZATION //
////////////////////
$(function(){
	/* Place your calls to specific marquees here if they need custom options. It MUST come before the next set of declarations. */
		
    /* The following assign all 'normal' marquees. If you're not providing custom options that overwrite the default settings, these alone will be fine. */
    if ($(global_marquee_settings.selector.slider).is(".fade").length > 0 ) { $(global_marquee_settings.selector.slider).is(".fade").not(".custom").marqueeize({"hide_transitions":true}); } // Each marqueeize binds new event, fix this. 
    if ($(".marquee:not(.fade),.marquee.slide").length > 0 ) {
		//console.log($(".marquee:not(.fade),.marquee.slide"));
    	$(".marquee:not(.fade),.marquee.slide").not(".custom").marqueeize(); 
    }
    if ($(global_marquee_settings.selector.slider).is(".autoplay").length > 0) { 
        $(global_marquee_settings.selector.slider).is(".autoplay").marqueeAutoplay(); 
        // Controls the autoplay functionality for a specific marquee
        $(".autoplay .pause").click(function(){
            var marquee = $(this).parents(global_marquee_settings.selector.slider).first(),
                autoplay = marquee.data("autoplay");
            if (autoplay) {
                $(this).html("play");
                marquee.removeClass("autoplay-on").addClass("autoplay-off").data("autoplay",false);
            } else {
                $(this).html("pause");
                marquee.removeClass("autoplay-off").addClass("autoplay-on").data("autoplay",true);
            }
        });
    }
    /*
    
    */
    
            
	// Ancillary functions
	
	// Make some marquee panels clickable in special cases
	$(".clickToFocus").find(settings.selector.panel).on("click",function(){
		if (!$(this).closest(settings.selector.slider).hasClass("swiping") && !$(this).hasClass(settings.css_active_name)) {
			$(this).closest(settings.selector.slider).trigger("clickToFocus").marqueeGoTo($(this).index());
		} else {
			// console.log("prevented");
		}
	});

	// Prevents these marquees from activating links when clicking panels	
	$(".clickToFocus").find(settings.selector.panel).find("a").on("click",function(e){
		if (!$(this).closest(settings.selector.panel).is(settings.current_class)) {
			$(this).closest(settings.selector.slider).marqueeGoTo($(this).closest(settings.selector.panel).index());
			return false;
		} 
	});
	

});
////////////////////////
// END INITIALIZATION //
////////////////////////

/**
 * IE7 Hashchange Polyfill
 * jQuery hashchange event - v1.3 - 7/21/2010
 * http://benalman.com/projects/jquery-hashchange-plugin/
 * 
 * Copyright (c) 2010 "Cowboy" Ben Alman
 * Dual licensed under the MIT and GPL licenses.
 * http://benalman.com/about/license/
 */
//(function($,e,b){var c="hashchange",h=document,f,g=$.event.special,i=h.documentMode,d="on"+c in e&&(i===b||i>7);function a(j){j=j||location.href;return"#"+j.replace(/^[^#]*#?(.*)$/,"$1")}$.fn[c]=function(j){return j?this.bind(c,j):this.trigger(c)};$.fn[c].delay=50;g[c]=$.extend(g[c],{setup:function(){if(d){return false}$(f.start)},teardown:function(){if(d){return false}$(f.stop)}});f=(function(){var j={},p,m=a(),k=function(q){return q},l=k,o=k;j.start=function(){p||n()};j.stop=function(){p&&clearTimeout(p);p=b};function n(){var r=a(),q=o(m);if(r!==m){l(m=r,q);$(e).trigger(c)}else{if(q!==m){location.href=location.href.replace(/#.*/,"")+q}}p=setTimeout(n,$.fn[c].delay)}$.browser.msie&&!d&&(function(){var q,r;j.start=function(){if(!q){r=$.fn[c].src;r=r&&r+a();q=$('<iframe tabindex="-1" title="empty"/>').hide().one("load",function(){r||l(a());n()}).attr("src",r||"javascript:0").insertAfter("body")[0].contentWindow;h.onpropertychange=function(){try{if(event.propertyName==="title"){q.document.title=h.title}}catch(s){}}}};j.stop=k;o=function(){return a(q.location.href)};l=function(v,s){var u=q.document,t=$.fn[c].domain;if(v!==s){u.title=h.title;u.open();t&&u.write('<script>document.domain="'+t+'"<\/script>');u.close();q.location.hash=v}}})();return j})()})(jQuery,this);

/* Object clone to clone properties of an object rather than just a reference*/
function cloneObject(source) {
    for (i in source) {
        if (typeof source[i] == 'source') {
            this[i] = new cloneObject(source[i]);
        }
        else{
            this[i] = source[i];
	}
    }
}
 


////////////////
// CHANGE LOG //
////////////////

/**
 * 0.7.3 
 * - Lots of cleanup and reorganization in preparation for rewrite.  Last update for Marquee.js!  Check out instead https://github.com/Skotlake/Svider.js
 *
 * 0.7.2 
 * - Updated for jQuery 1.9
 * - Fixes an error where autosize was applied to all marquees
 * - Adds "center" option for data-left-offset for marquees.  The page will automatically determine the offset so that the active marquee panel will be centered within the window.  Then adds leftOffsetCentered class.
 *
 * 0.7.1
 * - Infinite marquees: adds support for "buffering" new slides, allowing you to designate a number of slides ahead of time when the clone operation should take place (in cases where the design would show white-space on the edge of the screen otherwise).  Use a number for the data-infinite-buffer attribute on the .marquee element: data-infinite-buffer="3" to do it when you are 3 slides away from the end.
 *
 * 0.7
 * - Adds events for easy scripting: init, newPanel, prev, next, first, last, random, deselect, navClick, navHover, beginning, end, hashUpdate, clickToFocus, swiped
 * - Working on new types of sliders: multiple panels visible, next button moves "pages" of panels, etc
 * - Future reference to fix autoplay bug when window is not focused: http://stackoverflow.com/questions/1060008/is-there-a-way-to-detect-if-a-browser-window-is-not-currently-active 
 *
 *
 * 0.6.5
 * - Adds support for automatically sizing panels and viewport based on size of parent
 * - Panels also resize (width) when the window is resized or orientation is changed
 * - Adds support for a ".marquee_deselect" button which removes any current classes from a marquee
 * - Adds a ".has-selection" class to marquees to offer alternate styling when something has a selection, and when something doesn't
 * - Adds autoselect option to determine whether marquee should autoselect the first panel.  Use ".no-autoselect" to disable.
 * 
 * 0.6.4.2
 * - Removes a // console.log message 
 *
 * 0.6.4.1
 * - Makes links in non-current .clickToFocus panels non-clickable
 *
 * 0.6.4
 * - Working on draggable marquees.  Set touchMove to drag to enable
 * - BUG: No touchscreen support
 * - BUG: Bouncing error when dragging on boundary panels
 *
 * 0.6.3
 * - Add "hoverActivate" option to allow hovering activation of marquee-nav li items.  Add hover-activate class to .marquee or set hoverActivate to true
 * - Adds "Cowboy" Ben Alman's hashchange polyfill for IE7 support
 *
 * 0.6.2
 * - .marquee elements now receive CSS classes that tell its current position, including .current-panel-first, .current-panel-last, and .current-panel-#, where # is the number of the current panel (not the index position)
 * - Improves _autoCurrentHash class to only be given when a real hash link exists (no # with nothing following it)
 * - Add ".fixed" to .marquee to override auto height resizing
 * - Fixes swipes not working correctly on "infinite" scrollers
 * - Add ".clickToFocus" class option which allows inactive panels to be clicked and cause them to become current.  These elements are not swipable currently because the browser is not able to separate the swipe and click events.
 * 
 * 0.6.1
 * - Bug fixes
 * - If page is initialized with a #hash, links that point to this #hash will now get .autoCurrentHash class
 *
 * 0.6
 * - Adds swipe support: left / right.  Tested on Android and iOS5.  Uses mouseup/mousedown for desktop swiping.  Set enableTouch setting to true to enable, and set swipeThreshold if needed.  Can also customize touchstartevent and touchendevent variables if only one type (mousedown or touch) is desired.  By default, it maps to both.
 *
 * 0.5.4
 * - Ensures that the height is always set correctly on page load if the marquee can auto-resize
 *
 * 0.5.3
 * - Fixes a bug where hide_transition was not always followed.
 *
 * 0.5.2
 * - Fixes a bug where a sub-marquee could confuse its parent marquee when autoplaying and using the parents next/previous buttons
 *
 * 0.5.1
 * - Improved performance of autoplaying marquees.
 * - Improved dynamic height resizing
 * - Fixes a bug where sub-marquees did not keep their '.current' designations when the parent marquee was clicked
 *
 * 0.4.7.1
 * - Fixes a bug where total number of panels can be miscalculated
 *
 * 0.5
 * - Adds support for marquees within marquees, allowing an infinite number of marquees to be used
 * - Rewrite of most event selectors and assignments to "sandbox" marquees to only effect their direct content
 *
 * 0.4.7
 * - Speeds up height resizing, and only runs it when needed.  Before, it was attempting to change the height each time.  When the height does need to change, it'll do it in 1/10th the time of the designated transition speed.  Before, it was using the same value, causing any panels where the height must change to take twice as long to load.
 * - Fixes a bug where custom options weren't always followed
 * - Better assignment of the marqueeize function.  When a marquee receives the marqueeize method, it receive a class of "hasBeenMarqueed."  The marqueeize function checks for this class, and if a marquee already has it, the marqueeize function will not be assigned to it.  This makes it easier to target specific marquees and give them custom options.
 *
 * 0.4.6.5
 * - Brings back auto height, might need more testing in IE.
 *
 * 0.4.6.4
 * - Bug fixes
 *
 * 0.4.6.3
 * - Fixed a bug with initialization and conflicting 'current' classes
 * - Fixed a bug where tabs with an initial tab based on the url HASH would not function properly
 *
 * 0.4.6.2
 * - Fixed a bug where the first panel would not auto-size on initialization
 * 
 * 0.4.6.1
 * - Added a default option where the marquee and the viewport will automatically resize based on the size of the current panel.  To disable this, add a "fixed" class to the .marquee element, or change initialization options.
 *
 * 0.4.6
 * - Changed "hide transition" speed from 150ms to 10ms
 * - Optimizing marquee.css to be more library-like
 * 0.4.5
 * - Added "infinite" carousel option, where instead of revolving backwards, the carousel will appear to loop forever.  limitation: going backwards on the first panel does not animate flawlessly.  therefore, looping backward from the first will use a fade for a more graceful transition.
 * - Changed the way the counter is updated to account for this new carousel type.  A data-original-length attribute is attached to the marquee with the number of the original elements in the marquee.
 * 0.4.3
 * - Special edits
 *
 * 0.4.2
 * - Added a hash "listener", so that the active tab will change if a hash link is clicked. 
 *
 * 0.4.1 
 * - Fixes a bug where the first tab would not be initialized if its' hash was used.  Also cleaned up initialization code.
 *
 * 0.4
 * - Added hash support.  On page load, if a <A> of one of the tabs matches the hash (<a href="#load_this_tab"), then that tab will be auto-selected on page load.
 *
 * 0.3.3
 * - Fixed a bug where panels did not properly scroll that contained an inline list item
 *
 * 0.3.2
 * - Changed the way autoplay sets the autoplay interval.  It now clears the timer when you hover over the content, so that when you hover off, the full timer runs (instead of it just being a loop and potentially a fraction of the timer run)
 *
 * 0.3.1
 * - Added marqueeGoTo("initialize", null, settings) which is a clean way of initializing a marquee.  
 * - Cleaned up fade transition effect
 *
 * 0.3
 * - Bug fixed: Multiple .marqueeize functions attached multiple .click functions to elements
 *
 * 0.2
 * - Added new fade type (use hide_transitions: true)
 *
 * version 0.1
 * - Initial version
 *
 *
 **/
 
 
function setup_marquee_autocenter(marquee,settings) {
	if (marquee.attr("data-left-offset") == "center") {
		var new_offset = ($(window).width() - marquee.find(settings.selector.panel).width())/2;
		marquee.attr("data-left-offset",new_offset).addClass("leftOffsetCentered");
		
		var leftOffsetCentered_timeout;
		$(window).on(settings.orientationevent,function(){
			clearTimeout(leftOffsetCentered_timeout);
			leftOffsetCentered_timeout = setTimeout(function(){
				// Fix auto-centered marquees
				var centers = $(".leftOffsetCentered");
				$.each(centers,function(i,el){
					el = $(el);
					var new_offset = ($(window).width() - el.find(settings.selector.panel).width())/2;
					el.attr("data-left-offset",new_offset).addClass("leftOffsetCentered");
					el.marqueeGoTo(settings.css_active_name, null, settings);
				});

			},200);
		});

	}
}


function setup_marquee_autosize(marquee,settings) {
	if (settings.autosize) {
		// console.log(settings);
		var new_width = marquee.width();
		marquee.addClass("autosized").find(settings.selector.panel).add(settings.selector.viewport,marquee).width(new_width);

		var timeout;

		$(window).on(settings.orientationevent,function(){
			var new_width = marquee.width();
			marquee.find(settings.selector.panel).add(settings.selector.viewport,marquee).width(new_width).attr("data-width","yes");
			clearTimeout(timeout);
			timeout = setTimeout(function(){
				// console.log("Fixing");
				//var i = marquee.find(settings.current_class).index();
				// console.log(i);
				//force_refresh=true;
				marquee.marqueeGoTo(settings.css_active_name, null, settings);
			},200);
		});
	}
}

function setup_marquee_controls(marquee,settings) {
	marquee.find(settings.selector.nav).find("li").on("click",function(e){ e.preventDefault(); marquee.trigger("navClick"); $(this).marqueeClick();});
    if (settings.hoverActivate) { marquee.find(settings.selector.nav).find("li").on("mouseover",function(e){ e.preventDefault(); marquee.trigger("navHover"); $(this).marqueeClick();}); }
    marquee.find(".marquee_prev").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("prev").first().marqueeGoTo("prev", null, settings);});
    marquee.find(".marquee_next").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("next").first().marqueeGoTo("next", null, settings);});
    marquee.find(".marquee_first").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("first").first().marqueeGoTo("first", null, settings);});
    marquee.find(".marquee_last").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("last").first().marqueeGoTo("last", null, settings);});
    marquee.find(".marquee_random").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("random").first().marqueeGoTo("random", null, settings);});
    marquee.find(".marquee_deselect").first().on("click", function(e){ e.preventDefault();$(this).parents(settings.selector.slider).trigger("deselect").removeClass("has-selection").find(settings.current_class).removeClass(settings.css_active_name);});
}


function setup_marquee_swiping(marquee,settings) {
	if (settings.enableTouch && !marquee.hasClass("clickToFocus")) {
//			if (settings.enableTouch) {			
        marquee.on(settings.touchstartevent,function(e){

        	$(this).addClass("swiping");
        	var x_origin = e.clientX,
	        	margin_origin = $(this).find(settings.selector.panels).css("margin-left").replace("px","");

			if (settings.touchstartevent == "mousedown") { e.preventDefault(); /* Prevents highlight or grabbing elements on desktop browsers */ }
			var x = (e.pageX) ? e.pageX : e.originalEvent.changedTouches[0].pageX,
				y = (e.pageY) ? e.pageY : e.originalEvent.changedTouches[0].pageY;
			$(this).data({"start_x":x,"start_y":y});
			
			if (settings.touchMode == "drag") {
				marquee.addClass("touch-event-occurring");
				 marquee.on(settings.touchmoveevent, function(e){
		        	e.preventDefault();
		        	// To add -- support for touch screen
		        	var x = (e.pageX) ? e.pageX : e.originalEvent.changedTouches[0].pageX;
		        	var distance = x - parseInt(x_origin);
		        	var	new_margin = parseInt(margin_origin) + parseInt(distance);
		        	marquee.find(settings.selector.panels).css("margin-left",new_margin);

		        });
	        }
        });
        
        marquee.on(settings.touchendevent,function(e){	
        	marquee.off(settings.touchmoveevent);
        	setTimeout(function(){
	        	marquee.removeClass("touch-event-occurring").removeClass("swiping");	
        	},1000);
        	
			var marquee_moved = false; // Flag to ensure that movement occurs 
        
        	var x_swipe, y_swipe,
        		x = (e.pageX) ? e.pageX : e.originalEvent.changedTouches[0].pageX,
				y = (e.pageY) ? e.pageY : e.originalEvent.changedTouches[0].pageY;

			var x_change = $(this).data("start_x") - x,
				y_change = $(this).data("start_y") - y;

        	if (x_change < 0) { x_swipe = "left"; }
        	else if (x_change > 0) { x_swipe = "right"; }
        	
        	if (y_change < 0) { y_swipe = "up"; }
        	else if (y_change > 0) { y_swipe = "down"; }
			if (Math.abs(x_change) > Math.abs(y_change)) { // Ensures only swipes intended to be horizontal are registered
   				
   				if (Math.abs(x_change) > settings.swipeThreshold) {
   					// console.log("swipe registered");
       				marquee.trigger("swiped");
       				if (x_swipe == "left") { 
       					
       					if ($(this).find(settings.selector.panel).is(settings.current_class).index() != 0) { $(this).marqueeGoTo("prev", null, settings); marquee_moved = true; }
       					else { // Bounce effect on the beginning (first panel)
       						var orig = $(this).find(settings.selector.panels).css("margin-left").replace("px","");
       						var bounce_this_far = 40;
       						if ($(this).attr("data-left-offset")) { bounce_this_far = bounce_this_far + $(this).attr("data-left-offset"); }
       						$(this).find(settings.selector.panels).animate({"margin-left":(orig + bounce_this_far)}, 200).animate({"margin-left":(orig)}, 400, (jQuery.easing['easeOutBounce']) ? "easeOutBounce" : "swing"); marquee_moved = true; }
       				} else if (x_swipe == "right") { 
       					if ($(this).find(settings.selector.panel).find(settings.current_class).index() != (parseInt(marquee.find(settings.selector.panel).length - 1))) { $(this).marqueeGoTo("next", null, settings); marquee_moved = true; }
       					else { // Bounce effect on the end (last panel)
       						var orig = $(this).find(settings.selector.panels).css("margin-left").replace("px","");
       						$(this).find(settings.selector.panels).animate({"margin-left":(orig - 40)}, 200).animate({"margin-left":(orig)}, 400, (jQuery.easing['easeOutBounce']) ? "easeOutBounce" : "swing"); marquee_moved = true; }
       				}		       				
   				} 
			} else {
				// Y change was greater than x change	
			}

				$(this).data({"start_x":null,"end_x":null});
				
				// Auto-fix marquee if swipe wasn't enough to register
				if (marquee_moved == false && x_change > 0) {
					marquee.marqueeGoTo(settings.css_active_name, null, settings);
				} 
			
        	});
        	
        }
}



function fix_marquee_height(viewport,container,settings,panel_height) {
	if (settings.hide_transitions) {
    	viewport.css({"height": panel_height+"px"}); 
    	container.css({"height": panel_height+"px"});        	
	} else {
        viewport.animate({"height": panel_height+"px"}, (settings.transition_speed/2)); 
    	container.animate({"height": panel_height+"px"}, (settings.transition_speed/2));
	}
}

function marquee_move_margin_left_to_here(travelTo,container,settings,panel_height,speed,viewport) {

	container.animate({"margin-left": travelTo}, speed, "swing", function () {
		if (settings.resizable == true && panel_height) {
			container.animate({"height": panel_height+"px"}, (speed/2));
			if (viewport != undefined) {
				viewport.animate({"height": panel_height+"px"}, (speed/2)); 
			}
		}
	});


}


function marqueeClick_update_caption(marquee,nav,settings,index) {
	            if (marquee.find("."+settings.marquee_caption).length) {
	                var caption = $(nav).find("li:eq("+index+") .caption").html(); // Let's check for a .caption element
	                if (caption == null) {
	                    var caption = $(nav).find("li:eq("+index+")").attr("title"); // Let's check for a title attr on the LI
	                }
	                
	                if (caption) {
	                    $(marquee).find("."+settings.marquee_caption).fadeTo(500,1).html(caption); // Change the caption
	                } else {
	                    $(marquee).find("."+settings.marquee_caption).fadeTo(500,0); // Fade out the caption
	                }
	            } 
            }
            
            
function setup_marquee_infinite(marquee,settings,index,total_index) {
			// If the "infinite" class is applied to the marquee, the LI elements will be cloned so that it appears the carousel always continues in one direction.
	        // However, this currently only goes forward -- if looping backward from the first, it will loop all the way back.
	        if (marquee.hasClass("infinite") == true) {
	            var panels_container = marquee.find(settings.selector.panels).first(),
	            	panels = $(panels_container).children(settings.selector.panel),
	            	container_width = panels_container.width();
	            	
	            if (marquee.attr("data-infinite-buffer")) {
		            var buffered_index = parseInt(marquee.attr("data-infinite-buffer")) + index;
	            } else {
		            var buffered_index = index;
	            }
	            if (buffered_index == total_index || buffered_index > total_index) { // End, going to beginning // Change > to == on 5/4/12, builds infinite one ahead of when needed
	                panels.clone().appendTo(panels_container);
	                panels_container.width(container_width*2);
	                total_index = (total_index * 2) + 1;
	            }
	            
	            if (index < 0) { // beginning, going to end
	                index = total_index;
	              
	                panels.clone().prependTo(panels_container);
	                panels_container.width(container_width*2);
	                
	                total_index = (total_index * 2) + 1;
	                index = total_index;
	                var temp_hide_trans = true; // Because we don't want the user to see all the panels, hide the transition
	            } 
	        } 
		}
