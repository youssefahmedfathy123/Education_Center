using Education_Center;
using Education_Center_DbContext;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.Identity
{
    public class Identity : Iidentity
    {
        private readonly UserManager<User> _user;
        private readonly Jwt _jwt;
        private readonly ApplicationDbContext _db;
        public Identity(UserManager<User> user, Jwt jwt, ApplicationDbContext db)
        {
            _user = user;
            _jwt = jwt;
            _db = db;
        }

        public async Task<Show> Login(Login login)
        {
            //Check first
            var Find_user = await _user.FindByEmailAsync(login.Email);

            if (Find_user is null)
                return new Show { Message = "User Not Found!" };

            var check_pass = await _user.CheckPasswordAsync(Find_user, login.PassWord);
            if (!check_pass)
                return new Show { Message = "Password is wrong" };

            var roles = await _user.GetRolesAsync(Find_user);

            var token =  _jwt.GenerateToken(roles.ToList(),Find_user.UserName);

            var branch = _db.Branches.FirstOrDefault(b => b.Id == Find_user.Branch_id);


            return new Show
            {
                Token = token,
                Email = login.Email,
                Role = roles.ToList(),
                Branch_name = branch.Name,
                Position = Find_user.Role,

            };

        }



        public async Task<Show> Register(Register register)
        {
            var Find1_user = await _user.FindByEmailAsync(register.Email);
            var Find2_user = await _user.FindByNameAsync(register.UserName);


            if (Find1_user != null || Find2_user != null)
                return new Show { Message = "Login?" };

            // create new user
            var NewUser = new User
            {
                Name = register.Name,
                Email = register.Email,
                UserName = register.UserName,
                Branch_id = register.Branch_id,
                Role = register.Position,
                CreatedOn = DateTime.Now,
                IsActive = true
            };


            var creation = await _user.CreateAsync(NewUser);
            if (!creation.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in creation.Errors)
                {
                    errors += $"creation , {error.Description},";
                }
                return new Show { Message = errors };
            }

            var AddingRole =  await _user.AddToRoleAsync(NewUser, register.Position);

            if (!AddingRole.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in AddingRole.Errors)
                {
                    errors += $"Role , {error.Description},";
                }
                return new Show { Message = errors};
            }

            var pass = await _user.AddPasswordAsync(NewUser, register.Password);

            if (!pass.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in pass.Errors)
                {
                    errors += $"password , {error.Description},";
                }
                return new Show { Message = errors };
            }

            var Role = await _user.GetRolesAsync(NewUser);

            var token = _jwt.GenerateToken(Role.ToList(),register.UserName);
            
            return new Show
            {
                UserName = register.UserName,
                Email = register.Email,
                Name = register.Name,
                Role = Role.ToList(),
                Branch_id = register.Branch_id,
                Token = token,
            };

        }





    }
}



