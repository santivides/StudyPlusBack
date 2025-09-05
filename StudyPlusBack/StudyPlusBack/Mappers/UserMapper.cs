using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Models;

namespace StudyPlusBack.Mappers
{
    public static class UserMapper
    {
        public static UserDto toUserDto(this User UserModel) 
        {
            return new UserDto
            {
                Id = UserModel.Id,
                Name = UserModel.Name,
                Email = UserModel.Email,
                Role = UserModel.Role,
                Inscriptions = UserModel.Inscriptions
            };
        }

        public static User toUserFromCreateDto(this CreateUserDto CreateUserDto)
        {
            return new User
            {
                Name = CreateUserDto.Name,
                Email = CreateUserDto.Email,
                Password = CreateUserDto.Password,
                Role = CreateUserDto.Role
            };
        }
    }
}
