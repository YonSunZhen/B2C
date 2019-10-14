using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// UserLevel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserLevel
	{
		public UserLevel()
		{}
		#region Model
		private string _id;
		private string _levelname;
		private decimal? _discount;
		private int? _levelpiont;
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
		/// 
		/// </summary>
		public string levelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? levelPiont
		{
			set{ _levelpiont=value;}
			get{return _levelpiont;}
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

