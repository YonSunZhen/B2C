using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Article
	{
		public Article()
		{}
        #region Model
        private string _id;
        private int? _type;
        private int? _state;
        private string _title;
        private int? _orders;
        private string _webcontent;
        private string _content;
        private string _imgs;
        private int? _readcount;
        private string _remark;
        private string _creator;
        private DateTime? _createtime;
        private string _modifier;
        private DateTime? _modifydate;
        private string _seotitle;
        private string _seokey;
        private string _seodescribe;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 1为公司新闻，2为行业资讯,具体文章类型那边编辑
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 0为草稿、1为已经发布
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 默认为0，越大排名越前，列表按排序字段倒叙排序，再按发布时间倒叙排序 即desc
        /// </summary>
        public int? orders
        {
            set { _orders = value; }
            get { return _orders; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string webContent
        {
            set { _webcontent = value; }
            get { return _webcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgs
        {
            set { _imgs = value; }
            get { return _imgs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? readCount
        {
            set { _readcount = value; }
            get { return _readcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modifier
        {
            set { _modifier = value; }
            get { return _modifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? modifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string seoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string seoKey
        {
            set { _seokey = value; }
            get { return _seokey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string seoDescribe
        {
            set { _seodescribe = value; }
            get { return _seodescribe; }
        }
        #endregion Model


    }
}

