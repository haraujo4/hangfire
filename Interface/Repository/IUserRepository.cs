using FluentResults;
using hagnfireJob.Entity;
using hagnfireJob.Entity.DTO;

namespace hagnfireJob.Interface.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(Guid id);
        Task<Result> CreateUser(User user);
        Task<Result> UpdateUser(Guid id, User user);
        Task<Result> DeleteUser(Guid id);
        Task<Result> DeleteAll();
    }
}
