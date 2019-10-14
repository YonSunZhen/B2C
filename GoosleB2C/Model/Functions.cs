using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// Functions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Functions
	{
		public Functions()
		{}
        #region Model
        private string _id;
        private string _functionname;
        private string _url;
        private string _father = "0";
        private int _funlevel = 1;
        private int _funorder = 1;
        private int _funtype = 1;
        private string _img1;
        private string _img2;
        private string _intro;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 菜单页面名
        /// </summary>
        public string functionName
        {
            set { _functionname = value; }
            get { return _functionname; }
        }
        /// <summary>
        /// rul地址
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 父级id：一级菜单为：0
        /// </summary>
        public string father
        {
            set { _father = value; }
            get { return _father; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int funLevel
        {
            set { _funlevel = value; }
            get { return _funlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int funOrder
        {
            set { _funorder = value; }
            get { return _funorder; }
        }
        /// <summary>
        /// 0为不显示类型【普通】；1为显示类型【普通】；2为系统管理级显示；3为系统管理级隐藏
        /// </summary>
        public int funType
        {
            set { _funtype = value; }
            get { return _funtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string img1
        {
            set { _img1 = value; }
            get { return _img1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string img2
        {
            set { _img2 = value; }
            get { return _img2; }
        }
        /// <summary>
        /// 说明用于解说页面上那些特殊功能按钮对应权限控制页面上那个扩展功能
        /// </summary>
        public string intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

