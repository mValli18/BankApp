using BankAPP.Models;

namespace BankAPP.Interfaces
{
    public interface IAccountService
    {
        Account Add(Account account);
        bool Deposit(int AccountId,decimal amount);
        bool Withdraw(int AccountId,decimal amount);
    }
}
