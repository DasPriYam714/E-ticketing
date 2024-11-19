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
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/post")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PostService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpGet]
        [Route("api/post/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, PostService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/post/add")]
        public HttpResponseMessage Add(PostDTO post)
        {
            try
            {
                var res = PostService.Create(post);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = post });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = post });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = post });
            }
        }

        [HttpPatch]
        [Route("api/post/update")]
        public IHttpActionResult Update([FromBody] PostDTO post)
        {
            try
            {
                var isUpdated = PostService.Update(post);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = post })
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/post/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = PostService.Delete(id);
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
