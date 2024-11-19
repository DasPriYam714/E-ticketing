using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Ticketing.Controllers
{
    public class CommentController : ApiController
    {
        [HttpGet]
        [Route("api/comment")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CommentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpGet]
        [Route("api/comment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, CommentService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/comment/add")]
        public HttpResponseMessage Add(CommentDTO comment)
        {
            try
            {
                var res = CommentService.Create(comment);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = comment });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = comment });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = comment });
            }
        }

        [HttpPatch]
        [Route("api/comment/update")]
        public IHttpActionResult Update([FromBody] CommentDTO comment)
        {
            try
            {
                var isUpdated = CommentService.Update(comment);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = comment })
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/comment/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = CommentService.Delete(id);
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
