using Domain;
using System.Collections.Generic;
using AutoMapper;
using Repository;

namespace Service.Impl
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public User RegisterUser(User user)
        {
            return _userRepository.Insert(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}