using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Category
	{
		public Category()
		{}
		#region Model
		private int _id;
		private string _categoryname;
		private int? _father;
		private int? _level;
		private string _path;
		private string _img;
		private int? _order;
		private string _seotitle;
		private string _seokey;
		private string _seoremark;
		private string _remark;
		private string _updater;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string categoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? father
		{
			set{ _father=value;}
			get{return _father;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? order
		{
			set{ _order=value;}
			get{return _order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
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
		public string seoRemark
		{
			set{ _seoremark=value;}
			get{return _seoremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string updater
		{
			set{ _updater=value;}
			get{return _updater;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

