using Data.DTOs;
using Data.DTOs.AdminViewModel;
using Entities.User;
using Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository 
    {
        Task<bool> IsExistUserName(string userName, CancellationToken cancellationToken);
        Task<bool> IsExistEmail(string email, CancellationToken cancellationToken);
        Task<User> IsExistEmailAndPassword(LoginViewModel login, CancellationToken cancellationToken);
        Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);
        Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<User> IsExistUserByUserEmail(string email, CancellationToken cancellationToken);
        Task<User> GetUserByUserName(string userName, CancellationToken cancellationToken);
        Task<int> GetUserIdByUserName(string userName, CancellationToken cancellationToken);
        Task<bool> ActiveAccount(string activeCode, CancellationToken cancellationToken);
        Task<User> GetUserByUserId(int userId, CancellationToken cancellationToken);
        Task<List<User>> GetAllUsers(CancellationToken cancellationToken);
        Task DeleteUser(int userId,CancellationToken cancellationToken);
        Task UpdateUser(User user,CancellationToken cancellationToken);
        Task<int> AddUser(User user,CancellationToken cancellationToken);
        Task<User> ExistActiveCode(string token);
        Task<User> ExistPassword(string password);
       
        #region User Panel

        Task<InformationUserViewModel> GetUserInformation(string userName, CancellationToken cancellationToken);
        Task<InformationUserViewModel> GetUserInformation(int userId, CancellationToken cancellationToken);
        Task<SideBarUserPanelViewModel> GetSideBarUserPanelData(string username, CancellationToken cancellationToken);
        Task<EditProfileViewModel> GetDataForEditProfileUser(string userName, CancellationToken cancellationToken);
        Task EditProfile(string username, EditProfileViewModel profile, CancellationToken cancellationToken);
        Task<bool> CompareOldPassword(string oldPassword, string username, CancellationToken cancellationToken);
        Task ChangeUserPassword(string userName, string newPassword, CancellationToken cancellationToken);
        //Task<int> BalanceUserWallet(string userName, CancellationToken cancellationToken);

        #endregion

        #region Admin Panel
        Task<UserForAdminViewModel> GetUsers(CancellationToken cancellationToken,int pageId = 1, string filterEmail = "", string filterUserName = "");
        Task<UserForAdminViewModel> GetDeleteUsers(CancellationToken cancellationToken,int pageId = 1, string filterEmail = "", string filterUserName = "");
        Task AddUserFromAdmin(CreateUserViewModel user, CancellationToken cancellationToken);
        Task<EditUserViewModel> GetUserForShowInEditMode(int userId, CancellationToken cancellationToken);
        Task EditUserFromAdmin(EditUserViewModel editUser, CancellationToken cancellationToken);

        #endregion

        #region Wallet

        Task<int> BalanceUserWallet(string userName, CancellationToken cancellationToken);
        Task<List<WalletViewModel>> GetWalletUser(string userName, CancellationToken cancellationToken);
        Task<int> ChargeWallet(string userName, int amount, string description, CancellationToken cancellationToken, bool isPay = false);
        Task<int> AddWallet(Wallet wallet, CancellationToken cancellationToken);
        Task<Wallet> GetWalletByWalletId(int walletId, CancellationToken cancellationToken);
        void UpdateWallet(Wallet wallet,CancellationToken cancellationToken);

        #endregion
    }
}
