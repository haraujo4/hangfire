using FluentResults;
using hagnfireJob.Entity;
using hagnfireJob.Entity.DTO;
using hagnfireJob.Interface.Repository;
using hagnfireJob.Interface.Services;

namespace hagnfireJob.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(User user)
        {
            var create = await _userRepository.CreateUser(user);
            if(create.IsSuccess)
            {
                return user;
            }
            else
            {
                return new User();
            }
        }

        public async Task<Result> DeleteUser(Guid id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public UserDTO GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
           return _userRepository.GetUsers();
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            var usuario = new User(user.Nome, user.Email, user.Senha, user.Status);

           var update = await _userRepository.UpdateUser(id, usuario);
            if(update.IsSuccess)
            {
                return user;
            }
            else
            {
                return new User();
            }
        }

        public async Task<Result> DeleteAll()
        {
           return await _userRepository.DeleteAll();
        }
    }
}
