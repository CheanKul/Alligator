using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Alligator.Domain
{
    public class ResponseModel : IResponseModel
    {

        public HttpStatusCode Status { get; set; }
        public string StatusMessage { get; set; }
        public object Data { get; set; }


        public ResponseModel CreateBadRequestResponse(HttpStatusCode status = HttpStatusCode.BadRequest,
            string statusMessage = "Bad Request",
            object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }

        public ResponseModel CreateInternalServerErrorResponse(HttpStatusCode status = HttpStatusCode.InternalServerError,
            string statusMessage = "Internal Server Error",
            object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }

        public ResponseModel CreateNotFoundResponse(HttpStatusCode status = HttpStatusCode.NotFound,
            string statusMessage = "Empty",
            object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }

        public ResponseModel CreateValidationErrorResponse(HttpStatusCode status,
            string statusMessage = "Bad Request",
            object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }

        public ResponseModel CreateResponse(HttpStatusCode status,
            string statusMessage = "Success",
            object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }

        public ResponseModel CreateUnauthorizeResponse(HttpStatusCode status, string statusMessage = "Unauthorize", object Data = null)
        {
            return new ResponseModel()
            {
                Status = status,
                StatusMessage = statusMessage,
                Data = Data
            };
        }
    }
}
