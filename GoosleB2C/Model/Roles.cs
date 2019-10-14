using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Roles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Roles
	{
		public Roles()
		{}
		#region Model
		private string _id;
		private string _rolename;
		private int? _roleorder=1;
		private string _intro;
		private string _createuser;
		private DateTime? _createdate= DateTime.Now;
		private string _updateuser;
		private DateTime? _updatedate;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string roleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 排序：为了显示而已
		/// </summary>
		public int? roleOrder
		{
			set{ _roleorder=value;}
			get{return _roleorder;}
		}
		/// <summary>
		/// 介绍说明
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 创建人：这里直接赋中文名子。
		/// </summary>
		public string createUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string updateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

