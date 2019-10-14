using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductType
	{
		public ProductType()
		{}
		#region Model
		private string _id;
		private string _productid;
		private string _typename;
		private decimal? _originalprice;
		private decimal? _price;
		private int? _stock;
		private string _img;
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
		public string productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? originalPrice
		{
			set{ _originalprice=value;}
			get{return _originalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img
		{
			set{ _img=value;}
			get{return _img;}
		}
		#endregion Model

	}
}

