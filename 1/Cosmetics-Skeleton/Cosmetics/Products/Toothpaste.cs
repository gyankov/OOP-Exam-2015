using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    //    All toothpastes should implement the IToothpaste interface.
    //    Ingredients should be represented as text, joined in their order of addition,
    //    separated by “, “ (comma and space). Each ingredient name’s length should be between 4 and 12 symbols, inclusive.
    //    The error message should be "Each ingredient must be between {min} and {max} symbols long!".


    class Toothpaste : Product, IToothpaste
    {
        private string ingredients;


        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) 
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;

        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Ingredients"));

                if (!CheckIngredientsLength(value))
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Each ingredient must be between {0} and {1} symbols long!", 4, 12));
                }

                this.ingredients = value;

            }
        }

        private static bool CheckIngredientsLength(string ingredients)
        {
            var result = true;

            var ingr = ingredients.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in ingr)
            {
                if (item.Length<4 || item.Length>12)
                {
                    result = false;
                }
            }

            return result;
        }

        public override string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString().Trim();


        }
    }
}
