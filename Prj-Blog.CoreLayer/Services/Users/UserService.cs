
using Prj_Blog.CoreLayer.DTOs.Users;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Context;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Services.Users
{


    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }


        //metod haye entity freamwork 
        //any
        //add
        //savechanges
        //first
        //firstordefault
        //sing
        //singordefault

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isUserNameExists=_context.Users.Any(u=>u.UserName== registerDto.UserName);
            if (isUserNameExists)
            return OperationResult.Error("نام کاربری تکراری است");

            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDto.FullName,
                IsDeleted = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash

            });
            _context.SaveChanges();
          return OperationResult.Success();
        }

        public UserDto LoginUser(LoginUserDto loginUserDto)
        {
           var passwordhashed=loginUserDto.Password.EncodeToMd5();
            var user=_context.Users.FirstOrDefault(u=>u.UserName == loginUserDto.UserName &&u.Password==passwordhashed);

            if (user == null)
                return null;

            var userDto = new UserDto()
            {
                FullName = user.FullName,
                Password =user.Password,
                Role = user.Role,
                UserName=user.UserName,
                RegisterDate =user.CreationDate,
                User_Id = user.Id,
            };


            return userDto;
        }

    }
}
