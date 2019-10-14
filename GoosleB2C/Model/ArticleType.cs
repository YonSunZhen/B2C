using System;
namespace GoosleB2C.Model
{
	/// <summary>
	/// 又超级管理员管理，不给用户使用
	/// </summary>
	[Serializable]
	public partial class ArticleType
	{
		public ArticleType()
		{}
		#region Model
		private int _id;
		private string _typename;
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
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

