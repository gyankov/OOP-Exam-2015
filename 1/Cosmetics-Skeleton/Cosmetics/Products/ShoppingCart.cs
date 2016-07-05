using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{

    // Shopping cart should implement the IShoppingCart interface.
    // Adding the same product more than once is allowed.
    // Do not check if the product exists, when removing it from the shopping cart.
    // Look into the example below to get better understanding of the printing format.
    // All number type fields should be printed “as is”, without any formatting or rounding.
    // All properties in the above interfaces are mandatory(cannot be null or empty).
    // If a null value is passed to some mandatory property, your program should throw a proper exception.


    class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> cart;


        public ShoppingCart()
        {
            this.cart = new List<IProduct>();
        }



        public ICollection<IProduct> Cart
        {
            get
            {
                return new List<IProduct>(this.cart);
            }
        }



        public void AddProduct(IProduct product)
        {
           

            this.cart.Add(product);

        }



        public bool ContainsProduct(IProduct product)
        {

            return this.cart.Contains(product);
        }



        public void RemoveProduct(IProduct product)
        {
            this.cart.Remove(product);
        }



        public decimal TotalPrice()
        {
            return this.cart.Sum(x => x.Price);
        }
    }
}
