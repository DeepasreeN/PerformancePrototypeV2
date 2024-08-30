using PerformancePrototypeV2.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.Service.Login
{
    public interface IAuthService
    {
        string Authenticate(LoginDTO loginModel);
    }
}
