using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using System.Globalization;

namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            this.rounds = rounds;
        }

        //public int Rounds
        //{
        //    get
        //    {
        //        return this.rounds;
        //    }

        //  private  set
        //    {
        //        if (!(value>0) || value>10 )
        //        {
        //            throw new ArgumentException("Rounds cannot be negative number.");
        //        }

        //        this.rounds = value;
        //    }
        //}



        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }



        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, 
            ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds>0)
            {
                return currentDamage *2.0M;
            }

            this.rounds--;
            return currentDamage;

        }
    }
}
