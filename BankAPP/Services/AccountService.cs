using BankAPP.Interfaces;
using BankAPP.Models;

namespace BankAPP.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<int, Account> _accountRepository;
       


        public AccountService(IRepository<int, Account> accountRepository)
        {
            _accountRepository = accountRepository;
           
        }

      
        public Account Add(Account account)
        {
            var result = _accountRepository.Add(account);
            return result;
        }

        public bool Deposit(int AccountId, decimal amount)
        {
            var account=_accountRepository.GetById(AccountId);
            account.Balance += amount;
            _accountRepository.Update(account);
            return true;
        }

        public bool Withdraw(int AccountId, decimal amount)
        {
            var account = _accountRepository.GetById(AccountId);
            account.Balance -= amount;
            _accountRepository.Update(account);
            return true;
        }
    }
}
