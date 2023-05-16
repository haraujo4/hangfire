using Dapper;
using FluentResults;
using hagnfireJob.Entity;
using hagnfireJob.Entity.DTO;
using hagnfireJob.Interface.Repository;
using System.Data;

namespace hagnfireJob.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Result> CreateUser(User user)
        {
            var query = @"INSERT INTO USUARIO(ID, NOME, EMAIL, SENHA, STATUS)
                        VALUES(@UserID, @Nome, @Email, @Senha, @Status)";
            try
            {
                await _connection.ExecuteAsync(query, user);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result> DeleteUser(Guid id)
        {
            var query = @"DELETE FROM USUARIO WHERE ID = @id";
            try
            {
                await _connection.ExecuteAsync(query, id);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public UserDTO GetUserById(Guid id)
        {
            var query = $@"SELECT ID UserID, NOME Nome, EMAIL Email, SENHA Senha, STATUS Status FROM USUARIO WHERE ID = '{id}'";

            try
            {
                var result = _connection.Query<UserDTO>(query).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {
                return new UserDTO();
            }
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var query = $@"SELECT ID UserID, NOME Nome, EMAIL Email, SENHA Senha, STATUS Status FROM USUARIO";
            try
            {
                var result = _connection.Query<UserDTO>(query);
                return result;
            }
            catch(Exception ex)
            {
                return new List<UserDTO>();
            }
        }

        public async Task<Result> UpdateUser(Guid id, User user)
        {
            var query = @"UPDATE USUARIO SET
                            NOME = @nome,
                            EMAIL = @email,
                            SENHA = @senha,
                            STATUS = @status
                        WHERE ID = @id";
            try
            {
                await _connection.ExecuteAsync(query, new {id, user });
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result> DeleteAll()
        {
            var query = $@"DELETE FROM USUARIO";
            try
            {
                await _connection.ExecuteAsync(query);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
