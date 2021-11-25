using Common;
using Data.Contracts;
using Data.DTOs;
using Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository, IScopedDependency
    {
        private readonly IUserRepository _userRepository;
        public WalletRepository(ApplicationDbContext context, IUserRepository userRepository)
            : base(context)
        {
            this._userRepository = userRepository;
        }

        public async Task<int> AddWallet(Wallet wallet, CancellationToken cancellationToken)
        {
            var result= AddAsync(wallet,cancellationToken);
            return result.Id;
        }

        public async Task<int> BalanceUserWallet(string userName, CancellationToken cancellationToken)
        {
            int userId = await _userRepository.GetUserIdByUserName(userName, cancellationToken);

            var Enter = await Table.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount).ToListAsync(cancellationToken);

            var Exit = await Table.Where(w => w.UserId == userId && w.TypeId == 2)
                .Select(w => w.Amount).ToListAsync(cancellationToken);

            return (Enter.Sum() - Exit.Sum());
        }

        public async Task<int> ChargeWallet(string userName, int amount, string description, CancellationToken cancellationToken, bool isPay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = isPay,
                TypeId = 1,
                UserId =await _userRepository.GetUserIdByUserName(userName,cancellationToken)
            };
            return await AddWallet(wallet,cancellationToken);
        }

        public async Task<Wallet> GetWalletByWalletId(int walletId, CancellationToken cancellationToken)
        {
            return await Entities.FindAsync(walletId);
        }

        public async Task<List<WalletViewModel>> GetWalletUser(string userName, CancellationToken cancellationToken)
        {
            int userId = await _userRepository.GetUserIdByUserName(userName,cancellationToken);

            return await Table.Where(w => w.IsPay && w.UserId == userId)
                .Select(w => new WalletViewModel()
                {
                     Amount=w.Amount,
                     DateTime=w.CreateDate,
                     Description=w.Description,
                     Type=w.TypeId

                }).ToListAsync();
        }


    }
}
