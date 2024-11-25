using BudifyAPI.Users.Models.WalletModel.DBWallet;
using BudifyAPI.Users.Services.Wallets.InerfaceWallet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudifyAPI.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }


        [HttpGet("GetWallets")]
        public async Task<IActionResult> GetWallet(Wallet wallets)
        {
            var result = await _walletService.GetWallet(wallets);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AdicionaWallet")]
        public async Task<IActionResult> AddWallet(Wallet wallets)
        {
            var result = await _walletService.AddWallets(wallets);
            if(result != null) 
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateWallet")]
        public async Task<IActionResult> UpdateWallet(Wallet wallet)
        {
            var result = await _walletService.UpdateWallet(wallet);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("DeleteWallet/walletId")]
        public async Task<IActionResult> DeleteWallet(Guid walletId)
        {
            var result = await _walletService.DeleteWallet(walletId);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet("GetWalletById/walletId")]
        public async Task<IActionResult> GetWalletById(Guid walletId)
        {
            var result = await _walletService.GetWalletById(walletId);
            if (result != null)
                return Ok();
            return BadRequest();
        }
    }
}
