using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private string _uid;
		private string _username;
		private string _password;
		private string _wid;
		private string _wname;
		private string _wimg;
		private string _wcode;
		private string _realname;
		private int? _sex;
		private string _phone;
		private int? _state;
		private string _levelid;
		private int? _points;
		private string _remak;
		private decimal? _fund;
		private DateTime? _logintime;
		private string _loginip;
		private DateTime? _lasttime;
		private string _lastip;
		/// <summary>
		/// 
		/// </summary>
		public string uId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wId
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wName
		{
			set{ _wname=value;}
			get{return _wname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wImg
		{
			set{ _wimg=value;}
			get{return _wimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wCode
		{
			set{ _wcode=value;}
			get{return _wcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string realName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 1为男，0为女
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 1有效、0删除、-1黑名单
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string levelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? points
		{
			set{ _points=value;}
			get{return _points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remak
		{
			set{ _remak=value;}
			get{return _remak;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fund
		{
			set{ _fund=value;}
			get{return _fund;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? loginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginIp
		{
			set{ _loginip=value;}
			get{return _loginip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? lastTime
		{
			set{ _lasttime=value;}
			get{return _lasttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lastIp
		{
			set{ _lastip=value;}
			get{return _lastip;}
		}
		#endregion Model

	}
}

