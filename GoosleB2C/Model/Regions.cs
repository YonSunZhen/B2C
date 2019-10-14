using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Regions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Regions
	{
		public Regions()
		{}
		#region Model
		private int _id;
		private string _regionname;
		private string _regioncode;
		private int? _fatherid;
		private int? _level;
		private int? _regionorder;
		private string _enname;
		private string _shortenname;
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
		public string regionName
		{
			set{ _regionname=value;}
			get{return _regionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string regionCode
		{
			set{ _regioncode=value;}
			get{return _regioncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? fatherId
		{
			set{ _fatherid=value;}
			get{return _fatherid;}
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
		public int? regionOrder
		{
			set{ _regionorder=value;}
			get{return _regionorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string enName
		{
			set{ _enname=value;}
			get{return _enname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shortEnName
		{
			set{ _shortenname=value;}
			get{return _shortenname;}
		}
		#endregion Model

	}
}

