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
    public class DetailStudentExamDetailController : ApiController
    {
        DetailStudentExamDetailBLL detailSED = new DetailStudentExamDetailBLL();
        /// <summary>
        /// Hàm thực hiện lấy tất cả dữ liệu sinh vien da dang ky
        /// </summary>
        /// <returns>Danh sách mon hoc</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailSED")]
        [HttpGet]
        public AjaxResult Get()
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = detailSED.GetDetailStudentExamDetails();
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
        /// Hàm thực hiện lấy dữ liệu theo ID sinh vien
        /// </summary>
        /// <param name="id">Thong tin sinh vien da dang ky can a=lay</param>
        /// <returns></returns>
        /// Created by: vtnam 13.11.2019
        [Route("detailSED/{id}")]
        [HttpGet]
        public AjaxResult Get(Guid id)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = detailSED.GetDetailStudentExamDetails().Where(p => p.StudentID == id);
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
        /// Hàm thực hiện them moi sinh vien vao phong thi
        /// </summary>
        /// <param name="detail">Đối tượng mon hoc cần thêm mới</param>
        /// <returns>AjaxResul để nhận thông báo lỗi</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailSED")]
        [HttpPost]
        public AjaxResult Post([FromBody]DetailStudentExamDetail detail)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                detailSED.InserDetailSED(detail);
                _ajax.Data = detail;
            }
            catch (Exception ex)
            {

                _ajax.Success = false;
                _ajax.Message = ex.Message;
            }
            return _ajax;
        }

        [Route("detailSED")]
        [HttpDelete]
        public AjaxResult Delete([FromBody]DetailStudentExamDetail detail)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                detailSED.DeleteDetailSED(detail);
                _ajax.Data = detail;
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
