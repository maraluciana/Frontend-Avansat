using ProjectFlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task Register(RegisterUserModel registerModel);
        Task<TokenModel> Login(LoginUserModel loginModel);
    }
}
