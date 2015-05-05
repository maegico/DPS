using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class KrakenBaby
        :BaseCharacter
    {
        #region Constructor

        public KrakenBaby(Random rand)
            : base(rand, EClassType.Spawn, "Balos", 30, 20, 10, 10)
        {
        }

        #endregion

        public override string Attack(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            return Attack(ally[rand.Next(0, ally.Count)]);
        }

        #region Abilities Not in Use

        public override string Ability1(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            return "What?";
        }

        #endregion
    }
}
