using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Handler
{
    public class NickNameHandler : AuthorizationHandler<NickNameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NickNameRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Type == "NickName"))
            {
                return Task.CompletedTask;
            }

            string nickStatus = context.User.FindFirst(u => u.Type == "NickName").Value;

            if( nickStatus == requirement.IsNickName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
