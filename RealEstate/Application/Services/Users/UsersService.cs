using RealEstateAPI.Context;
using RealEstateAPI.Domain.Entities;
using RealEstateAPI.Infrastructure.DTO;
using RealEstateAPI.Infrastructure.Models;
using RealEstateAPI.Infrastructure.Pagination;
using System.Numerics;

namespace RealEstateAPI.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <param name="model"></param>
        public void CreateUser(CreateUserDTO model)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
               
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password ,
                CreationDatetime = DateTime.Now,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update an exist user
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUser(UpdateUserDTO model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == model.Id);
            if (user is not null)
            {
                user.Name = model.Name;
               
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Password = model.Password;
                user.NumOfAddedPropertys= model.NumOfAddedPropertys;
                user.Subscription_id = model.Subscription;
                user.LastEditDatetime = DateTime.Now;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Soft Delete an exist user
        /// </summary>
        /// <param name="model"></param>
        public void DeleteUser(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user is not null)
            {
                user.IsDeleted = true;
                user.DeletedDateTime = DateTime.Now;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        public UserDTO GetUserById(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                return null;
            return new UserDTO
            {
                Name = user.Name,
              
                Email = user.Email,
             
                Phone = user.Phone,
                Password = user.Password,
                Subscription= user.Subscription_id,
                NumOfAddedPropertys = user.NumOfAddedPropertys,
    };
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _context.Users;
            var data = users.Select(u => new UserDTO {
                Id = u.Id, 
                Name = u.Name,
               
                Email = u.Email ,
                Phone = u.Phone, 
                Password = u.Password,
            
                Subscription = u.Subscription_id,
                NumOfAddedPropertys = u.NumOfAddedPropertys,
            }).ToList();
            return data;
        }

        public PaginationResult<UserDTO> Search(SearchUserDTO model)
        {
            var users = _context.Users.Where(u=> (string.IsNullOrEmpty(model.Name) || u.Name == model.Name) 
                                                && (string.IsNullOrEmpty(model.Email) || u.Email == model.Email)
                                                && u.IsDeleted != true)
                .Skip((model.PageNumber - 1) * model.PageSize).Take(model.PageSize).AsEnumerable();
            var data = users.Select(u => new UserDTO { Id = u.Id, Name = u.Name, Email = u.Email }).ToList();
            return new PaginationResult<UserDTO>(data, users.Count(), model.PageNumber, model.PageSize);
        }
    }
}

