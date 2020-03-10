using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDAL
{
    public class ProcedureDAL
    {
        public ProcedureDAL() {
        }

        /// <summary>
        /// 试卷操作（新增，编辑）
        /// </summary>
        /// <param name="paperGuid">试卷主键（新增为""）</param>
        /// <param name="paperName">试卷名称</param>
        /// <param name="score">试卷分值</param>
        /// <param name="remark">试卷简介</param>
        /// <param name="questionGuids">试卷试题主键guid1,guid2...</param>
        /// <returns>操作结果</returns>
        public bool PaperOp(string paperGuid,string paperName,decimal score,string remark,string questionGuids,string examorprac) {
            try
            {
                var parameters = new SqlParameter[] {
                    new SqlParameter("@PaperGuid",SqlDbType.NVarChar,36),
                    new SqlParameter("@PaperName",SqlDbType.NVarChar,50),
                    new SqlParameter("@Score",SqlDbType.Decimal),
                    new SqlParameter("@Remark",SqlDbType.NVarChar,500),
                    new SqlParameter("@QuestionsArr",SqlDbType.NVarChar),
                    new SqlParameter("@ReturnValue", SqlDbType.Int,4)
                };
                parameters[0].Value = paperGuid;
                parameters[1].Value = paperName;
                parameters[2].Value = score;
                parameters[3].Value = remark;
                parameters[4].Value = questionGuids;
                var result = 0;
                var re = DbHelperSQL.RunProcedure(examorprac, parameters, out result);
                return re > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
