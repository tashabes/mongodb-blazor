using Microsoft.AspNetCore.Http;
using System.Net;

namespace BlazorMongoDB.Service

{
    public class UserIPAddressService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIPAddressService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserIPAddress()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            if (remoteIpAddress != null && remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return remoteIpAddress.ToString();
            }

            return "Unknown";
        }
    }
};