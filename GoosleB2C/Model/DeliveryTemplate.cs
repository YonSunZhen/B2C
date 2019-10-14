using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// DeliveryTemplate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeliveryTemplate
	{
		public DeliveryTemplate()
		{}
		#region Model
		private string _id;
		private string _tempname;
		private int? _ischoose;
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
		public string tempName
		{
			set{ _tempname=value;}
			get{return _tempname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isChoose
		{
			set{ _ischoose=value;}
			get{return _ischoose;}
		}
		#endregion Model

	}
}

