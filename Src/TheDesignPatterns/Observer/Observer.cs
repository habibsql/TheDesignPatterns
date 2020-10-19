using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TheDesignPatterns.Observer
{
    /// <summary>
    /// Subject Class
    /// </summary>
    public class KeyboardItemInStock
    {
        private readonly Queue<Keyboard> keyboards = new Queue<Keyboard>();
        private readonly IList<INoKeyboardInStockListener> noKeyboardInStockListeners = new List<INoKeyboardInStockListener>();

        public KeyboardItemInStock()
        {
            keyboards.Enqueue(new Keyboard { Id = 1, UnitPrice = 100 });
            keyboards.Enqueue(new Keyboard { Id = 2, UnitPrice = 150 });
            keyboards.Enqueue(new Keyboard { Id = 3, UnitPrice = 200 });
        }

        /// <summary>
        /// Register Listers who are interested to listen when keybaord will be empty in stock.
        /// </summary>
        /// <param name="newListner"></param>
        public void RegisterListener(INoKeyboardInStockListener newListner)
        {
            noKeyboardInStockListeners.Add(newListner);
        }

        public void UnRegisterListener(INoKeyboardInStockListener existingListner)
        {
            noKeyboardInStockListeners.Remove(existingListner);
        }

        public Keyboard FetchSingleKeyboard()
        {
            Keyboard singleKeyboard = keyboards.Dequeue();

            if (keyboards.Count ==0 )
            {
                NotifyNOKeyboardInStockListenres();
            }

            return singleKeyboard;
        }

        /// <summary>
        /// Retrull all observers who wants to listen when empty keyboard in stock 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<INoKeyboardInStockListener> GetAllObservers()
        {
            return noKeyboardInStockListeners;
        }

        /// <summary>
        /// Notify all listeners when keyboard is empty in stock.
        /// </summary>
        private void NotifyNOKeyboardInStockListenres()
        {
            foreach(INoKeyboardInStockListener listner in noKeyboardInStockListeners )
            {
                listner.OnEmptyKeyboardInStock(DateTime.UtcNow);
            }
        }
    }

    public class Keyboard
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int UnitPrice { get; set; }
    }
    
    /// <summary>
    /// Observer interface
    /// </summary>
    public interface INoKeyboardInStockListener
    {
        void OnEmptyKeyboardInStock(DateTime date);
    }

    /// <summary>
    /// One kind of observer
    /// </summary>
    public class Supplier : INoKeyboardInStockListener
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime? DateOfKeyboardEmptyInStock { get; private set; }

        public void OnEmptyKeyboardInStock(DateTime date)
        {
            DateOfKeyboardEmptyInStock = date;

            Debug.WriteLine($"Need to supply new products dated={date}");
        }
    }

    /// <summary>
    /// Another kind of observer
    /// </summary>
    public class Accounts : INoKeyboardInStockListener
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime? DateOfKeyboardEmptyInStock { get; private set; }

        public void OnEmptyKeyboardInStock(DateTime date)
        {
            DateOfKeyboardEmptyInStock = date;

            Debug.WriteLine($"Keyboard stock has finished at {date}. Need to prepare money for purchse new items");
        }
    }
}
