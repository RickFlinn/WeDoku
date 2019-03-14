using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Handler
{
    public class NickNameRequirement : IAuthorizationRequirement
    {

        public string IsNickName { get; set; }


        /// <summary>
        /// Nick Name Requirement Constructor
        /// </summary>
        /// <param name="isNickName">status of user having a nickname</param>
        public NickNameRequirement(string isNickName)
        {
            IsNickName = isNickName;
        }
    }
}
