using System.Net;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Exceptions;


namespace NDDTraining.API.Configs
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await ExceptionTreatment(httpContext, ex);
            }
        }
        private Task ExceptionTreatment(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case NoDataException:
                case EmailErrorException:
                    status = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                case DuplicateException:
                    status = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;               
                case (BadRequestException):
                    status = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case (AlreadyExistsException):
                    status = HttpStatusCode.Conflict;
                    message = exception.Message;
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An internal error ocurred. Please contact IT";
                    break;
            }

            ErrorDTO response = new(message);
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }

}
