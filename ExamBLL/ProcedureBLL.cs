﻿using ExamDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBLL
{
    public class ProcedureBLL
    {
        public ProcedureBLL() { }
        public ProcedureDAL dal = new ProcedureDAL();
        /// <summary>
        /// 试卷操作（新增，编辑）
        /// </summary>
        /// <param name="paperGuid">试卷主键（新增为""）</param>
        /// <param name="paperName">试卷名称</param>
        /// <param name="score">试卷分值</param>
        /// <param name="remark">试卷简介</param>
        /// <param name="questionGuids">试卷试题主键guid1,guid2...</param>
        /// <returns>操作结果</returns>
        public bool PaperOp(string paperGuid, string paperName, decimal score, string remark, string questionGuids)
        {
            return dal.PaperOp(paperGuid, paperName, score, remark, questionGuids, "SP_PaperOp");
        }
        public bool PracticePaperOp(string paperGuid, string paperName, decimal score, string remark, string questionGuids)
        {
            return dal.PaperOp(paperGuid, paperName, score, remark, questionGuids, "SP_PracticePaperOp");
        }
    }
}
