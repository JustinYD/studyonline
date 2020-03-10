using System;
namespace ExamModel
{
	/// <summary>
	/// ʵ����ExamUserEntity ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ExamUserEntity
	{
		public ExamUserEntity()
		{}
		#region Model
		private Guid _euguid;
		private Guid _examguid;
		private Guid _userguid;
		/// <summary>
		/// 
		/// </summary>
		public Guid EUGuid
		{
			set{ _euguid=value;}
			get{return _euguid;}
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
		public Guid UserGuid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		#endregion Model

	}
}

