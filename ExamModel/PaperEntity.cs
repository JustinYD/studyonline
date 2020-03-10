using System;
namespace ExamModel
{
	/// <summary>
	/// 实体类PaperEntity 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PaperEntity
	{
		public PaperEntity()
		{}
		#region Model
		private Guid _paperguid;
		private Guid _userguid;
		private Guid _examguid;
		private Guid _questionguid;
		private int _isright;
		private decimal? _questionorder;
		private decimal? _score;
		/// <summary>
		/// 
		/// </summary>
		public Guid PaperGuid
		{
			set{ _paperguid=value;}
			get{return _paperguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid UserGuid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ExamGuid
		{
			set{ _examguid=value;}
			get{return _examguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid QuestionGuid
		{
			set{ _questionguid=value;}
			get{return _questionguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsRight
		{
			set{ _isright=value;}
			get{return _isright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? QuestionOrder
		{
			set{ _questionorder=value;}
			get{return _questionorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

