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
    public class ClassController : ApiController
    {
        ClassBLL classBLL = new ClassBLL();
        /// <summary>
        /// Controller lấy dữ liệu toàn bộ lop hoc
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <returns>Dữ liệu toàn bộ sinh viên</returns>
        [Route("classes")]
        [HttpGet]
        public AjaxResult GetClasses()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = classBLL.GetClasses();
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu theo ID lop hoc
        /// </summary>
        /// <param name="id">Id của lop hoc cần lấy</param>
        /// <returns>Đối tượng lop hoc có id như trên</returns>
        /// Created by: vtnam 13.11.2019
        [Route("classes/{id}")]
        [HttpGet]
        public AjaxResult Get(Guid id)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = classBLL.GetClasses().Where(p => p.ClassID == id).FirstOrDefault();
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
        /// Controller xóa 1 hoặc nhiều lop hoc
        /// Created by vtnam 14/12/2019
        /// </summary>
        /// <param name="ids">Các id cần xóa</param>
        /// <returns>AjaxResult</returns>
        [Route("classes")]
        [HttpDelete]
        public AjaxResult DeleteClass([FromBody] Guid[] ids)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = classBLL.DeleteClasses(ids);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller sửa dữ liệu lop hoc
        /// Created by ncphuoc 14/12/2019
        /// </summary>
        /// <param name="classes">dữ liệu mới của lop hoc</param>
        /// <returns>AjaxResult</returns>
        [Route("classes")]
        [HttpPut]
        public AjaxResult UpdateClass([FromBody] Class classes)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = classBLL.UpdateClasses(classes);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller thêm mới lop hoc
        /// Created by vtnam 14/12/2019
        /// </summary>
        /// <param name="student">sinh viên cần thêm</param>
        /// <returns>AjaxResult</returns>
        [Route("classes")]
        [HttpPost]
        public AjaxResult InsertClass([FromBody] Class classes)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = classBLL.InsertClasses(classes);
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
