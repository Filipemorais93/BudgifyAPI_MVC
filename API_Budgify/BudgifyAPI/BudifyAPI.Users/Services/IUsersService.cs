using BudifyAPI.Users.Models.DB;

namespace BudifyAPI.Users.Services
{
    public interface IUsersService
    {
        //User-groups
        Task<bool> AddUserGroup(UserGroup userGroup);
        Task<bool> UpdateUserGroup(UserGroup userGroup);
        Task<bool> DeleteUserGroup(UserGroup userGroup);
        Task<List<UserGroup>> GetAllUserGroup(Guid userGroupId);
        Task<bool> AddUserToUserGroup(User user, UserGroup userGroup);
        Task<bool> DeleteUserFromUserGroup(User user, UserGroup userGroup);
        Task<bool> AddManagerToUserGroup(User user, UserGroup userGroup);
        Task<bool> DeleteManagerToUserGroup(User user, UserGroup userGroup);

        //Users
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User userId);
        Task<bool> DeleteUser(Guid userId);
        Task<List<User>> GetUsers(User user);
        Task<User> GetUserById(Guid userId);


    }
}
