using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABCUnit.Controllers
{
    public class DetailStudentSubjectController : ApiController
    {
        DetailStudentSubjectBLL detailStudentSubjectBLL = new DetailStudentSubjectBLL();
        /// <summary>
        /// Hàm thực hiện lấy tất cả dữ liệu mon hoc
        /// </summary>
        /// <returns>Danh sách mon hoc</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailSS")]
        [HttpGet]
        public AjaxResult Get()
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = detailStudentSubjectBLL.GetDetailStudentSubjects();
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
        /// Hàm thực hiện thêm mới hoc sinh trong mon hoc
        /// </summary>
        /// <param name="detail">Đối tượng cần thêm mới</param>
        /// <returns>AjaxResul để nhận thông báo lỗi</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailSS")]
        [HttpPost]
        public AjaxResult Post([FromBody]DetailStudentSubject detail)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                _ajax.Data = detailStudentSubjectBLL.InsertStudentSubject(detail);
                
            }
            catch (Exception ex)
            {

                _ajax.Success = false;
                _ajax.Message = ex.Message;
            }
            return _ajax;
        }
    }
}
