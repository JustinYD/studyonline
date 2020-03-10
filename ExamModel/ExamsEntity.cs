using System;
namespace ExamModel
{
	/// <summary>
	/// ʵ����ExamsEntity ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ExamsEntity
	{
		public ExamsEntity()
		{}
		#region Model
		private Guid _examguid;
		private string _examname;
		private decimal _examscore;
		private DateTime _createtime;
		private int _status;
		private int? _actualcount;
		private decimal? _avgscore;
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
		public string ExamName
		{
			set{ _examname=value;}
			get{return _examname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ExamScore
		{
			set{ _examscore=value;}
			get{return _examscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 0����ɾ����1��������2�����
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �ο�����
		/// </summary>
		public int? ActualCount
		{
			set{ _actualcount=value;}
			get{return _actualcount;}
		}
		/// <summary>
		/// ƽ����
		/// </summary>
		public decimal? AvgScore
		{
			set{ _avgscore=value;}
			get{return _avgscore;}
		}
		#endregion Model

	}
}

