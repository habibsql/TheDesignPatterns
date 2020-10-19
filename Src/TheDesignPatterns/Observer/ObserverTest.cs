using FluentAssertions;
using System;
using Xunit;

namespace TheDesignPatterns.Observer
{
    public class ObserverTest
    {
        private readonly KeyboardItemInStock keyboardItemInStock = new KeyboardItemInStock();

        [Fact]
        public void ShouldRegisterListener()
        {
            INoKeyboardInStockListener supplierListener = new Supplier();
            INoKeyboardInStockListener accountListener = new Supplier();

            keyboardItemInStock.RegisterListener(supplierListener);
            keyboardItemInStock.RegisterListener(accountListener);

            keyboardItemInStock.GetAllObservers().Should().HaveCount(2);
        }


        [Fact]
        public void ShouldNotifyListeners()
        {
            //Arrange
            var supplierListener = new Supplier();
            var accountListener = new Accounts();

            keyboardItemInStock.RegisterListener(supplierListener);
            keyboardItemInStock.RegisterListener(accountListener);

            //Act
            Keyboard item1 = keyboardItemInStock.FetchSingleKeyboard(); // after getting, still stock has two items
            Keyboard item2 = keyboardItemInStock.FetchSingleKeyboard(); // after getting, still stock has one item
            Keyboard item3 = keyboardItemInStock.FetchSingleKeyboard(); // after getting, stock is empty and now it should notify subsribers/listeners

            //Assert
            supplierListener.DateOfKeyboardEmptyInStock.Should().BeSameDateAs(DateTime.UtcNow);
            accountListener.DateOfKeyboardEmptyInStock.Should().BeSameDateAs(DateTime.UtcNow);
        }
    }
}