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
    public class RatingController : ApiController
    {
        [HttpGet]
        [Route("api/rating")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RatingServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpGet]
        [Route("api/rating/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, RatingServices.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/rating/add")]
        public HttpResponseMessage Add(RatingDTO user)
        {
            try
            {
                var res = RatingServices.Create(user);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = user });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = user });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = user });
            }
        }

        [HttpPatch]
        [Route("api/rating/update")]
        public IHttpActionResult Update([FromBody] RatingDTO user)
        {
            try
            {
                var isUpdated = RatingServices.Update(user);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = user })
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/rating/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = RatingServices.Delete(id);
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
