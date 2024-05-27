namespace BankAPP.Interfaces
{
    public interface ITransferService
    {
       public bool Transfer(int SourceAccount, int DestinationAccount,decimal amount);
    }
}
