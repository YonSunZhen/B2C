using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// IndexImg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IndexImg
	{
		public IndexImg()
		{}
		#region Model
		private string _id;
		private string _img;
		private string _url;
		private int? _orders;
		private int? _position;
		private int? _urltype;
		private string _toid;
		private DateTime? _updatetime;
		private string _updatepeople;
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
		public string img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 手机网页直接把要链接的地址写这里
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 按降序排序
		/// </summary>
		public int? orders
		{
			set{ _orders=value;}
			get{return _orders;}
		}
		/// <summary>
		/// 1、成功案例上面，2成功案例下面产品上面位置，3产品下面文章上面，4文章下面
		/// </summary>
		public int? position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 1为产品，2为案例，3为文章
		/// </summary>
		public int? urlType
		{
			set{ _urltype=value;}
			get{return _urltype;}
		}
		/// <summary>
		/// 对应的产品id或成功案例id，文章id
		/// </summary>
		public string toId
		{
			set{ _toid=value;}
			get{return _toid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string updatePeople
		{
			set{ _updatepeople=value;}
			get{return _updatepeople;}
		}
		#endregion Model

	}
}

