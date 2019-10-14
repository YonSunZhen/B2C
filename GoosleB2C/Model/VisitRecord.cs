using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// VisitRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VisitRecord
	{
		public VisitRecord()
		{}
		#region Model
		private string _id;
		private string _vid;
		private string _ip;
		private string _url;
		private DateTime? _visittime;
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
		public string vId
		{
			set{ _vid=value;}
			get{return _vid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
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
		/// 
		/// </summary>
		public DateTime? visitTime
		{
			set{ _visittime=value;}
			get{return _visittime;}
		}
		#endregion Model

	}
}

