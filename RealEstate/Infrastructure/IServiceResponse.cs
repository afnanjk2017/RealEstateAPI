using System.Net;
using RealEstateAPI.Infrastructure.Enum;

namespace RealEstateAPI.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="IServiceResponse" />.
    /// </summary>
    public interface IServiceResponse
    {
        /// <summary>
        /// Gets or sets the Success
        /// Gets or sets a value indicating whether Success...
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        object Message { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        ResponseCode Code { get; set; }

        /// <summary>
        /// Gets or sets the HttpStatusCode.
        /// </summary>
        HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        object Data { get; set; }
    }
}