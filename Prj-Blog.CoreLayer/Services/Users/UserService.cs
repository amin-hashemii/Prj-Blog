
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
        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isFullNameExists=_context.Users.Any(u=>u.UserName== registerDto.UserName);
            if (isFullNameExists)
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

       
    }
}
