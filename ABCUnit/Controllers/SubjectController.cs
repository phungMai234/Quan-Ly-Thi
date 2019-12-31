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
    public class SubjectController : ApiController
    {
        SubjectBLL subjectBLL = new SubjectBLL();

        /// <summary>
        /// Hàm thực hiện lấy tất cả dữ liệu mon hoc
        /// </summary>
        /// <returns>Danh sách mon hoc</returns>
        /// Created by: vtnam 13/11/2019

        [Route("subjects")]
        [HttpGet]
        public AjaxResult Get()
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = subjectBLL.GetSubjects();
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
        /// Hàm thực hiện lấy dữ liệu theo ID mon hoc
        /// </summary>
        /// <param name="id">Id của sinh vien cần lấy</param>
        /// <returns>Đối tượng mon hoc có id như trên</returns>
        /// Created by: vtnam 13.11.2019
        [Route("subjects/{id}")]
        [HttpGet]
        public AjaxResult Get(Guid id)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = subjectBLL.GetSubjects().Where(p => p.SubjectID == id).FirstOrDefault();
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
        /// Hàm thực hiện thêm mới mon hoc
        /// </summary>
        /// <param name="_subject">Đối tượng mon hoc cần thêm mới</param>
        /// <returns>AjaxResul để nhận thông báo lỗi</returns>
        /// Created by: vtnam 13/11/2019

        [Route("subjects")]
        [HttpPost]
        public AjaxResult Post([FromBody]Subject _subject)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                subjectBLL.InsertSubject(_subject);
                _ajax.Data = _subject;
            }
            catch (Exception ex)
            {
                
                _ajax.Success = false;
                _ajax.Message = ex.Message;
            }
            return _ajax;
        }

        // <summary>
        /// Hàm thực hiện sua mới mon hoc
        /// </summary>
        /// <param name="_subject">Đối tượng mon hoc cần thêm mới</param>
        /// <returns>AjaxResul để nhận thông báo lỗi</returns>
        /// Created by: vtnam 13/11/2019

        [Route("subjects")]
        [HttpPut]
        public AjaxResult Put([FromBody]Subject _subject)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                subjectBLL.UpdateSubject(_subject);
                _ajax.Data = _subject;
            }
            catch (Exception ex)
            {

                _ajax.Success = false;
                _ajax.Message = ex.Message;
            }
            return _ajax;
        }

        /// <summary>
        /// Ham thuc hien xoa mot mon hoc
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        [Route("subjects")]
        [HttpDelete]
        public AjaxResult Delete([FromBody] Guid[] ids)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = subjectBLL.DeleteSubjects(ids);
                
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
