using System;
using System.Data;
using System.Collections.Generic;
using ExamModel;
using ExamDAL;

namespace ExamBLL
{
	/// <summary>
	/// ҵ���߼���ExamQuestionBLL ��ժҪ˵����
	/// </summary>
	public class ExamQuestionBLL
	{
        private readonly ExamQuestionDAL dal = new ExamQuestionDAL();
		public ExamQuestionBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Guid EQGuid)///bool����
		{
			return dal.Exists(EQGuid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ExamQuestionEntity model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ExamQuestionEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Guid EQGuid)
		{
			
			dal.Delete(EQGuid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ExamQuestionEntity GetModel(Guid EQGuid)
		{
			
			return dal.GetModel(EQGuid);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ExamQuestionEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ExamQuestionEntity> DataTableToList(DataTable dt)
		{
			List<ExamQuestionEntity> modelList = new List<ExamQuestionEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ExamQuestionEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ExamQuestionEntity();
					if(dt.Rows[n]["EQGuid"].ToString()!="")
					{
						model.EQGuid=new Guid(dt.Rows[n]["EQGuid"].ToString());
					}
					if(dt.Rows[n]["ExamGuid"].ToString()!="")
					{
						model.ExamGuid=new Guid(dt.Rows[n]["ExamGuid"].ToString());
					}
					if(dt.Rows[n]["QuestionGuid"].ToString()!="")
					{
						model.QuestionGuid=new Guid(dt.Rows[n]["QuestionGuid"].ToString());
					}
					if(dt.Rows[n]["EQOrder"].ToString()!="")
					{
						model.EQOrder=int.Parse(dt.Rows[n]["EQOrder"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

