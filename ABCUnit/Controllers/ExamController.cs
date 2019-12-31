using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABCUnit.Controllers
{
    public class ExamController : ApiController
    {
        ExamBLL examBLL = new ExamBLL();
        /// <summary>
        /// Controller lấy dữ liệu toàn bộ ky thi
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <returns>Dữ liệu toàn bộ sinh viên</returns>
        [Route("exams")]
        [HttpGet]
        public AjaxResult GetExams()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = examBLL.GetExams();
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller thêm mới kì thi
        /// Created by ncphuoc 15/12/2019
        /// </summary>
        /// <param name="exam">Đối tượng kì thi cần thêm</param>
        /// <returns></returns>
        [Route("exams")]
        [HttpPost]
        public AjaxResult InsertExam([FromBody]Exam exam)
        {
            var ajaxResult = new AjaxResult();

            try
            {
                //ajaxResult.Data = examBLL.InsertExam(exam);
                ajaxResult.Data = exam;
            }
            catch(Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }
    }
}
