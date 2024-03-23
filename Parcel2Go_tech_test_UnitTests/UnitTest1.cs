using Parcel2Go_tech_test;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Parcel2Go_tech_test_UnitTests
{
    public class UnitTest1
    {
        IServiceCatalogue catalogue = new ServiceCatalogue();

        [Theory]
        [InlineData("a", "A")]
        [InlineData("A", "A")]
        [InlineData("b", "B")]
        [InlineData("B", "B")]
        [InlineData("c", "C")]
        [InlineData("C", "C")]
        [InlineData("d", "D")]
        [InlineData("D", "D")]
        [InlineData("F", "F")]
        [InlineData("f", "F")]
        [InlineData("F ", "F")]
        [InlineData(" f", "F")]

        public void BasketAddTestValidInput(string input, string expected)
        {
            Checkout checkout = new Checkout(catalogue);
          var result =  checkout.Scan(input);

            Assert.True(result);
            Assert.Contains(expected, checkout.ShoppingBasket);
            Assert.True(checkout.ShoppingBasket.Count == 1);
        }


        [Theory]
        [InlineData("e")]
        [InlineData("checkout")]
        [InlineData("1")]
        [InlineData("exit")]

        public void BasketAddTestinvalidInput(string input)
        {
            Checkout checkout = new Checkout(catalogue);
            var result = checkout.Scan(input);

            Assert.False(result);
            Assert.True(checkout.ShoppingBasket.Count == 0);
        }


        [Theory]
        [InlineData(1, 10.0)]
        [InlineData(2, 20.0)]
        [InlineData(3, 25.0)]
        [InlineData(4, 35.0)]
        [InlineData(5, 45.0)]
        [InlineData(6, 50.0)]

        public void ServiceAPrices(int quantity, decimal price) 
        {
            Checkout checkout = new Checkout(catalogue);

            for(int i = 0; i < quantity; i++)
            {
                checkout.Scan("A");
            }

            Assert.True(checkout.GetTotalPrice() == price);
            Assert.True(checkout.ShoppingBasket.Count == quantity);
        }


        [Theory]
        [InlineData(1, 12.0)]
        [InlineData(2, 20.0)]
        [InlineData(3, 32.0)]
        [InlineData(4, 40.0)]
        public void ServiceBPrices(int quantity, decimal price)
        {
            Checkout checkout = new Checkout(catalogue);

            for (int i = 0; i < quantity; i++)
            {
                checkout.Scan("B");
            }

            Assert.True(checkout.GetTotalPrice() == price);
            Assert.True(checkout.ShoppingBasket.Count == quantity);
        }


        [Theory]
        [InlineData(1, 15.0)]
        [InlineData(2, 30.0)]
        [InlineData(3, 45.0)]
        public void ServiceCPrices(int quantity, decimal price)
        {
            Checkout checkout = new Checkout(catalogue);

            for (int i = 0; i < quantity; i++)
            {
                checkout.Scan("C");
            }

            Assert.True(checkout.GetTotalPrice() == price);
            Assert.True(checkout.ShoppingBasket.Count == quantity);
        }


        [Theory]
        [InlineData(1, 25.0)]
        [InlineData(2, 50.0)]
        [InlineData(3, 75.0)]
        public void ServiceDPrices(int quantity, decimal price)
        {
            Checkout checkout = new Checkout(catalogue);

            for (int i = 0; i < quantity; i++)
            {
                checkout.Scan("D");
            }

            Assert.True(checkout.GetTotalPrice() == price);
            Assert.True(checkout.ShoppingBasket.Count == quantity);
        }


        [Theory]
        [InlineData(1, 8.0)]
        [InlineData(2, 15.0)]
        [InlineData(3, 23.0)]
        public void ServiceFPrices(int quantity, decimal price)
        {
            Checkout checkout = new Checkout(catalogue);

            for (int i = 0; i < quantity; i++)
            {
                checkout.Scan("F");
            }

            Assert.True(checkout.GetTotalPrice() == price);
            Assert.True(checkout.ShoppingBasket.Count == quantity);
        }


        [Fact]
        public void Example1Test() {

            Checkout checkout = new Checkout(catalogue);

            checkout.Scan("B");
            checkout.Scan("B");

            Assert.True(checkout.GetTotalPrice() == 20.0m);
            Assert.True(checkout.ShoppingBasket.Count == 2);
        }


        [Fact]
        public void Example2Test()
        {
            Checkout checkout = new Checkout(catalogue);

            checkout.Scan("F");
            checkout.Scan("C");

            Assert.True(checkout.GetTotalPrice() == 23.0m);
            Assert.True(checkout.ShoppingBasket.Count == 2);

        }


        [Fact]
        public void Example3Test()
        {
            Checkout checkout = new Checkout(catalogue);

            checkout.Scan("F");
            checkout.Scan("F");
            checkout.Scan("B");

            Assert.True(checkout.GetTotalPrice() == 27.0m);
            Assert.True(checkout.ShoppingBasket.Count == 3);
        }

    }
}