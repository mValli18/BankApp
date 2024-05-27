using BankAPP.Interfaces;

namespace BankAPP.Services
{
    public class TransferService : ITransferService
    {
        private readonly IAccountService _accountService;
        private readonly ITransferLogService _itl;
        public TransferService(IAccountService accountService)
            {
             _accountService = accountService;
            }
        public bool Transfer(int SourceAccount, int DestinationAccount, decimal amount)
        {
            _accountService.Withdraw(SourceAccount, amount);
            _accountService.Deposit(DestinationAccount, amount);
            _itl.Log(SourceAccount, DestinationAccount, amount);
            return true;

        }
    }
}
