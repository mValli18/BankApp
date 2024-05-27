using BankAPP.Interfaces;
using BankAPP.Models;

namespace BankAPP.Services
{
    public class TransferLogService : ITransferLogService
    {
        

        public void Log(int SourceAccountId, int DestinationAccountId, decimal amount)
        {
            Console.WriteLine($"Transferred {amount} from account {SourceAccountId} to account {DestinationAccountId}");
        }
    }
}
