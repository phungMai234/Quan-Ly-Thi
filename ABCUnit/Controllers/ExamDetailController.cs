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
    public class ExamDetailController : ApiController
    {
        ExamDetailBLL examDetailBLL = new ExamDetailBLL();
        /// <summary>
        /// Hàm thực hiện lấy tất cả dữ liệu ca thi
        /// </summary>
        /// <returns>Danh sách mon hoc</returns>
        /// Created by: vtnam 13/11/2019

        [Route("examdetails")]
        [HttpGet]
        public AjaxResult Get()
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = examDetailBLL.GetExamDetails();
            }
            catch (Exception ex)
            {
                _ajax.Success = false;
                _ajax.Message = "Hệ thống lỗi con mẹ nó rồi";
                _ajax.Data = ex;
            }
            return _ajax;
        }

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu theo ID ca thi
        /// </summary>
        /// <param name="id">Id của ca thi cần lấy</param>
        /// <returns>Đối tượng ca thi có id như trên</returns>
        /// Created by: vtnam 13.11.2019
        [Route("examdetails/{id}")]
        [HttpGet]
        public AjaxResult Get(Guid id)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = examDetailBLL.GetExamDetails().Where(p => p.ExamDetailID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _ajax.Success = false;
                _ajax.Message = "Hệ thống lỗi con mẹ nó rồi";
                _ajax.Data = ex;
            }
            return _ajax;
        }

        /// <summary>
        /// Controller thêm mới sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <param name="student">sinh viên cần thêm</param>
        /// <returns>AjaxResult</returns>
        [Route("examdetails")]
        [HttpPost]
        public AjaxResult InsertExamDetail([FromBody] ExamDetail examDetail)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = examDetailBLL.InsertExamDetail(examDetail);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller xóa 1 hoặc nhiều sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <param name="ids">Các id cần xóa</param>
        /// <returns>AjaxResult</returns>
        [Route("examdetails")]
        [HttpDelete]
        public AjaxResult DeleteStudents([FromBody] Guid[] ids)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = examDetailBLL.DeleteExamDetails(ids);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }
    }
}
