using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{


    //    Categories should implement ICategory.Adding the same product to one category more than once is allowed.
    //    Minimum category name’s length length is 2 symbols and maximum is 15 symbols.
    //    The error message should be "Category name must be between {min} and {max} symbols long!".
    //    Products in category should be sorted by brand in ascending order and then by price in descending order.
    //    When removing product from category, if the product is not found, the error message should be 
    //    "Product {product name} does not exist in category {category name}!". 
    //    Category’s print method should return text in the following format:

    class Category : ICategory
    {
        private const int minLength = 2;
        private const int maxLength = 15;

        private string name;
        private ICollection<IProduct> products;


        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,string
                    .Format( GlobalErrorMessages.StringCannotBeNullOrEmpty,"Category name"));

                Validator.CheckIfStringLengthIsValid(value, 15, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15));

                this.name = value;


            }
        }

        public ICollection<IProduct> Products
        {
            get
            {
                return new List<IProduct>(this.products);
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        

        }

        public string Print()
        {

            var result = new StringBuilder();
           // string form = this.products.Count > 1 ? "products":"product";

            result.AppendLine(string.Format("{0} category - {1} {2} in total",
                this.name, this.products.Count, this.products.Count==1?"product":"products"));

            var sortedProducts = this.products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);

            foreach (var prod in sortedProducts)
            {
                result.AppendLine(prod.Print());
            }

            return result.ToString().Trim(); 
            
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!"
                    , cosmetics.Name, this.Name));
            }

            this.products.Remove(cosmetics);
        }


       
    }
}
