using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// 图片通用上传类
/// </summary>
public class ImageHelper
{
	protected UploadImageInfo upImage = new UploadImageInfo();
    public ImageHelper() { }
	/// <summary>
	/// 上传图片
	/// </summary>
	/// <param name="postedFile">文件</param>
	/// <param name="uploadPath">上传文件夹路径</param>
	///<param name="maxSize">大小</param>
	/// <param name="thumbnail">是否生成缩略图</param>
	public UploadImageInfo UploadImage(HttpPostedFile postedFile, string uploadPath, int maxSize, bool thumbnail, string Logo_brand, int waterMarkType, int waterMarkPosition, string waterMarkContent, string waterMarkPicture, int waterMarkTransparency, int width = 0, int height = 0)
	{
		//上传配置
		//string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
		//string[] fileTypes = { "image/png", "image/bmp", "image/gif", "image/jpeg" };		
		//string uploadpath = HttpContext.Current.Server.MapPath(pathbase);//获取文件上传路径

		try
		{          
			var filepath = HttpContext.Current.Server.MapPath(uploadPath);           
            //目录创建
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string fp_year = uploadPath + year + "/";
            string fp_year_month = fp_year + month + "/";
            var filepath_year = HttpContext.Current.Server.MapPath(fp_year);
            var filepath_year_month = HttpContext.Current.Server.MapPath(fp_year_month);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            else
            {
                if (!Directory.Exists(filepath_year))
                {
                    Directory.CreateDirectory(filepath_year);
                }
                else
                {
                    if (!Directory.Exists(filepath_year_month))
                    {
                        Directory.CreateDirectory(filepath_year_month);
                    }
                }
            }

            //string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
            string[] filetype = { "image/png", "image/bmp", "image/gif", "image/jpeg", "image/PNG", "image/jpg", "image/JPG", "image/JPEG" };
			if (!filetype.Contains(postedFile.ContentType))
			{
				upImage.msg = "图片格式错误";
			}
			int fileSize = postedFile.ContentLength;
			//大小验证
			if (fileSize >= maxSize * 1024 * 1024)
			{
				upImage.msg = string.Format("图片大小超出，请上传小于{0}M的图片", maxSize);
			}
			//保存图片
			if (string.IsNullOrEmpty(upImage.msg))
			{
				var oldName = postedFile.FileName;
				//获取文件扩展名称
				string fileExt = Common.GetFileExt(oldName);
				//重命名文件		
				var newName = Common.Rename(oldName);
                //创建图像流
                Image img = Image.FromStream(postedFile.InputStream);
                //保存的路径				
                //postedFile.SaveAs(filepath_year_month + newName + fileExt);

                if(waterMarkType == 1)
                {
                    AddImageWaterMarkText(img, filepath_year_month + newName + fileExt, waterMarkContent, waterMarkPosition, 100, "Verdana", 24, waterMarkTransparency);
                }
                else if(waterMarkType == 2)
                {
                    AddImageWaterMarkPic(img, filepath_year_month + newName + fileExt, HttpContext.Current.Server.MapPath(waterMarkPicture), waterMarkPosition, 100, waterMarkTransparency);
                }
                else
                {
                    postedFile.SaveAs(filepath_year_month + newName + fileExt);
                }

                //生成缩略图
                if (thumbnail)
				{
                    //string sFileName = "thumb_" + newName;
                    //缩略图文件名
                    if (Logo_brand == "success_Del")
                    {
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg", width, height, ThumbnailType.WidthHeightCut);
                    }
                    else if(Logo_brand == "Multiple")
                    {
                        this.MakeThumbnail_(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg", width, height, ThumbnailType.WidthHeightCut);
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg" + "_1.jpg", 192, 128, ThumbnailType.WidthHeightCut);
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg" + "_2.jpg", 120, 80, ThumbnailType.WidthHeightCut);                  
                    }
                    else if(Logo_brand == "width")
                    {
                        this.MakeThumbnail_o(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg", width, height, ThumbnailType.WidthHeightCut);
                    }
                    else if(Logo_brand == "Multiple_other")
                    {
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg", width, height, ThumbnailType.WidthHeightCut);
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg" + "_400.jpg", 400, 400, ThumbnailType.WidthHeightCut);
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg" + "_200.jpg", 200, 200, ThumbnailType.WidthHeightCut);
                        this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg" + "_60.jpg", 60, 60, ThumbnailType.WidthHeightCut);

                    }                                                                                            
                    upImage.thumb = fp_year_month + newName + fileExt + "_.jpg"; //返回的小图  					

                }

                File.Delete(filepath_year_month + newName + fileExt);

				upImage.status = (int)ResultCode.Success;
				upImage.msg = "上传成功";
				upImage.name = oldName;
				upImage.path = fp_year_month + newName + fileExt; //返回的原图片URL
				upImage.size = fileSize;
				upImage.extension = fileExt;

                upImage.url = fp_year_month + newName + fileExt;
                upImage.uploaded = 1;
            }
			else
			{
				upImage.status = (int)ResultCode.Fail;
			}
		}
		catch
		{
			upImage.status = (int)ResultCode.Fail;
			upImage.msg = "图片上传出错";
		}
		return upImage;
	}

    /// <summary>
	/// 水印设置，上传水印图片
	/// </summary>
	/// <param name="postedFile">文件</param>
	/// <param name="uploadPath">上传文件夹路径</param>
	///<param name="maxSize">大小</param>
	/// <param name="thumbnail">是否生成缩略图</param>
    public UploadImageInfo UploadImage(HttpPostedFile postedFile, string uploadPath, int maxSize, bool thumbnail)
    {
        //上传配置
        //string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
        //string[] fileTypes = { "image/png", "image/bmp", "image/gif", "image/jpeg" };		
        //string uploadpath = HttpContext.Current.Server.MapPath(pathbase);//获取文件上传路径

        try
        {
            var filepath = HttpContext.Current.Server.MapPath(uploadPath);
            //目录创建
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string fp_year = uploadPath + year + "/";
            string fp_year_month = fp_year + month + "/";
            var filepath_year = HttpContext.Current.Server.MapPath(fp_year);
            var filepath_year_month = HttpContext.Current.Server.MapPath(fp_year_month);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            else
            {
                if (!Directory.Exists(filepath_year))
                {
                    Directory.CreateDirectory(filepath_year);
                }
                else
                {
                    if (!Directory.Exists(filepath_year_month))
                    {
                        Directory.CreateDirectory(filepath_year_month);
                    }
                }
            }

            //string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
            string[] filetype = { "image/png", "image/bmp", "image/gif", "image/jpeg", "image/PNG", "image/jpg", "image/JPG", "image/JPEG" };
            if (!filetype.Contains(postedFile.ContentType))
            {
                upImage.msg = "图片格式错误";
            }
            int fileSize = postedFile.ContentLength;
            //大小验证
            if (fileSize >= maxSize * 1024 * 1024)
            {
                upImage.msg = string.Format("图片大小超出，请上传小于{0}M的图片", maxSize);
            }
            //保存图片
            if (string.IsNullOrEmpty(upImage.msg))
            {
                var oldName = postedFile.FileName;
                //获取文件扩展名称
                string fileExt = Common.GetFileExt(oldName);
                //重命名文件		
                var newName = Common.Rename(oldName);

                //保存的路径				
                postedFile.SaveAs(filepath_year_month + newName + fileExt);
                //生成缩略图
                if (thumbnail)
                {
                    this.MakeThumbnail(filepath_year_month + newName + fileExt, filepath_year_month + newName + fileExt + "_.jpg", 200, 200, ThumbnailType.WidthHeightCut);
                    upImage.thumb = fp_year_month + newName + fileExt + "_.jpg"; //返回的小图 
                }
                upImage.status = (int)ResultCode.Success;
                upImage.msg = "上传成功";
                upImage.name = oldName;
                upImage.path = fp_year_month + newName + fileExt; //返回的原图片URL
                upImage.size = fileSize;
                upImage.extension = fileExt;

                upImage.url = fp_year_month + newName + fileExt;
                upImage.uploaded = 1;
            }
            else
            {
                upImage.status = (int)ResultCode.Fail;
            }
        }
        catch
        {
            upImage.status = (int)ResultCode.Fail;
            upImage.msg = "图片上传出错";
        }
        return upImage;
    }

    /// <summary>
	/// 上传ckeditor的图片
	/// </summary>
	/// <param name="postedFile">文件</param>
	/// <param name="uploadPath">上传文件夹路径</param>
	///<param name="maxSize">大小</param>
	/// <param name="thumbnail">是否生成缩略图</param>
    public UploadImageInfo UploadImage(HttpPostedFile postedFile, string uploadPath, int maxSize)
    {
        //上传配置
        //string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
        //string[] fileTypes = { "image/png", "image/bmp", "image/gif", "image/jpeg" };		
        //string uploadpath = HttpContext.Current.Server.MapPath(pathbase);//获取文件上传路径

        try
        {
            var filepath = HttpContext.Current.Server.MapPath(uploadPath);
            //目录创建
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string fp_year = uploadPath + year + "/";
            string fp_year_month = fp_year + month + "/";
            var filepath_year = HttpContext.Current.Server.MapPath(fp_year);
            var filepath_year_month = HttpContext.Current.Server.MapPath(fp_year_month);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            else
            {
                if (!Directory.Exists(filepath_year))
                {
                    Directory.CreateDirectory(filepath_year);
                }
                else
                {
                    if (!Directory.Exists(filepath_year_month))
                    {
                        Directory.CreateDirectory(filepath_year_month);
                    }
                }
            }

            //string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
            string[] filetype = { "image/png", "image/bmp", "image/gif", "image/jpeg", "image/PNG", "image/jpg", "image/JPG", "image/JPEG" };
            if (!filetype.Contains(postedFile.ContentType))
            {
                upImage.msg = "图片格式错误";
            }
            int fileSize = postedFile.ContentLength;
            //大小验证
            if (fileSize >= maxSize * 1024 * 1024)
            {
                upImage.msg = string.Format("图片大小超出，请上传小于{0}M的图片", maxSize);
            }
            //保存图片
            if (string.IsNullOrEmpty(upImage.msg))
            {
                var oldName = postedFile.FileName;
                //获取文件扩展名称
                string fileExt = Common.GetFileExt(oldName);
                //重命名文件		
                var newName = Common.Rename(oldName);

                //保存的路径				
                postedFile.SaveAs(filepath_year_month + newName + fileExt);                
                
                upImage.status = (int)ResultCode.Success;
                upImage.msg = "上传成功";
                upImage.name = oldName;
                upImage.path = fp_year_month + newName + fileExt; //返回的原图片URL
                upImage.size = fileSize;
                upImage.extension = fileExt;

                upImage.url = fp_year_month + newName + fileExt;
                upImage.uploaded = 1;
            }
            else
            {
                upImage.status = (int)ResultCode.Fail;
            }
        }
        catch
        {
            upImage.status = (int)ResultCode.Fail;
            upImage.msg = "图片上传出错";
        }
        return upImage;
    }

    /// <summary>
    /// 上传图片加水印
    /// </summary>
    /// <param name="postedFile">文件</param>
    /// <param name="uploadPath">上传文件夹路径</param>
    /// <param name="maxSize">文件大小</param>
    /// <param name="waterType">水印类型</param>
    /// <param name="image_text">水印图片&水印文字</param>
    /// <param name="position">水印位置</param>
    /// <param name="thumbnail">是否生成缩略图</param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public UploadImageInfo UploadImage(HttpPostedFile postedFile, string uploadPath, int maxSize, WatermarkType waterType, string image_text, WatermarkPosition position, bool thumbnail, int width = 0, int height = 0)
	{
		try
		{
			var filepath = HttpContext.Current.Server.MapPath(uploadPath);
			//目录创建
			if (!Directory.Exists(filepath))
			{
				Directory.CreateDirectory(filepath);
			}

			string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };  //文件允许格式
			if (filetype.Contains(postedFile.ContentType))
			{
				upImage.msg = "图片格式错误";
			}
			int fileSize = postedFile.ContentLength;
			//大小验证
			if (fileSize >= maxSize * 1024 * 1024)
			{
				upImage.msg = string.Format("图片大小超出，请上传小于{0}M的图片", maxSize);
			}
			//保存图片
			if (string.IsNullOrEmpty(upImage.msg))
			{
				var oldName = postedFile.FileName;
				//获取文件扩展名称
				string fileExt = Common.GetFileExt(oldName);
				//重命名文件		
				var newName = Common.Rename(oldName);
				//创建图像流
				Image img = Image.FromStream(postedFile.InputStream);

				if (waterType == WatermarkType.Text)
				{
					AddImageWaterMarkText(img, filepath + newName, image_text, (int)position, 90, "Verdana", 24, 10);
				}
				else if (waterType == WatermarkType.Image)
				{
					if (!File.Exists(image_text))
					{
						upImage.status = (int)ResultCode.Fail;
						upImage.msg = "水印图片不存在";
						return upImage;
					}
					else
					{
						AddImageWaterMarkPic(img, filepath + newName, image_text, (int)position, 80, 10);
					}
				}
				if (thumbnail)
				{
					string sFileName = "thumb_" + newName;//缩略图文件名
					this.MakeThumbnail(filepath + newName, filepath + sFileName, width, height, ThumbnailType.WidthHeightCut);
					upImage.thumb = uploadPath + sFileName; //返回的小图
				}

				upImage.status = (int)ResultCode.Success;
				upImage.name = oldName;
				upImage.path = uploadPath + newName; //返回的原图片URL
				upImage.size = fileSize;
				upImage.extension = fileExt;
			}
			else
			{
				upImage.status = (int)ResultCode.Fail;
			}
		}
		catch
		{
			upImage.status = (int)ResultCode.Fail;
			upImage.msg = "图片上传出错";
		}
		return upImage;
	}

	/// <summary>
	/// 加图片水印
	/// </summary>
	/// <param name="img">要加水印的原图﻿(System.Drawing)</param>
	/// <param name="filename">文件名</param>
	/// <param name="watermarkFilename">水印文件名</param>
	/// <param name="watermarkStatus">图片水印位置1=左上 2=中上 3=右上 4=左中  5=中中 6=右中 7=左下 8=中下 9=右下</param>
	/// <param name="quality">加水印后的质量0~100,数字越大质量越高</param>
	/// <param name="watermarkTransparency">水印图片的透明度1~10,数字越小越透明,10为不透明</param>	
	public static void AddImageWaterMarkPic(Image img, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
	{
		Graphics g = Graphics.FromImage(img);
		//设置高质量插值法
		//g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
		//设置高质量,低速度呈现平滑程度
		//g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		Image watermark = new Bitmap(watermarkFilename);

        if (watermark.Height >= img.Height || watermark.Width >= img.Width)
            return;
        //throw new Exception("水印图片大小大于源图片大小");

        ImageAttributes imageAttributes = new ImageAttributes();
		ColorMap colorMap = new ColorMap();

		colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
		colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
		ColorMap[] remapTable = { colorMap };

		imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

		float transparency = 0.5F;
		if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
			transparency = (watermarkTransparency / 10.0F);


		float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };

		ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

		int xpos = 0;
		int ypos = 0;

		switch (watermarkStatus)
		{
			case 1:
				xpos = (int)(img.Width * (float).01);
				ypos = (int)(img.Height * (float).01);
				break;
			case 2:
				xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
				ypos = (int)(img.Height * (float).01);
				break;
			case 3:
				xpos = (int)((img.Width * (float).99) - (watermark.Width));
				ypos = (int)(img.Height * (float).01);
				break;
			case 4:
				xpos = (int)(img.Width * (float).01);
				ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
				break;
			case 5:
				xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
				ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
				break;
			case 6:
				xpos = (int)((img.Width * (float).99) - (watermark.Width));
				ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
				break;
			case 7:
				xpos = (int)(img.Width * (float).01);
				ypos = (int)((img.Height * (float).99) - watermark.Height);
				break;
			case 8:
				xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
				ypos = (int)((img.Height * (float).99) - watermark.Height);
				break;
			case 9:
				xpos = (int)((img.Width * (float).99) - (watermark.Width));
				ypos = (int)((img.Height * (float).99) - watermark.Height);
				break;
		}

		g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

		ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
		ImageCodecInfo ici = null;
		foreach (ImageCodecInfo codec in codecs)
		{
			if (codec.MimeType.IndexOf("jpeg") > -1)
				ici = codec;
		}
		EncoderParameters encoderParams = new EncoderParameters();
		long[] qualityParam = new long[1];
		if (quality < 0 || quality > 100)
			quality = 80;

		qualityParam[0] = quality;

		EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
		encoderParams.Param[0] = encoderParam;

		if (ici != null)
			img.Save(filename, ici, encoderParams);
		else
			img.Save(filename);

		g.Dispose();
		img.Dispose();
		watermark.Dispose();
		imageAttributes.Dispose();
	}

    /// <summary>
    /// 增加图片文字水印
    /// </summary>
    /// <param name="img">要加水印的原图﻿(﻿System.Drawing)</param>
    /// <param name="filename">文件名</param>
    /// <param name="watermarkText">水印文字</param>
    /// <param name="watermarkStatus">图片水印位置1=左上 2=中上 3=右上 4=左中  5=中中 6=右中 7=左下 8=右中 9=右下</param>
    /// <param name="quality">加水印后的质量0~100,数字越大质量越高</param>
    /// <param name="fontname">水印的字体</param>
    /// <param name="fontsize">水印的字号</param>
    /// <param name="watermarkTransparency">水印图片的透明度1~10,数字越小越透明,10为不透明</param>
    public static void AddImageWaterMarkText(Image img, string filename, string watermarkText, int watermarkStatus, int quality, string fontname, int fontsize, int watermarkTransparency)
	{
        int transparency = 1;
		Graphics g = Graphics.FromImage(img);
		Font drawFont = new Font(fontname, fontsize, FontStyle.Bold, GraphicsUnit.Pixel);
		SizeF crSize;
		crSize = g.MeasureString(watermarkText, drawFont);
      
		float xpos = 0;//左边距
		float ypos = 0;//上边距

        if(watermarkTransparency >= 1 || watermarkTransparency <= 10)
        {
            transparency = (watermarkTransparency * 25);
        }

		switch (watermarkStatus)
		{
			case 1:
				xpos = (float)img.Width * (float).01;
				ypos = (float)img.Height * (float).01;
				break;
			case 2:
				xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
				ypos = (float)img.Height * (float).01;
				break;
			case 3:
				xpos = ((float)img.Width * (float).99) - crSize.Width;
				ypos = (float)img.Height * (float).01;
				break;
			case 4:
				xpos = (float)img.Width * (float).01;
				ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
				break;
			case 5:
				xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
				ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
				break;
			case 6:
				xpos = ((float)img.Width * (float).99) - crSize.Width;
				ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
				break;
			case 7:
				xpos = (float)img.Width * (float).01;
				ypos = ((float)img.Height * (float).99) - crSize.Height;
				break;
			case 8:
				xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
				ypos = ((float)img.Height * (float).99) - crSize.Height;
				break;
			case 9:
				xpos = ((float)img.Width * (float).99) - crSize.Width;
				ypos = ((float)img.Height * (float).99) - crSize.Height;
				break;
		}

        //g.DrawString(watermarkText, drawFont, new SolidBrush(Color.LightGray), xpos + 1, ypos + 1);//文字阴影
        g.DrawString(watermarkText, drawFont, new SolidBrush(Color.FromArgb(transparency, 255, 255, 255)), xpos + 1, ypos + 1);//文字阴影				

        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
		ImageCodecInfo ici = null;
		foreach (ImageCodecInfo codec in codecs)
		{
			if (codec.MimeType.IndexOf("jpeg") > -1)
				ici = codec;
		}
		EncoderParameters encoderParams = new EncoderParameters();
		long[] qualityParam = new long[1];
		if (quality < 0 || quality > 100)
			quality = 80;

		qualityParam[0] = quality;

		EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
		encoderParams.Param[0] = encoderParam;

		if (ici != null)
			img.Save(filename, ici, encoderParams);
		else
			img.Save(filename);

		g.Dispose();
		img.Dispose();
	}

	/// <summary>
	/// 生成缩略图,指定大小
	/// </summary>
	/// <param name="originalImagePath">源图路径（物理路径）</param>
	/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
	/// <param name="width">缩略图宽度</param>
	/// <param name="height">缩略图高度</param>
	/// <param name="mode">生成缩略图的方式</param>
	protected void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ThumbnailType type)
	{
		Image originalImage = Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;                
        //修改开始
		//if (ow >= oh)
		//{
		//	type = ThumbnailType.Width;
		//}
		//else if (ow < oh)
		//{
		//	type = ThumbnailType.Height;
		//}
		//switch (type)
		//{
		//	case ThumbnailType.Width://指定宽，高按比例                    
		//		toheight = originalImage.Height * width / originalImage.Width;
		//		break;
		//	case ThumbnailType.Height://指定高，宽按比例
		//		towidth = originalImage.Width * height / originalImage.Height;
		//		break;
		//	case ThumbnailType.WidthHeightCut://指定高宽裁减（不变形）                
		//		if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
		//		{
		//			oh = originalImage.Height;
		//			ow = originalImage.Height * towidth / toheight;
		//			y = 0;
		//			x = (originalImage.Width - ow) / 2;
		//		}
		//		else
		//		{
		//			ow = originalImage.Width;
		//			oh = originalImage.Width * height / towidth;
		//			x = 0;
		//			y = (originalImage.Height - oh) / 2;
		//		}
		//		break;
		//	default:
		//		break;
		//}
        //修改结束

		//新建一个bmp图片
		Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
		//新建一个画板
		Graphics g = System.Drawing.Graphics.FromImage(bitmap);
		//设置高质量插值法
		g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
		//设置高质量,低速度呈现平滑程度
		g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		//清空画布并以透明背景色填充
		g.Clear(Color.Transparent);
		//在指定位置并且按指定大小绘制原图片的指定部分
		g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
			new Rectangle(x, y, ow, oh),
			GraphicsUnit.Pixel);
		try
		{
			//以jpg格式保存缩略图
			bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
		}
		catch (System.Exception e)
		{
			throw e;
		}
		finally
		{
			originalImage.Dispose();
			bitmap.Dispose();
			g.Dispose();
		}
	}


    /// <summary>
	/// 生成缩略图,如果原图宽度超过指定大小,高度按宽度缩放,否则原图上传
	/// </summary>
	/// <param name="originalImagePath">源图路径（物理路径）</param>
	/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
	/// <param name="width">缩略图宽度</param>
	/// <param name="height">缩略图高度</param>
	/// <param name="mode">生成缩略图的方式</param>   
    protected void MakeThumbnail_(string originalImagePath, string thumbnailPath, int width, int height, ThumbnailType type)
    {
        Image originalImage = Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        if (ow > width)
        {
            towidth = width;
            toheight = originalImage.Height * width / originalImage.Width;
            x = 0;
            y = 0;
            ow = originalImage.Width;
            oh = originalImage.Height;
        }
        else
        {
            towidth = originalImage.Width;
            toheight = originalImage.Height;
            x = 0;
            y = 0;
            ow = originalImage.Width;
            oh = originalImage.Height;
        }

        //新建一个bmp图片
        Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }


    /// <summary>
	/// 生成缩略图,高度按指定宽度缩放
	/// </summary>
	/// <param name="originalImagePath">源图路径（物理路径）</param>
	/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
	/// <param name="width">缩略图宽度</param>
	/// <param name="height">缩略图高度</param>
	/// <param name="mode">生成缩略图的方式</param>    
    protected void MakeThumbnail_o(string originalImagePath, string thumbnailPath, int width, int height, ThumbnailType type)
    {
        Image originalImage = Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = originalImage.Height * width / originalImage.Width;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;        

        //新建一个bmp图片
        Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    #region 先上传再加水印 (已注释)
    ///// <summary>
    ///// 在图片上增加文字水印
    ///// </summary>
    ///// <param name="Path">物理图片路径</param>
    ///// <param name="Path_sy">生成后带文字水印的图片路径</param>
    ///// <param name="waterText">水印文字</param>
    //protected void AddWaterText(string path, string savePath, string waterText)
    //{
    //	System.Drawing.Image image = System.Drawing.Image.FromFile(path);
    //	System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
    //	g.DrawImage(image, 0, 0, image.Width, image.Height);
    //	System.Drawing.Font f = new System.Drawing.Font("Verdana", 18);
    //	System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
    //	var x = image.Width * 0.4f;
    //	var y = image.Height * 0.5f;
    //	g.DrawString(waterText, f, b, x, y);
    //	g.Dispose();
    //	image.Save(savePath);
    //	image.Dispose();
    //}
    ///// <summary>
    ///// 在图片上生成图片水印
    ///// </summary>
    ///// <param name="Path">物理图片路径</param>
    ///// <param name="Path_syp">生成的带图片水印的图片路径</param>
    ///// <param name="Path_sypf">水印图片路径</param>
    //protected void AddWaterImage(string path, string savePath, string waterImage)
    //{
    //	System.Drawing.Image image = System.Drawing.Image.FromFile(path);
    //	System.Drawing.Image copyImage = System.Drawing.Image.FromFile(waterImage);
    //	System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
    //	g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width - 20, image.Height - copyImage.Height - 20, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
    //	g.Dispose();

    //	image.Save(savePath);
    //	image.Dispose();
    //}
    #endregion
}