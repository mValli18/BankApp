using BankAPP.Services;

namespace BankAPP.Models
{
    public class Current : Account
    {
        private readonly TransferService _transferService;
        public Current(TransferService transferService)
        {
            _transferService = transferService;
        }

        public bool Transfer(int SourceAccount, int DestinationAccount, decimal amount)
        {
            _transferService.Transfer(SourceAccount, DestinationAccount, amount);
            return true;
        }
    }
}
