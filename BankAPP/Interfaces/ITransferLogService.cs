namespace BankAPP.Interfaces
{
    public interface ITransferLogService
    {
        void Log(int SourceAccountId,int DestinationAccountId,decimal amount);
    }
}
