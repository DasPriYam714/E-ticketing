using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Ticketing.Controllers
{
   
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, AdminService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/admin/add")]
        public HttpResponseMessage Add(AdminDTO admin)
        {
            try
            {
                var res = AdminService.Create(admin);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = admin });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = admin });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = admin });
            }
        }

        [HttpPatch]
        [Route("api/admin/update")]
        public IHttpActionResult Update([FromBody] AdminDTO admin)
        {
            try
            {
                var isUpdated = AdminService.Update(admin);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = admin })
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/admin/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = AdminService.Delete(id);
                return ResponseMessage(isDeleted
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}
