using Microsoft.AspNetCore.Mvc;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Models;

namespace StudyPlusBack.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> getAll();
        Task<User?> GetById(int id);
        Task<User> create(User user);
        Task<User> update(int id, UpdateUserDto userDto);
        Task<User?> delete(int id);
        Task<bool> userExist(int id);

    }
}
