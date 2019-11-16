using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Alligator.Domain
{
    public interface IResponseModel
    {
        ResponseModel CreateResponse(HttpStatusCode status,
        string statusMessage = "Success",
           object Data = null);
        ResponseModel CreateBadRequestResponse(HttpStatusCode status,
            string statusMessagee = "Bad Request",
            object Data = null);
        ResponseModel CreateInternalServerErrorResponse(HttpStatusCode status,
            string statusMessagee = "Internal Server Error",
            object Data = null);
        ResponseModel CreateNotFoundResponse(HttpStatusCode status,
            string statusMessagee = "Empty",
            object Data = null);
        ResponseModel CreateValidationErrorResponse(HttpStatusCode status,
            string statusMessagee = "Bad Request",
            object Data = null);

        ResponseModel CreateUnauthorizeResponse(HttpStatusCode status,
            string statusMessage = "Unauthorize",
            object Data = null);
    }
}
