using BankAPP.Interfaces;
using BankAPP.Services;

namespace BankAPP.Models
{
    public class Savings : Account, ITransferService
    {
        private readonly TransferService _transferService;
        public Savings(TransferService transferService){
            _transferService = transferService;
            }

        public bool Transfer(int SourceAccount, int DestinationAccount, decimal amount)
        {
            _transferService.Transfer(SourceAccount, DestinationAccount, amount);
            return true;
        }
    }
}
