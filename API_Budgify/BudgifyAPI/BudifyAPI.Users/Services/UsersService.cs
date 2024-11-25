using BudifyAPI.Users.Models.DB;
using Microsoft.EntityFrameworkCore;
using BudifyAPI.Users.Models;
using Npgsql;

namespace BudifyAPI.Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly UsersContext _contextUsers;
        public UsersService(UsersContext contextUsers)
        {
            _contextUsers = contextUsers;
        }

        /// <summary>
        /// Criar grupo de utilizadores
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> AddUserGroup(UserGroup userGroup)
        {
            await _contextUsers.UserGroups.AddAsync(userGroup);
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Editar grupo de utilizadores
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserGroup(UserGroup userGroup)
        {
            _contextUsers.UserGroups.Update(userGroup);
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Apagar grupo de utilizadores
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserGroup(UserGroup userGroup)
        {
            _contextUsers.UserGroups.Remove(userGroup);
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obter grupo de utilizadores através do ID do grupo
        /// </summary>
        /// <param name="userGroupId"></param>
        /// <returns></returns>
        public async Task<List<UserGroup>> GetAllUserGroup(Guid userGroupId)
        {
            //Verficiar se o Id existe
            string query = $"select * from public.user_group where id_user_group ='{userGroupId}'";
            List<UserGroup> listaUserGroups = await _contextUsers.UserGroups.FromSqlRaw(query).ToListAsync();
            return listaUserGroups;
        }

        /// <summary>
        /// Adicionar utilizadores a um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddUserToUserGroup(User user, UserGroup userGroup)
        {
            var UserExistGroup = await _contextUsers.UserGroups.FirstOrDefaultAsync(x => x.IdUserGroup.Equals(user.IdUserGroup));
            if (UserExistGroup != null)
                return false;
            string query = "update public.user " +
                $"set id_user_group = @id_user_group " +
                $"where id_user = '@id_user'";
            var result = _contextUsers.Users.FromSqlRaw(query, new NpgsqlParameter("id_user_group", userGroup.IdUserGroup), new NpgsqlParameter("id_user", user.IdUser));
            return true;

        }

        /// <summary>
        /// Remover utilizador de um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserFromUserGroup(User user, UserGroup userGroup)
        {
            //Ver isto
            var userExistGroup = _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUserGroup.Equals(userGroup.IdUserGroup));
            if (userExistGroup != null)
                return false;
            string query = "update public.user " +
                $"set id_user_group = @id_user_group " +
                $"where id_user = '@id_user'";
            var result = _contextUsers.Users.FromSqlRaw(query, new NpgsqlParameter("id_user_group", userGroup.IdUserGroup), new NpgsqlParameter("id_user", user.IdUser));
            return true;
        }

        /// <summary>
        /// Adicionar manager a um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> AddManagerToUserGroup(User user, UserGroup userGroup)
        {
            if (user.IsManager)
            {
                string query = "update public.user " +
                $"set id_user_group = @id_user_group " +
                $"where id_user = '@id_user'";
                var result = _contextUsers.Users.FromSqlRaw(query, new NpgsqlParameter("id_user_group", userGroup.IdUserGroup), new NpgsqlParameter("id_user", user.IdUser));
                return true;
            }
            return false;

        }

        /// <summary>
        /// Remover gestor de um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> DeleteManagerToUserGroup(User user, UserGroup userGroup)
        {
            //Ver isto
            if (user.IsManager)
            {
                string query = "update public.user " +
                $"set id_user_group = @id_user_group " +
                $"where id_user = '@id_user'";
                var result = _contextUsers.Users.FromSqlRaw(query, new NpgsqlParameter("id_user_group", userGroup.IdUserGroup), new NpgsqlParameter("id_user", user.IdUser));
                return true;
            }
            return false;
        }


        //Users

        /// <summary>
        /// Adicionar um utilizador, primeiro verificar se existe, se não existir adiciona
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddUser(User user)
        {
            var userExists = _contextUsers.Users.FirstOrDefaultAsync(x => x.Email.Equals(user.Email));
            if (userExists != null)
                return false;
            await _contextUsers.Users.AddAsync(user);
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Editar um utilizador
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(User userId)
        {
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser.Equals(userId));
            if (userExist != null)
            {
                _contextUsers.Users.Update(userId);
                await _contextUsers.SaveChangesAsync();
                return true;
            }
            return false;

        }

        /// <summary>
        /// Desativar um utilizador
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(Guid userId)
        {
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser.Equals(userId));
            if (userExist != null)
            {
                string query = "update public.user " +
                "set is_active = false " +
                $"where id_user = '@id_user'";
                var result = _contextUsers.Users.FromSqlRaw(query);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lista de utilizadores
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUsers(User user)
        {
            string query = "select * from public.user";
            List<User> listUsers = await _contextUsers.Users.FromSqlRaw(query).ToListAsync();
            return listUsers;
        }
        /// <summary>
        /// Informação de um utilizador através do ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(Guid userId)
        {
            var userIdExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser.Equals(userId));
            if (userIdExist != null)
                return userIdExist;
            var user = await _contextUsers.Users.FirstOrDefaultAsync();
            return user;

        }
    }
}
