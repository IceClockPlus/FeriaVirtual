using FeriaVirtual.API.Models.Users;
using FeriaVirtual.Database.Entities;

namespace FeriaVirtual.API.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        void Update(UpdateRequest model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterRequest model)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
