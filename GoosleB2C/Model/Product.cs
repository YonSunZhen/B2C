using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private string _pid;
		private string _title;
		private int? _orders;
		private int? _procategory;
		private string _img1;
		private string _img2;
		private string _img3;
		private string _img4;
		private string _img5;
		private decimal? _originalprice;
		private decimal? _price;
		private int? _total;
		private int? _sales;
		private string _webdetails;
		private string _details;
		private string _detailimgs;
		private int? _state;
		private string _deliverytempid;
		private string _seotitle;
		private string _seokey;
		private string _seodescribe;
		private string _creator;
		private DateTime? _createttime;
		private string _modifier;
		private DateTime? _modifydate;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string pId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 默认为0，越大排名越前，列表按排序字段倒叙排序，再按发布时间倒叙排序 即desc
		/// </summary>
		public int? orders
		{
			set{ _orders=value;}
			get{return _orders;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? proCategory
		{
			set{ _procategory=value;}
			get{return _procategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img1
		{
			set{ _img1=value;}
			get{return _img1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img2
		{
			set{ _img2=value;}
			get{return _img2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img3
		{
			set{ _img3=value;}
			get{return _img3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img4
		{
			set{ _img4=value;}
			get{return _img4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img5
		{
			set{ _img5=value;}
			get{return _img5;}
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
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 有系统触发统计颜色分类总量之和
		/// </summary>
		public int? total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sales
		{
			set{ _sales=value;}
			get{return _sales;}
		}
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public string detailImgs
		{
			set{ _detailimgs=value;}
			get{return _detailimgs;}
		}
		/// <summary>
		/// 1为上架正常销售，0为下架，-1删除放回收站中
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deliveryTempId
		{
			set{ _deliverytempid=value;}
			get{return _deliverytempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoKey
		{
			set{ _seokey=value;}
			get{return _seokey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seoDescribe
		{
			set{ _seodescribe=value;}
			get{return _seodescribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createTtime
		{
			set{ _createttime=value;}
			get{return _createttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string modifier
		{
			set{ _modifier=value;}
			get{return _modifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? modifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
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

