using BudifyAPI.Users.Models.WalletModel.DBWallet;
using BudifyAPI.Users.Services.Wallets.InerfaceWallet;
using Microsoft.EntityFrameworkCore;

namespace BudifyAPI.Users.Services.Wallets
{
    public class WalletService : IWalletService
    { 
        private readonly WalletContext _walletContext;

        public WalletService(WalletContext walletContext)
        {
            _walletContext = walletContext;
        }
        /// <summary>
        /// Adicionar Wallet
        /// </summary>
        /// <param name="wallets"></param>
        /// <returns></returns>
        public async Task<bool> AddWallets(Wallet wallets)
        {
            var walletExist = await _walletContext.Wallets.FirstOrDefaultAsync(x => x.IdWallet.Equals(wallets.IdWallet));
            if(walletExist == null) 
                return false;
            await _walletContext.AddAsync(wallets);
            await _walletContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Apagar Wallet
        /// </summary>
        /// <param name="walletId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteWallet(Guid walletId)
        {
            var walletExist = await _walletContext.Wallets.FirstOrDefaultAsync(x => x.IdWallet.Equals(walletId));
            if (walletExist == null)
                return false;
            _walletContext.Remove(walletId);
            await _walletContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Lista de Wallets
        /// </summary>
        /// <param name="wallets"></param>
        /// <returns></returns>
        public async Task<List<Wallet>> GetWallet(Wallet wallets)
        {
            string query = "select * from public.wallet";
            List<Wallet> listWallet = await _walletContext.Wallets.FromSqlRaw(query).ToListAsync();
            return listWallet;
        }
        /// <summary>
        /// Get wallet por ID
        /// </summary>
        /// <param name="walletId"></param>
        /// <returns></returns>
        public async Task<bool> GetWalletById(Guid walletId)
        {
            var walletExist = await _walletContext.Wallets.FirstOrDefaultAsync(x => x.IdWallet.Equals(walletId));
            if (walletExist == null)
                return false;
            await _walletContext.Wallets.FirstOrDefaultAsync();
            return true; 
            
        }
        /// <summary>
        /// Update Wallet
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public async Task<bool> UpdateWallet(Wallet wallet)
        {
            var walletExist = _walletContext.Wallets.FirstOrDefaultAsync(x => x.IdWallet.Equals(wallet.IdWallet));
            if (walletExist == null)
                return false;
            _walletContext.Wallets.Update(wallet);
            await _walletContext.SaveChangesAsync();
            return true;

        }
        //VER ISTO
        //public Task<bool> UpdateWalletAmount(Guid walletId)
        //{
        //    var walletExist = _walletContext.Wallets.FirstOrDefaultAsync(x => x.IdWallet.Equals(walletId));
        //    if (walletExist == null)
        //        return false;
        //    string query = ""
        //}
    }
}
