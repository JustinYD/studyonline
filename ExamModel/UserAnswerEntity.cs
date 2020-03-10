using System;
namespace ExamModel
{
	/// <summary>
	/// ʵ����UserAnswerEntity ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class UserAnswerEntity
	{
		public UserAnswerEntity()
		{}
		#region Model
		private Guid _paperanswerguid;
		private Guid _paperguid;
		private Guid _userguid;
		private Guid _selectanswerguid;
		/// <summary>
		/// 
		/// </summary>
		public Guid PaperAnswerGuid
		{
			set{ _paperanswerguid=value;}
			get{return _paperanswerguid;}
		}
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
		public Guid SelectAnswerGuid
		{
			set{ _selectanswerguid=value;}
			get{return _selectanswerguid;}
		}
		#endregion Model

	}
}

