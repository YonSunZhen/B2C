using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Powers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Powers
	{
		public Powers()
		{}
		#region Model
		private string _id;
		private string _roleid;
		private string _funid;
		private int? _powervalue=0;
		private DateTime? _createdate= DateTime.Now;
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
		public string roleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string funId
		{
			set{ _funid=value;}
			get{return _funid;}
		}
		/// <summary>
		/// 权限值
		/// </summary>
		public int? powerValue
		{
			set{ _powervalue=value;}
			get{return _powervalue;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

