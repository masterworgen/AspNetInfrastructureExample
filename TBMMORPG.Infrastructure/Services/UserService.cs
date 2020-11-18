using System.Linq;
using TBMMORPG.Infrastructure.Data.Interface;
using TBMMORPG.Infrastructure.Domain;
using TBMMORPG.Infrastructure.Services.Interface;

namespace TBMMORPG.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDomain> _repository;

        public UserService(IRepository<UserDomain> repository)
        {
            _repository = repository;
        }

        public UserDomain Auth(string login, string password)
        {
            var user = _repository.Table.FirstOrDefault(domain => domain.UserName == login && domain.Password == password);

            var t = _repository.Table.ToList();

            return user;
        }

        public void Registration(string login, string password)
        {
            var user = new UserDomain
            {
                Password = password,
                UserName = login
            };
            _repository.Add(user);
        }
    }
}
