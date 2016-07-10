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
    class AddAttackWhenSkip : Specialty
    {
        private int addAttack;

        public AddAttackWhenSkip(int addAttack)
        {
            if (addAttack<1 || addAttack>10)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.addAttack = addAttack;
        }


        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.addAttack;
        }


        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.addAttack);
        }
    }
}
