namespace TheDesignPatterns.Proxy
{
    public interface IAccountService
    {
        int GetTodaysIncome();

        int GetTodaysExpense();
    }

    public class AccountService : IAccountService
    {
        public int GetTodaysExpense()
        {
            int expense = 500;

            return expense;
        }

        public int GetTodaysIncome()
        {
            int income = 1000000;

            return income;
        }
    }

    public class ProxyAccountService : IAccountService
    {
        private readonly IAccountService accountService = new AccountService();

        public int GetTodaysExpense()
        {
            int expense = accountService.GetTodaysExpense();

            if (expense >= 10000)
            {
                return expense;
            }

            return expense * 2;
        }

        public int GetTodaysIncome()
        {
            int income = accountService.GetTodaysIncome();

            if (income > 10000)
            {
                return income  / 2;
            }

            return income;
        }
    }
}
