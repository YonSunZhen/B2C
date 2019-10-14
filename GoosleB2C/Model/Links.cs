using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Links:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Links
	{
		public Links()
		{}
		#region Model
		private string _id;
		private string _linkname;
		private string _url;
		private int? _orders;
		private string _tags;
		private int? _state;
		private DateTime? _createdate;
		private string _creator;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 默认为0，越大排名越前，列表按排序字段倒叙排序，再按发布时间倒叙排序 即desc
		/// </summary>
		public int? orders
		{
			set{ _orders=value;}
			get{return _orders;}
		}
		/// <summary>
		/// 鼠标移上去提示文字
		/// </summary>
		public string tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		/// <summary>
		/// 0不显示，1显示
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

