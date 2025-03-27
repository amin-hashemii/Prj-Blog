
using Prj_Blog.CoreLayer.DTOs.Users;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Services.Users
{



    public interface IUserService
    {
        //void RegisterUser(UserRegisterDto registerDto);
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(LoginUserDto loginUserDto);
    }
}
