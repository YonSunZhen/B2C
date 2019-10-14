using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// 又超级管理员管理，不给用户使用
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
        #region Model
        private string _id;
        private string _vid;
        private string _to;
        private string _name;
        private int? _sex;
        private string _phone;
        private string _weixin;
        private string _content;
        private DateTime? _createtime;
        private string _ip;
        private int? _isshow;
        private int? _isread;
        private DateTime? _readtime;
        private int? _isanswer;
        /// <summary>
        /// 
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 小程序读到登录微信号
        /// </summary>
        public string vId
        {
            set { _vid = value; }
            get { return _vid; }
        }
        /// <summary>
        /// 用户留言为0，管理员回复为被回复人的vid，没有vid的不能回复
        /// </summary>
        public string to
        {
            set { _to = value; }
            get { return _to; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 1为先生，2为女士
        /// </summary>
        public int? sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 手动填的微信
        /// </summary>
        public string weixin
        {
            set { _weixin = value; }
            get { return _weixin; }
        }
        /// <summary>
        /// 界面保存需要提高超过1000文字不能保存
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
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
        public string ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 1为展示，0为不展示，默认都为零
        /// </summary>
        public int? isShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        /// <summary>
        /// 1为已阅，0为未阅
        /// </summary>
        public int? isRead
        {
            set { _isread = value; }
            get { return _isread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? readTime
        {
            set { _readtime = value; }
            get { return _readtime; }
        }
        /// <summary>
        /// 1为已回复，0为未回复，默认为0
        /// </summary>
        public int? isAnswer
        {
            set { _isanswer = value; }
            get { return _isanswer; }
        }
        #endregion Model



    }
}

