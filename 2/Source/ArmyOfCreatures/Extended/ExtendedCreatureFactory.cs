using ArmyOfCreatures.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Extended.Creatures;
using System.Globalization;

namespace ArmyOfCreatures.Extended
{
    class ExtendedCreatureFactory: CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "Goblin": return new Goblin();
                case "AncientBehemoth": return new AncientBehemoth();
                case "CyclopsKing" :return new CyclopsKing();
                case "Griffin": return new Griffin();
                case "WolfRaider": return new WolfRaider();
                default: return base.CreateCreature(name);
                   
                    
            }
        }
    }
}
