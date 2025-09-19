using Microsoft.EntityFrameworkCore;
using StudyPlusBack.Dtos.Users;
using StudyPlusBack.Interfaces;
using StudyPlusBack.Models;

namespace StudyPlusBack.Repositories
{
    public class UserRepository : IUserRepository  
    {
        private readonly StudyPlusContext _context;

        public UserRepository(StudyPlusContext context) 
        {
            _context = context;
        }

        public async Task<List<User>> getAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> update(int id, UpdateUserDto userDto)
        {
            var userModel = await _context.Users.FindAsync(id);

            if(userModel == null) 
            {
                return null;
            }

            userModel.Name = userDto.Name;
            userModel.Email = userDto.Email;
            userModel.Password = userDto.Password;
            userModel.Role = userDto.Role;

            await _context.SaveChangesAsync();

            return userModel;   
        }

        public async Task<User?> delete(int id)
        {
            var userModel = await _context.Users.FindAsync(id);

            if (userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }
    }
}
