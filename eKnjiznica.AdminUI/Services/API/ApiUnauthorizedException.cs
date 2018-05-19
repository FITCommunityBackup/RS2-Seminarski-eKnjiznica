using System;
using System.Runtime.Serialization;

namespace eKnjiznica.AdminUI.Services.API
{
    [Serializable]
    internal class ApiUnauthorizedException : Exception
    {
        public ApiUnauthorizedException()
        {
        }

        public ApiUnauthorizedException(string message) : base(message)
        {
        }

        public ApiUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}