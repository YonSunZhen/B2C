using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// IndexContent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IndexContent
	{
		public IndexContent()
		{}
		#region Model
		private string _id;
		private int? _isshowsuccess;
		private int? _successtotal;
		private int? _isshowproduct;
		private int? _producttotal;
		private int? _isshowarticle;
		private int? _articletotal;
		private int? _isshowvideo;
		private int? _isrun;
		private string _videopath;
		private string _videotitle;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 1为显示，0为不显示
		/// </summary>
		public int? isShowSuccess
		{
			set{ _isshowsuccess=value;}
			get{return _isshowsuccess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? successTotal
		{
			set{ _successtotal=value;}
			get{return _successtotal;}
		}
		/// <summary>
		/// 1为显示，0为不显示
		/// </summary>
		public int? isShowProduct
		{
			set{ _isshowproduct=value;}
			get{return _isshowproduct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? productTotal
		{
			set{ _producttotal=value;}
			get{return _producttotal;}
		}
		/// <summary>
		/// 1为显示，0为不显示
		/// </summary>
		public int? isShowArticle
		{
			set{ _isshowarticle=value;}
			get{return _isshowarticle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? articleTotal
		{
			set{ _articletotal=value;}
			get{return _articletotal;}
		}
		/// <summary>
		/// 1为显示，0为不显示
		/// </summary>
		public int? isShowVideo
		{
			set{ _isshowvideo=value;}
			get{return _isshowvideo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isRun
		{
			set{ _isrun=value;}
			get{return _isrun;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoPath
		{
			set{ _videopath=value;}
			get{return _videopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoTitle
		{
			set{ _videotitle=value;}
			get{return _videotitle;}
		}
		#endregion Model

	}
}

