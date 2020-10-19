using System.Collections.Generic;

namespace TheDesignPatterns.Mediator
{
    /// <summary>
    /// Colleague
    /// </summary>
    public interface IFamilyExpenseProvider
    {
        int ProvideExpenseAmount();
    }

    public class Father : IFamilyExpenseProvider
    {
        public int ProvideExpenseAmount()
        {
            return 1000;
        }
    }
    public class GrandFather : IFamilyExpenseProvider
    {
        public int ProvideExpenseAmount()
        {
            return 2000;
        }
    }

    /// <summary>
    /// Mediator
    /// </summary>
    public interface IExpenseMoneyCollector
    {
        int CollectExpenseAmount();
    }

    public class Mother : IExpenseMoneyCollector
    {
        private readonly IList<IFamilyExpenseProvider> familyExpenseProviderList = new List<IFamilyExpenseProvider>();

        public Mother()
        {
            familyExpenseProviderList.Add(new Father());
            familyExpenseProviderList.Add(new GrandFather());
        }

        public int CollectExpenseAmount()
        {
            int totalAmount = 0;
            foreach(IFamilyExpenseProvider expenseProvider in familyExpenseProviderList)
            {
               totalAmount += expenseProvider.ProvideExpenseAmount();
            }

            return totalAmount;
        }
    }
}
