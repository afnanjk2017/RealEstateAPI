using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using RealEstateAPI.Infrastructure.Enum;

namespace RealEstateAPI.Infrastructure
{
    public class ServiceResponse : IServiceResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether Success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        public object Message { get; set; }
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public ResponseCode Code { get; set; }

        /// <summary>
        /// Gets or sets the HttpStatusCode.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the ResponseType.
        /// </summary>
        public string ResponseType { get; set; }
        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        public object Data { get; set; }

        

        /// <summary>
        /// The GetResponseMessage.
        /// </summary>
        /// <param name="responseCode">The responseCode<see cref="ResponseCode"/>.</param>
        /// <param name="httpCode">The httpCode<see cref="HttpStatusCode"/>.</param>
        /// <param name="data">The data<see cref="object"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <returns>The <see cref="ServiceResponse"/>.</returns>
        public static ServiceResponse GetResponseMessage(ResponseCode responseCode, HttpStatusCode httpCode, object data, object message)
        {
            ServiceResponse returnResult = new();
            returnResult.Code = responseCode;
            returnResult.HttpStatusCode = httpCode;
            returnResult.Success = ResponseCode.Success == responseCode;
            returnResult.Data = data;
            returnResult.Message = message;
            return returnResult;
        }
        /// <summary>
        /// The GetResponseMessage.
        /// </summary>
        /// <param name="responseCode">The responseCode<see cref="ResponseCode"/>.</param>
        /// <param name="httpCode">The httpCode<see cref="HttpStatusCode"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <returns>The <see cref="ServiceResponse"/>.</returns>
        public static ServiceResponse GetResponseMessage(ResponseCode responseCode, HttpStatusCode httpCode, object message)
        {
            ServiceResponse returnResult = new();
            returnResult.Code = responseCode;
            returnResult.HttpStatusCode = httpCode;
            returnResult.Success = ResponseCode.Success == responseCode;
            returnResult.Data = null;
            returnResult.Message = message;
            return returnResult;
        }
    }
}
