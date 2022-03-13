using FeriaVirtual.API.Models.Users;
using FeriaVirtual.Database.Entities;
using FeriaVirtual.Database;
using System.Text;
using System.Security.Cryptography;
using FeriaVirtual.API.Helpers;
using FeriaVirtual.API.Authorization;
using AutoMapper;

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
        private readonly FeriaVirtualContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        public UserService(FeriaVirtualContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            string hashedPass = SecurePaswordHasher.ComputeHash(model.Password);
            if (user == null || hashedPass != user.Password)
            {
                throw new AppException("Username or password is incorrect");
            }

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
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
            return GetUser(id);
        }

        public void Register(RegisterRequest model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
                throw new AppException($"Email {model.Email} is already taken");
            var user = _mapper.Map<User>(model);

            user.Password = SecurePaswordHasher.ComputeHash(model.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(UpdateRequest model)
        {
            throw new NotImplementedException();
        }

        private User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

    }
}
