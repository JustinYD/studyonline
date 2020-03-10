using System;
namespace ExamModel
{
	/// <summary>
	/// ʵ����ExamQuestionEntity ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ExamQuestionEntity
	{
		public ExamQuestionEntity()
		{}
		#region Model
		private Guid _eqguid;
		private Guid _examguid;
		private Guid _questionguid;
		private int _eqorder;
		/// <summary>
		/// 
		/// </summary>
		public Guid EQGuid
		{
			set{ _eqguid=value;}
			get{return _eqguid;}
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
		public int EQOrder
		{
			set{ _eqorder=value;}
			get{return _eqorder;}
		}
		#endregion Model

	}
}

