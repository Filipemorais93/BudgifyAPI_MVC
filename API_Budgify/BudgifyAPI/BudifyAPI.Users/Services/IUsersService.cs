using BudifyAPI.Users.Models.USers.DBUsers;
using BudifyAPI.Users.Models.USers.DBUsers.CreateUSerHelper;
using BudifyAPI.Users.Models.USers.Helpers;

namespace BudifyAPI.Users.Services
{
    public interface IUsersService
    {
        //User-groups
        Task<bool> AddUserGroup(CreateUserGroup name);
        Task<bool> UpdateUserGroup(Guid userGroupId, CreateUserGroup name);
        Task<bool> DeleteUserGroup(Guid userGroupId);
        Task<UserGroup> GetUserGroup(Guid userGroupId);
        Task<bool> AddUserToUserGroup(User user);
        Task<bool> DeleteUserFromUserGroup(Guid userId, Guid userGroupId);
        Task<bool> AddManagerToUserGroup(User user);
        Task<bool> DeleteManagerToUserGroup(User user);

        //Users
        Task<bool> AddUser(CreateUser createUser);
        Task<bool> UpdateUser(Guid userId, CreateUser createUser);
        Task<bool> DeleteUser(Guid userId);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid userId);


    }
}
