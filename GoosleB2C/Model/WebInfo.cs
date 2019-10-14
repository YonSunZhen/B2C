using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// WebInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WebInfo
	{
		public WebInfo()
		{}
		#region Model
		private int _id;
		private string _webname;
		private string _title;
		private string _logo;
		private string _vlogo;
		private string _vname;
		private string _vcode;
		private string _records;
		private string _bottominfo;
		private string _vbottom;
		private string _seokey;
		private string _seodescribe;
		/// <summary>
		/// 默认为1就可以了
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webName
		{
			set{ _webname=value;}
			get{return _webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vLogo
		{
			set{ _vlogo=value;}
			get{return _vlogo;}
		}
		/// <summary>
		/// 填写微信平台申请下来的小程序名，用于提示用户搜索使用小程序名
		/// </summary>
		public string vName
		{
			set{ _vname=value;}
			get{return _vname;}
		}
		/// <summary>
		/// 二维码图片路径
		/// </summary>
		public string vCode
		{
			set{ _vcode=value;}
			get{return _vcode;}
		}
		/// <summary>
		/// 这个不为空的时候网页或手机端才显示【备案号：】的label ，否则需要隐藏掉。
		/// </summary>
		public string records
		{
			set{ _records=value;}
			get{return _records;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bottomInfo
		{
			set{ _bottominfo=value;}
			get{return _bottominfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vBottom
		{
			set{ _vbottom=value;}
			get{return _vbottom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoKey
		{
			set{ _seokey=value;}
			get{return _seokey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoDescribe
		{
			set{ _seodescribe=value;}
			get{return _seodescribe;}
		}
		#endregion Model

	}
}

