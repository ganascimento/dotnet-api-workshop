using Api.Service.Helpers.interfaces;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Helpers
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context;
        }
        
        public int GetAuthId()
        {
            return int.Parse(_context.HttpContext.User.FindFirst(ClaimsConstant.USER_ID).Value);
        }

        public int GetWorkshopId()
        {
            return int.Parse(_context.HttpContext.User.FindFirst(ClaimsConstant.WORKSHOP_ID).Value);
        }
    }
}