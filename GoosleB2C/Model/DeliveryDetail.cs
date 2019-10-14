using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// DeliveryDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeliveryDetail
	{
		public DeliveryDetail()
		{}
		#region Model
		private string _id;
		private string _tempid;
		private int? _provinceid;
		private decimal? _firstweight;
		private decimal? _addedweight;
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
		public string tempId
		{
			set{ _tempid=value;}
			get{return _tempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? provinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? firstWeight
		{
			set{ _firstweight=value;}
			get{return _firstweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? addedWeight
		{
			set{ _addedweight=value;}
			get{return _addedweight;}
		}
		#endregion Model

	}
}

