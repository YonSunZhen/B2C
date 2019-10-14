using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// WaterMark:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WaterMark
	{
		public WaterMark()
		{}
		#region Model
		private int _id;
		private int? _state;
		private int? _watertype;
		private int? _position;
		private string _words;
		private string _img;
		private int? _transparent;
		/// <summary>
		/// 默认为1
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 1为启用，0为不启用
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 1为文字水印，2为图片水印
		/// </summary>
		public int? waterType
		{
			set{ _watertype=value;}
			get{return _watertype;}
		}
		/// <summary>
		/// 参考小键盘：1 为左下，2为下中，3为右下，4为左中，5为中间，6为右中，7为左上，8为上中，9为右上
		/// </summary>
		public int? position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string words
		{
			set{ _words=value;}
			get{return _words;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 1-100的透明度
		/// </summary>
		public int? transparent
		{
			set{ _transparent=value;}
			get{return _transparent;}
		}
		#endregion Model

	}
}

