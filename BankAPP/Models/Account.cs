namespace BankAPP.Models
{
    public abstract class Account
    {
        public int AccountId { get; set; }

        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
      
        private User user { get; set; }
    }
}
