using BankAPP.Models;
using BankAPP.Services;
using BankAPP.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BankAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransferService _transfer;
        private readonly ITransferLogService _transferLog;
        private readonly Savings _savings;
        private readonly Current _current;

        private readonly PPF _ppf;


        public AccountController(IAccountService accountService, ITransferService transfer,ITransferLogService transferLog,Savings savings,PPF ppf,Current current)
        { 
            _accountService = accountService;
            _transfer = transfer;
            _transferLog = transferLog;
            _savings = savings;
            _ppf = ppf;
            _current = current;
            
        }
        [HttpPost]
        public ActionResult Create(Account account)
        {
            string errorMessage = string.Empty;
            try
            {
               
                var result = _accountService.Add(account);
                
                return Ok(result); 
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
           
            return BadRequest(errorMessage); 
        }
        [HttpPost("Deposit")]
        public ActionResult Deposit(int AccountID,decimal Amount) {
            string errorMessage = string.Empty;
            try
            {
                bool flag= _accountService.Deposit(AccountID, Amount);
                if(flag==true)
                {
                    Console.WriteLine($"{Amount} is credited into {AccountID}");
                }
               
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return BadRequest(errorMessage);
        }
        [HttpPost("Withdraw")]
        public ActionResult Withdraw(int AccountID, decimal Amount)
        {
            string errorMessage = string.Empty;
            try
            {
                bool flag = _accountService.Withdraw(AccountID, Amount);
                if (flag == true)
                {
                    Console.WriteLine($"{Amount} is Debited from {AccountID}");
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return BadRequest(errorMessage);
        }
        [HttpPost("Transfer")]
        public ActionResult Transfer(int SourceAccountID,int DestinationAccountId,decimal Amount) { 
            string errorMessage = string.Empty;
            try
            {
                bool flag = _current.Transfer(SourceAccountID, DestinationAccountId, Amount);
                if (flag == true)
                {
                    _transferLog.Log(SourceAccountID, DestinationAccountId, Amount);
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }

    }
}
