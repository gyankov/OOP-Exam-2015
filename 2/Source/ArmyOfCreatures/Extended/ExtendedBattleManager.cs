﻿using ArmyOfCreatures.Logic.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Extended
{
    class ExtendedBattleManager : BattleManager
    {

        private readonly ICollection<ICreaturesInBattle> thirdArmy;

        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger) 
            : base(creaturesFactory, logger)
        {
            this.thirdArmy = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier.ArmyNumber==3)
            {
                this.thirdArmy.Add(creaturesInBattle);
            }
            else
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
            }
        }


        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber==3)
            {
                return this.thirdArmy.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            return base.GetByIdentifier(identifier);
        }
    }
}
