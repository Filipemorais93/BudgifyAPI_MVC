using BudifyAPI.Users.Models.DB;

namespace BudifyAPI.Users.Services
{
    public interface IUsersService
    {
        //User-groups
        Task<bool> AddUserGroup(UserGroup userGroup);
        Task<bool> UpdateUserGroup(UserGroup userGroup);
        Task<bool> DeleteUserGroup(Guid userGroupId);
        Task<UserGroup> GetUserGroup(Guid userGroupId);
        Task<bool> AddUserToUserGroup(User user);
        Task<bool> DeleteUserFromUserGroup(Guid userId, Guid userGroupId);
        Task<bool> AddManagerToUserGroup(User user);
        Task<bool> DeleteManagerToUserGroup(User user);

        //Users
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(Guid userId);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid userId);


    }
}
