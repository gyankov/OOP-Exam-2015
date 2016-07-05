using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleAttackWhenAttacking:Specialty
    {

        private  int rounds;


        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds<=0)
            {
                throw new ArgumentException("rounds", "The number of rounds should be greater than 0");
            }

            this.rounds = rounds;
        }


        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }



        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty==null)
            {
                throw new ArgumentException("attackerWithSpecialty");
            }

            if (defender==null)
            {
                throw new ArgumentException("defender");
            }

            if (this.rounds<=0)
            {
                return;
            }


            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }
    }
}
