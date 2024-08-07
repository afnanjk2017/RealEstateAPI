using System;
namespace RealEstateAPI.Infrastructure.Enum
{
    public enum ResponseCode
    {
        /// <summary>
        /// Defines the ServerError.
        /// </summary>
        ServerError = 0,
        /// <summary>
        /// Defines the Success.
        /// </summary>
        Success = 1,
        /// <summary>
        /// Defines the Failed.
        /// </summary>
        Failed = 2,
        /// <summary>
        /// Defines the NotFound.
        /// </summary>
        NotFound = 3,
        /// <summary>
        /// Defines the Exception.
        /// </summary>
        Exception = 4,
        /// <summary>
        /// Defines the InvalidParameter.
        /// </summary>
        InvalidParameter = 5,
        /// <summary>
        /// Defines the UnAuthorized.
        /// </summary>
        UnAuthorized = 6
    }
}
