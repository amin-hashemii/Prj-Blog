using System;
using System.Linq;
using CodeYad_Blog.CoreLayer.DTOs.Users;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;

namespace CodeYad_Blog.CoreLayer.Services.Users
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
            var isFullNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);
            if (isFullNameExist)
                return OperationResult.Error("نام کاربری تکراری است");

            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDto.Fullname,
                IsDelete = false,
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