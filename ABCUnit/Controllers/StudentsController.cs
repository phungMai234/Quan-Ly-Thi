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
    public class StudentsController : ApiController
    {
        StudentBLL studentBLL = new StudentBLL();


        /// <summary>
        /// Controller lấy dữ liệu toàn bộ sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <returns>Dữ liệu toàn bộ sinh viên</returns>
        [Route("students")]
        [HttpGet]
        public AjaxResult GetStudents()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = studentBLL.GetStudents();
            }
            catch(Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller lấy dữ liệu toàn bộ sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <returns>Dữ liệu toàn bộ sinh viên</returns>
        [Route("studentid")]
        [HttpPost]
        public AjaxResult GetStudentID([FromBody] Student student)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                IEnumerable<Student> student1 = studentBLL.GetStudentID(student);
                ajaxResult.Data = student1;
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu theo ID sinh vien
        /// </summary>
        /// <param name="id">Id của sinh vien cần lấy</param>
        /// <returns>Đối tượng khách hàng có id như trên</returns>
        /// Created by: vtnam 13.11.2019
        [Route("students/{id}")]
        [HttpGet]
        public AjaxResult Get(Guid id)
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = studentBLL.GetStudents().Where(p => p.StudentID == id).FirstOrDefault();
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
        /// Controller xóa 1 hoặc nhiều sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <param name="ids">Các id cần xóa</param>
        /// <returns>AjaxResult</returns>
        [Route("students")]
        [HttpDelete]
        public AjaxResult DeleteStudents([FromBody] Guid[] ids)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = studentBLL.DeleteStudents(ids);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller sửa dữ liệu sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <param name="student">dữ liệu mới của sinh viên</param>
        /// <returns>AjaxResult</returns>
        [Route("students")]
        [HttpPut]
        public AjaxResult UpdateStudent([FromBody] Student student)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = studentBLL.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller thêm mới sinh viên
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <param name="student">sinh viên cần thêm</param>
        /// <returns>AjaxResult</returns>
        [Route("students")]
        [HttpPost]
        public AjaxResult InsertStudent([FromBody] Student student)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = studentBLL.InsertStudent(student);
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
