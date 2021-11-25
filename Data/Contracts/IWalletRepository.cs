using Common;
using Data.DTOs;
using Entities.Common;
using Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IWalletRepository:IRepository<Wallet>
    {
        #region Wallet

        Task<int> BalanceUserWallet(string userName, CancellationToken cancellationToken);
        Task<List<WalletViewModel>> GetWalletUser(string userName, CancellationToken cancellationToken);
        Task<int> ChargeWallet(string userName, int amount, string description, CancellationToken cancellationToken, bool isPay = false);
        Task<int> AddWallet(Wallet wallet, CancellationToken cancellationToken);
        Task<Wallet> GetWalletByWalletId(int walletId, CancellationToken cancellationToken);

        #endregion
    }
}
