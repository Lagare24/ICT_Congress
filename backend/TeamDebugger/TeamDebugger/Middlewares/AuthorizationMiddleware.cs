//using Microsoft.AspNetCore.Authorization.Infrastructure;
//using Microsoft.AspNetCore.Authorization;
//using TeamDebugger.Data;

//namespace TeamDebugger.Middlewares
//{
//    public class AuthorizationMiddleware : AuthorizationHandler<RolesAuthorizationRequirement>
//    {
//        private readonly DataContext _dbContext;

//        public AuthorizationMiddleware(DataContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
//                                                             RolesAuthorizationRequirement requirement)
//        {
//            if (context.User == null || !context.User.Identity.IsAuthenticated)
//            {
//                context.Fail();
//                return;
//            }

//            var userId = context.User.Identity.Name;
//            if (string.IsNullOrEmpty(userId))
//            {
//                context.Fail();
//                return;
//            }

//            var user = await _dbContext.Users.SingleOrDefaultAsync(u => Convert.ToString(u.UserId) == userId);
//            if (user == null)
//            {
//                context.Fail();
//                return;
//            }

//            var allowedRole = requirement.AllowedRoles.FirstOrDefault();
//            var roleId = await _dbContext.Roles
//                                          .Where(m => m.RoleName == allowedRole)
//                                          .Select(m => m.RoleId).FirstOrDefaultAsync();

//            var userHasRole = _dbContext.UserRoles
//                                              .Where(m => m.UserId == user.UserId && m.RoleId == roleId).FirstOrDefault();

//            if (userHasRole != null)
//            {
//                context.Succeed(requirement);
//            }
//            else
//            {
//                context.Fail();
//            }
//        }
//    }
//}
