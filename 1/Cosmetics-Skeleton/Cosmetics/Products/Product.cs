using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    class Product : IProduct
    {


        //    All products should implement the IProduct interface. 
        //    Minimum product name’s length is 3 symbols and maximum is 10 symbols.
        //    The error message should be "Product name must be between {min} and {max} symbols long!".
        //    Minimum brand name’s length is 2 symbols and maximum is 10 symbols.
        //    The error message should be "Product brand must be between {min} and {max} symbols long!". 
        //    Gender type can be “Men”, “Women” or “Unisex”. 

        private string brand;
        private GenderType gender;
        private string name;
        private decimal price;


        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

           protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, 
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Brand"));

                Validator.CheckIfStringLengthIsValid(value, 10, 2, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));

                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
          protected  set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Gender"));
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

          protected  set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));

                Validator.CheckIfStringLengthIsValid(value, 10, 3,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

          protected  set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be zero or negative");
                }
                this.price = value;
            }
        }

        public virtual string Print()
        {

            var result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString().Trim();

           
        }
    }
}
