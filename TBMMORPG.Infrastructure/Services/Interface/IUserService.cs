using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Services.Interface
{
    public interface IUserService
    {
        UserDomain Auth(string login, string password);
        void Registration(string login, string password);
    }
}
