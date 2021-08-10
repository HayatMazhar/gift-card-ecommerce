using Bamboo.Application.Exceptions;
using Bamboo.Application.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bamboo.Api.Middlewares
{   
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
               // var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
                var responseModel = new Response<string>() { 
                Success = false,
                Message =  error?.Message
                };
               switch (error)
                {
                    case BadRequestException ex:                    
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    
                    case ValidationException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.ValidationErrors = ex.ValdationErrors;
                        break;
                    
                    case NotFoundException ex:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case SqlException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = "Something went wrong, Please try again";
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        //responseModel.Message = "Something went wrong, Please try again";
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
