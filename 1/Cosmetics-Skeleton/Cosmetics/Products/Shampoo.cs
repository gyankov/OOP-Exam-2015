using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Shampoo : Product, IShampoo
    {
        //All shampoos should implement the IShampoo interface. 
        //Shampoo’s price is given per milliliter.Usage type can be “EveryDay” or “Medical”.

        private uint milliliters;
        private UsageType usage;
        

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price *= this.Milliliters;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

           private  set
            {
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Usage"));

                this.usage = value;
            }
        }

        public override string Print()
        {

            var result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(string.Format("  * Usage: {0}", this.Usage));

            return result.ToString().Trim();
            
        }
    }
}
