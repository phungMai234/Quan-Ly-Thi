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
    public class ExRoomController : ApiController
    {
        ExRoomBLL exRoomBLL = new ExRoomBLL();
        /// <summary>
        /// Controller lấy dữ liệu toàn bộ phong hoc
        /// Created by ncphuoc 13/12/2019
        /// </summary>
        /// <returns>Dữ liệu toàn bộ sinh viên</returns>
        [Route("exrooms")]
        [HttpGet]
        public AjaxResult GetExRooms()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = exRoomBLL.GetExRooms();
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu phòng thi theo id
        /// Created by ncphuoc 16/12/2019
        /// </summary>
        /// <param name="id">id của phòng thi cần lấy</param>
        /// <returns>Ajax Result</returns>
        [Route("exrooms/{id}")]
        [HttpGet]
        public AjaxResult GetExRoomById(Guid id)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = exRoomBLL.GetExRoomById(id);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller thêm mới phòng thi
        /// Created by ncphuoc 16/12/2019
        /// </summary>
        /// <param name="exRoom">Phòng thi cần thêm</param>
        /// <returns>Ajax Result</returns>
        [Route("exrooms")]
        [HttpPost]
        public AjaxResult InsertExRoom( [FromBody] ExRoom exRoom)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = exRoomBLL.InsertExRoom(exRoom);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller sửa phòng thi
        /// Created by ncphuoc 16/12/2019
        /// </summary>
        /// <param name="exRoom">Phòng thi cần sửa</param>
        /// <returns>Ajax Result</returns>
        [Route("exrooms")]
        [HttpPut]
        public AjaxResult UpdateExRoom([FromBody] ExRoom exRoom)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = exRoomBLL.UpdateRoom(exRoom);
            }
            catch (Exception ex)
            {
                ajaxResult.Success = false;
                ajaxResult.Message = ex.Message;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Controller xóa phòng thi
        /// Created by ncphuoc 16/12/2019
        /// </summary>
        /// <param name="ids">id của phòng cần xóa</param>
        /// <returns>Ajax Result</returns>
        [Route("exrooms")]
        [HttpDelete]
        public AjaxResult DeleteExRooms([FromBody] Guid[] ids)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = exRoomBLL.DeleteExRooms(ids);
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
