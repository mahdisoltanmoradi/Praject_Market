using Common;
using Common.Utilities;
using Common.Utilities.Convertors;
using Data.Contracts;
using Data.DTOs;
using Data.DTOs.AdminViewModel;
using Entities.User;
using Entities.Wallet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IScopedDependency
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            return Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> ActiveAccount(string activeCode, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(p => p.ActiveCode == activeCode);
        }

        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await TableNoTracking.ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleOrDefaultAsync(e => e.Email == email, cancellationToken);
        }

        public async Task<User> GetUserByUserId(int userId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public async Task<User> GetUserByUserName(string userName, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleAsync(u => u.UserName == userName, cancellationToken);
        }

        public async Task<int> GetUserIdByUserName(string userName, CancellationToken cancellationToken)
        {
            var user = await TableNoTracking.SingleAsync(u => u.UserName == userName, cancellationToken);
            return user.Id;
        }

        public async Task<bool> IsExistEmail(string email, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User> IsExistEmailAndPassword(LoginViewModel login, CancellationToken cancellationToken)
        {
            string FixeEmail = FixedText.FixeEmail(login.Email);
            string hashPassword = login.Password;
            var user= await TableNoTracking.SingleOrDefaultAsync(u => u.Email == login.Email && u.PasswordHash == hashPassword, cancellationToken);
            return user;
        }

        public async Task<User> IsExistUserByUserEmail(string email, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> IsExistUserName(string userName, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(u => u.UserName == userName, cancellationToken);
        }

        public async Task<InformationUserViewModel> GetUserInformation(string userName, CancellationToken cancellationToken)
        {
            var user = await TableNoTracking.Where(u => u.UserName == userName).SingleAsync();
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.UserAvatar = user.UserAvatar;

            return information;
        }

        public async Task<InformationUserViewModel> GetUserInformation(int userId, CancellationToken cancellationToken)
        {
            var user = await TableNoTracking.FirstOrDefaultAsync(u => u.Id == userId);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.UserAvatar = user.UserAvatar;

            return information;
        }

        public async Task<SideBarUserPanelViewModel> GetSideBarUserPanelData(string username, CancellationToken cancellationToken)
        {
            var user = await TableNoTracking.Where(u => u.UserName == username).Select(u => new SideBarUserPanelViewModel
            {
                UserName = u.UserName,
                RegisterDate = u.RegisterDate,
                ImageName = u.UserAvatar
            }).SingleAsync();
            return user;
        }

        public async Task<EditProfileViewModel> GetDataForEditProfileUser(string userName, CancellationToken cancellationToken)
        {
            var user = await Table.Where(u => u.UserName == userName).Select(u => new EditProfileViewModel()
            {
                UserName = u.UserName,
                AvatarName = u.UserAvatar,
                Email = u.Email,
                lifeLocation = u.lifeLocation
            }).SingleAsync();
            return user;
        }

        public async Task EditProfile(string username, EditProfileViewModel profile, CancellationToken cancellationToken)
        {
            if (profile.UserAvatar != null)
            {
                string imagePath = "";
                if (profile.AvatarName != "Defult.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProductCategory/UserImage", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProductCategory/UserImage", profile.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }

            }

            var user = await Table.Where(u => u.UserName == username).SingleAsync();
            user.UserName = profile.UserName;
            user.Email = profile.Email;
            user.lifeLocation = profile.lifeLocation;
            user.UserAvatar = profile.AvatarName;

            await UpdateAsync(user, cancellationToken);
        }

        public async Task<bool> CompareOldPassword(string oldPassword, string username, CancellationToken cancellationToken)
        {
            var hashPassword = PasswordHelper.EncodePasswordMd5(oldPassword);
            return await Table.AnyAsync(u => u.UserName == username && u.PasswordHash == hashPassword);
        }

        public async Task ChangeUserPassword(string userName, string newPassword, CancellationToken cancellationToken)
        {
            var user = await TableNoTracking.SingleOrDefaultAsync(u => u.UserName == userName);
            user.PasswordHash = PasswordHelper.EncodePasswordMd5(newPassword);
            await UpdateAsync(user, cancellationToken);
        }

        public async Task<UserForAdminViewModel> GetUsers(CancellationToken cancellationToken, int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            var user =await TableNoTracking.ToListAsync();
            if (!string.IsNullOrEmpty(filterEmail))
            {
                user.Where(u => u.Email.Contains(filterEmail));
            }
            if (!string.IsNullOrEmpty(filterUserName))
            {
                user.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 5;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = user.Count() / take;
            list.Users =user.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public async Task<UserForAdminViewModel> GetDeleteUsers(CancellationToken cancellationToken,int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            var user = TableNoTracking.IgnoreQueryFilters().Where(u=>u.IsDelete);
            if (!string.IsNullOrEmpty(filterEmail))
            {
                user.Where(u => u.Email.Contains(filterEmail));
            }
            if (!string.IsNullOrEmpty(filterUserName))
            {
                user.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = user.Count() / take;
            list.Users = user.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public async Task AddUserFromAdmin(CreateUserViewModel user, CancellationToken cancellationToken)
        {
            User addUser = new User();
            addUser.PasswordHash = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GeneratorUniqCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;

            #region Save Avatar

            if (user.UserAvatar != null)
            {
                string imagePath = "";
                addUser.UserAvatar = NameGenerator.GeneratorUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProductCategory/UserImage", addUser.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            await AddAsync(addUser,cancellationToken);
        }

        public async Task<EditUserViewModel> GetUserForShowInEditMode(int userId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(u => u.Id == userId)
                .Select(u => new EditUserViewModel()
                {
                    UserId = u.Id,
                    AvatarName = u.UserAvatar,
                    Email = u.Email,
                    UserName = u.UserName
                }).SingleAsync();
        }

        public async Task EditUserFromAdmin(EditUserViewModel editUser, CancellationToken cancellationToken)
        {
            User user =await GetUserByUserId(editUser.UserId,cancellationToken);
            user.Email = editUser.Email;
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.PasswordHash = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }

            if (editUser.UserAvatar != null)
            {
                //Delete old Image
                if (editUser.AvatarName != "Defult.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProductCategory/UserImage", editUser.AvatarName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }

                //Save New Image
                user.UserAvatar = NameGenerator.GeneratorUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProductCategory/UserImage", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }

            await UpdateAsync(user, cancellationToken);
        }

        public async Task DeleteUser(int userId,CancellationToken cancellationToken)
        {
            User user =await GetUserByUserId(userId,cancellationToken);
            user.IsDelete = true;
            await UpdateAsync(user,cancellationToken);
        }
    }
}
