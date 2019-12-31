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
    public class DetailExamDetailExRoomController : ApiController
    {
        DetailExamDetailExRoomBLL detailEDED = new DetailExamDetailExRoomBLL();

        /// <summary>
        /// Hàm thực hiện lấy tất cả dữ liệu mon hoc
        /// </summary>
        /// <returns>Danh sách mon hoc</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailEDEDs")]
        [HttpGet]
        public AjaxResult Get()
        {
            var _ajax = new AjaxResult();
            try
            {
                _ajax.Data = detailEDED.GetDetailExamDetailExRoom();
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
        /// Hàm thực hiện thêm mới phong thi cho ca thi
        /// </summary>
        /// <param name="_subject">Đối tượng cần thêm mới</param>
        /// <returns>AjaxResul để nhận thông báo lỗi</returns>
        /// Created by: vtnam 13/11/2019

        [Route("detailEDEDs")]
        [HttpPost]
        public AjaxResult Post([FromBody]DetailExamDetailExRoom[] _details)
        {
            var _ajax = new AjaxResult();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                detailEDED.InsertDetailExamDetailExRoom(_details);
                _ajax.Data = _details;
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
