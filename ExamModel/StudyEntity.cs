using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamModel
{
	/// <summary>
	/// 实体类StudyEntity 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StudyEntity
	{
		public StudyEntity(){}
		private string _title;
		private string _fileurl;
		private string _time;
		public string title
		{
			set { _title = value; }
			get { return _title; }
		}
		public string fileurl
		{
			set { _fileurl = value; }
			get { return _fileurl; }
		}
		public string time
		{
			set { _time = value; }
			get { return _time; }
		}

	}
}
