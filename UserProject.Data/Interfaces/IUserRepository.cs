using UserProject.Core.Entities;

namespace UserProject.Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool IsUsernameUniq(string username);
        bool isEmailUniq(string email);
    }
}
