using BudifyAPI.Users.Models.USers.DBUsers;
using Microsoft.EntityFrameworkCore;
using BudifyAPI.Users.Models;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BudifyAPI.Users.Models.USers.Helpers;
using Microsoft.AspNetCore.Identity;
using BudifyAPI.Users.Models.USers.DBUsers.CreateUSerHelper;

namespace BudifyAPI.Users.Services
{
    public class UsersService:IUsersService
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
        public async Task<bool> AddUserGroup(CreateUserGroup name)
        {

            //string query = "insert into user_group (name) " +
            //    "values(@name)";
            //var resp = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@name", name.userGroupName));
            await _contextUsers.UserGroups.AddAsync(new UserGroup (){ Name = name.userGroupName });
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Editar grupo de utilizadores
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserGroup(Guid userGroupId, CreateUserGroup name)
        {
            var userGroupExist = await _contextUsers.UserGroups.FirstOrDefaultAsync(x => x.IdUserGroup == userGroupId);            
            if (userGroupExist == null)
                return false;

            _contextUsers.UserGroups.Update(new UserGroup() { Name = name.userGroupName });
            await _contextUsers.SaveChangesAsync();
            return true;


            //string query = "uddate public.user_group " +
            //    "set  name = @name " +
            //    "where id_user_group = @id_user_group";
            //var resp = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@name", name), new NpgsqlParameter("@id_user_group", userGroupId));

        }

        /// <summary>
        /// Apagar grupo de utilizadores
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserGroup(Guid userGroupId)
        {
            //VER ISTO
            var userGroupExist = await _contextUsers.UserGroups.FirstOrDefaultAsync(x => x.IdUserGroup == userGroupId);
            if (userGroupExist == null)
                return false;
            _contextUsers.UserGroups.Remove(userGroupExist);
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Obter grupo de utilizadores através do ID do grupo
        /// </summary>
        /// <param name="userGroupId"></param>
        /// <returns></returns>
        public async Task<UserGroup> GetUserGroup(Guid userGroupId)
        {
            var UserExistGroup = await _contextUsers.UserGroups.FirstOrDefaultAsync(x => x.IdUserGroup == userGroupId);
            if (UserExistGroup == null)
                return null;
            string query = $"select * from public.user_group where id_user_group = @userGroupId";
            var listaUserGroups = await _contextUsers.UserGroups.FromSqlRaw(query, new NpgsqlParameter("@userGroupId", userGroupId)).FirstOrDefaultAsync();
            return listaUserGroups;
        }
        /// <summary>
        /// Adicionar utilizadores a um grupo
        /// </summary>
        /// <param name="createUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> AddUserToUserGroup(CreateUser createUser, Guid userId)
        {
            var existGroup = await _contextUsers.UserGroups.FirstOrDefaultAsync(x => x.IdUserGroup == createUser.IdUserGroup);
            if (existGroup == null)
                return false;
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser == userId);
            if(userExist == null) 
                return false;
            userExist.IdUserGroup = createUser.IdUserGroup;
            await _contextUsers.SaveChangesAsync();
            return true;


            //string query = "update public.user " +
            //    $"set id_user_group = @id_user_group " +
            //    $"where id_user = @id_user";
            //var result = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@id_user_group", user.IdUserGroup), new NpgsqlParameter("@id_user", user.IdUser));
            //return true;

        }

        /// <summary>
        /// Remover utilizador de um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserFromUserGroup(Guid userId)
        {
            //Ver isto
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser == userId);
            if (userExist == null)
                return false;
            //var userExistInGroup = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUserGroup == userGroupId);
            //if (userExistInGroup == null)
            //    return false;
            //userExist.IdUserGroup = null;
            string query = "update public.user " +
                "set id_user_group = null " +
                "where id_user = @id_user ";
            var result = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@id_user", userId));
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Adicionar manager a um grupo
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        public async Task<bool> AddManagerToUserGroup(User user)
        {
            if (user.IsManager)
            {
                string query = "update public.user " +
                $"set id_user_group = @id_user_group " +
                $"where id_user = @id_user";
                var result = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@id_user_group", user.IdUserGroup), new NpgsqlParameter("@id_user", user.IdUser));
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
        public async Task<bool> DeleteManagerToUserGroup(User user)
        {
            //Ver isto
            if (user.IsManager)
            {
                string query = "update public.user " +
                $"set id_user_group = null " +
                $"where id_user = '@id_user'";
                var result = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@id_user_group", user.IdUserGroup), new NpgsqlParameter("@id_user", user.IdUser));
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
        public async Task<bool> AddUser(CreateUser createUser)
        {
            var userExists = await _contextUsers.Users.FirstOrDefaultAsync(x => x.Email == createUser.Email);
            if (userExists != null)
                return false;
            await _contextUsers.Users.AddAsync(new User{

                IdUserGroup = createUser.IdUserGroup,
                Name = createUser.Name,
                Email = createUser.Email,
                Password = createUser.Password,
                DateOfBirth = createUser.DateOfBirth,
                Genre = createUser.Genre,
                IsActive = createUser.IsActive,
                IsAdmin = createUser.IsAdmin,
                IsManager = createUser.IsManager,
                AllowWalletWatch = createUser.AllowWalletWatch

            });
            await _contextUsers.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Editar um utilizador
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(Guid userId, CreateUser createUser)
        {
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser == userId);
            if (userExist == null)
                return false;

            _contextUsers.Users.Update(new User()
            {
                IdUserGroup = createUser.IdUserGroup,
                Name = createUser.Name,
                Email = createUser.Email,
                Password = createUser.Password,
                DateOfBirth = createUser.DateOfBirth,
                Genre = createUser.Genre,
                IsActive = createUser.IsActive,
                IsAdmin = createUser.IsAdmin,
                IsManager = createUser.IsManager,
                AllowWalletWatch = createUser.AllowWalletWatch
            });
            await _contextUsers.SaveChangesAsync();
            return true;


        }

        /// <summary>
        /// Desativar um utilizador
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(Guid userId)
        {
            var userExist = await _contextUsers.Users.FirstOrDefaultAsync(x => x.IdUser == userId);
            if (userExist == null)
                return false;
            //string queryVerificaGrupo = "select id_user_group from public.user where id_user = @id_user";
            //var result = _contextUsers.Users.FromSqlRaw(queryVerificaGrupo, new NpgsqlParameter("@id_user", userId));
            ////TODO
            //if (!result)
            //    return false;
            string query = "update public.user " +
               "set is_active = 'false' " +
               "where id_user = @id_user";
            var result2 = _contextUsers.Database.ExecuteSqlRawAsync(query, new NpgsqlParameter("@id_user", userId));
            await _contextUsers.SaveChangesAsync();
            return true;

        }
        /// <summary>
        /// Lista de utilizadores
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUsers()
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
            if (userIdExist == null)
                return null;
            string query = "select * from public.user where id_user = @id_user";
            var user = await _contextUsers.Users.FromSqlRaw(query, new NpgsqlParameter("@id_user", userId)).FirstOrDefaultAsync();
            return user;

        }
    }
}
