using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// 又超级管理员管理，不给用户使用
	/// </summary>
	[Serializable]
	public partial class CompanyInfo
	{
		public CompanyInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _name2;
		private string _mainimg;
		private string _webdetails;
		private string _details;
		private string _imgs;
		private string _remarks;
		/// <summary>
		/// 1为公司简介，2为企业文化，3为联系我们，4为招聘信息，更多以后可以收到加入修改
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
		public string name2
		{
			set{ _name2=value;}
			get{return _name2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mainImg
		{
			set{ _mainimg=value;}
			get{return _mainimg;}
		}
		/// <summary>
		/// 网页版展示内容
		/// </summary>
		public string webDetails
		{
			set{ _webdetails=value;}
			get{return _webdetails;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string details
		{
			set{ _details=value;}
			get{return _details;}
		}
		/// <summary>
		/// 限制不超过30涨
		/// </summary>
		public string imgs
		{
			set{ _imgs=value;}
			get{return _imgs;}
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

