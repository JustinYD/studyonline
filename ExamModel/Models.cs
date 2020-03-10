﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamModel
{
    public class PaperModel {
        public string PaperGuid { get; set; }
        public string PaperName { get; set; }
        public double Score { get; set; }
        public string Remark { get; set; }
        public string CreateTime { get; set; }
        public int Status { get; set; }

        public int IsAnswered { get; set; }

        public double UserScore { get; set; }
    }
    

    public class PaperQuestionModel : PaperModel {
      public List<QuestionModel> QuestionList { get; set; }

    }

    public class QuestionModel : QuestionsEntity {
        public List<AnswersEntity> AnswerItem { get; set; }
        public List<string> RightAnswerGuid { get; set; }
        public List<string> SelectAnswerGuid { get; set; }
        public int IsRight { get; set; }
        public string Video { get; set; }
    }

    public class ExamModel : ExamsEntity {
        public int ExamId { get; set; }
        public string AddTime { get; set; }
        public string PaperGuid { get; set; }
        public string PaperName { get; set; }
        public List<UsersEntity> UserList { get; set; }
        /// <summary>
        /// 是否作答过
        /// </summary>
        public int IsAnswered { get; set; }
        /// <summary>
        /// 用户得分
        /// </summary>
        public double UserScore { get; set; }

        public string UserName { get; set; }

        public string UserGuid { get; set; }
        
    }

    public class UserPaperInfoModel {
        public Guid ExamGuid { get; set; }
        public string UserGuid { get; set; }
        public string PaperGuid { get; set; }
        public List<UserQuestionModel> Questions { get; set; }

    }

    public class UserQuestionModel {
        public Guid QuestionGuid { get; set; }
        public List<string> RightAnswerGuid { get; set; }
        public List<string> SelectAnswerGuid { get; set; }
        public int IsRight { get; set; }
        public string CreateTime { get; set; }

    }

    public class UserModel : ExamUserEntity {
        public double Score { get; set; }
    }
}