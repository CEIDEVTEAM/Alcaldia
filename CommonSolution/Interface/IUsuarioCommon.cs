using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommonSolution.Interface
{
    public interface IUsuarioCommon
    {
        JsonResult ValidateUserName(string userName);
        JsonResult ValidatePasswordNewUser(string pass, string repPass);
        JsonResult ValidateNewPassword(string newPass, string repNewPass);
    }
}
