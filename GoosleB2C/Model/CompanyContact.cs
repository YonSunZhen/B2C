using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// CompanyContact:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CompanyContact
	{
		public CompanyContact()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _address;
		private string _telephone;
		private string _phone;
		private string _email;
		private string _contacts;
		private string _weixin;
		/// <summary>
		/// 弄个1就行了，反正读取第一行数据
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
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
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contacts
		{
			set{ _contacts=value;}
			get{return _contacts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		#endregion Model

	}
}

