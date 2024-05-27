using BankAPP.Interfaces;
using BankAPP.Contexts;
using BankAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPP.Repositories
{
    public class AccountRepository : IRepository<int, Account>
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public Account Add(Account entity)
        {
            _context.Accounts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Account Delete(int key)
        {
            var quiz = GetById(key);
            if (quiz != null)
            {
                _context.Accounts.Remove(quiz);
                _context.SaveChanges();
                return quiz;
            }
            return null;
        }

        public IList<Account> GetAll()
        {
            if (_context.Accounts.Count() == 0)
                return null;
            return _context.Accounts.ToList();
        }

        public Account GetById(int key)
        {
            var accounts = _context.Accounts.SingleOrDefault(u => u.AccountId == key);
            return accounts;
        }
        public Account Update(Account entity)
        {
            var account = GetById(entity.AccountId);
            if (account != null)
            {
                _context.Entry<Account>(account).State = EntityState.Modified;
                _context.SaveChanges();
                return account;
            }
            return null;
        }


    }
}

