using BudifyAPI.Users.Models.WalletModel.DBWallet;

namespace BudifyAPI.Users.Services.Wallets.InerfaceWallet
{
    public interface IWalletService
    {
        Task<List<Wallet>> GetWallet(Wallet wallets);
        Task<bool> AddWallets(Wallet wallets);
        Task<bool> UpdateWallet(Wallet wallet);
        Task<bool> DeleteWallet(Guid walletId);
        //Task<bool> UpdateWalletAmount(Guid walletId);
        Task<bool> GetWalletById(Guid walletId);
    }
}
