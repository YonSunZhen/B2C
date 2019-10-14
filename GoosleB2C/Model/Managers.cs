using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Managers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Managers
	{
		public Managers()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _password;
		private string _cnname;
		private int _state=1;
		private int _usertype=1;
		private string _roleid;
		private string _mobile;
		private string _creator;
		private DateTime? _cteatedate;
		private DateTime? _lastlogindate;
		private DateTime? _logindate;
		private int? _logintimes=0;
		private string _expand1;
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
		/// 用户名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 中文名
		/// </summary>
		public string cnName
		{
			set{ _cnname=value;}
			get{return _cnname;}
		}
		/// <summary>
		/// 状态：-2禁止用户；-1删除用户；0未通过用户；1正式用户
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 类型：1为普通用户；9为管理员；99为超级管理员
		/// </summary>
		public int userType
		{
			set{ _usertype=value;}
			get{return _usertype;}
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
		/// 手机
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 创建人中文名
		/// </summary>
		public string creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? cteateDate
		{
			set{ _cteatedate=value;}
			get{return _cteatedate;}
		}
		/// <summary>
		/// 上次登录时间：本次登录之前的上次登录时间，每次登录时候，把登录时间上的时间付给“上次登录时间”后更新为当前当前的系统时间
		/// </summary>
		public DateTime? lastLoginDate
		{
			set{ _lastlogindate=value;}
			get{return _lastlogindate;}
		}
		/// <summary>
		/// 登录时间
		/// </summary>
		public DateTime? loginDate
		{
			set{ _logindate=value;}
			get{return _logindate;}
		}
		/// <summary>
		/// 登录次数
		/// </summary>
		public int? loginTimes
		{
			set{ _logintimes=value;}
			get{return _logintimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string expand1
		{
			set{ _expand1=value;}
			get{return _expand1;}
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

