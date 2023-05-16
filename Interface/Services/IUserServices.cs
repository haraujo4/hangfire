using FluentResults;
using hagnfireJob.Entity;
using hagnfireJob.Entity.DTO;

namespace hagnfireJob.Interface.Services
{
    public interface IUserServices
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(Guid id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(Guid id, User user);
        Task<Result> DeleteUser(Guid id);
        Task<Result> DeleteAll();
    }
}
