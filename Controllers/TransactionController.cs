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
    public class TransactionController : ApiController
    {
        [HttpGet]
        [Route("api/transaction")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TransactionService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpGet]
        [Route("api/transaction/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, TransactionService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/transaction/add")]
        public HttpResponseMessage Add(TransactionDTO trans)
        {
            try
            {
                var res = TransactionService.Create(trans);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = trans });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = trans });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = trans });
            }
        }

        [HttpPatch]
        [Route("api/transaction/update")]
        public IHttpActionResult Update([FromBody] TransactionDTO trans)
        {
            try
            {
                var isUpdated = TransactionService.Update(trans);
                return ResponseMessage(isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = trans })
                    : Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [HttpDelete]
        [Route("api/transaction/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var isDeleted = TransactionService.Delete(id);
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
