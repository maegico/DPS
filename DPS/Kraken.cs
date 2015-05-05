using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class Kraken
        :BaseCharacter
    {
        #region Fields

        KrakenBaby m_cKrakenBaby;

        #endregion

        #region Constructor

        public Kraken(Random rand)
            : base(rand, EClassType.Kraken, "Balof", 250, 8, 18, 7)
        {
        }

        #endregion

        #region Abilities

        /// <summary>
        /// Wade in Water
        /// the method returns a value of 3
        /// the ability reduces specific character's speed by 3
        /// </summary>
        /// <returns>amount to decrease speed by</returns>
        public override string Ability1(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            foreach (PlayerCharacter character in ally)
            {
                if (!character.Slowed)
                {
                    character.Slowed = true;
                    character.Speed -= 3;
                }

                character.SlowCounter = 10;
                Counter -= 100;
            }

            return name + " uses Wade in Water. Entire party is slowed by 3 for 10 rounds.";
        }

        /// <summary>
        /// Water Spittle
        /// returns a random int between (power / 2) and (power + 1) and ocercomes target's defences
        /// A stronger version of his normal attack,
        /// the spittle from his mouth is so acidic that it pierces armor
        /// </summary>
        /// <returns>amount of damage to deal</returns>
        public string Ability2(List<PlayerCharacter> ally)
        {
            int target = rand.Next(0, ally.Count);
            int waterSpittle = rand.Next(power / 2, power + 1) + (ally[target].Defence / 3);
            ally[target].Hp -= waterSpittle;
            counter -= 100;

            return name + " uses Water Spittle. The acidic spittle eats through " + ally[target].Name + "'s armor to deal " + waterSpittle + " damage.";
        }

        /// <summary>
        /// The Oceans Rage & The Waters Turn
        /// returns nothing, but increases power
        /// the ability increases the power of the Kraken by 1 permanently
        /// </summary>
        /// <returns></returns>
        public string Ability3()
        {
            this.power += 1;
            counter -= 100;

            return name + " rages, increasing it's power by 1. You made that Kraken angry, good for you.";
        }

        /// <summary>
        /// Depths of the Ocean
        /// The method creates a Baby Kraken,
        /// but for the ability in game the method should be called twice
        /// </summary>
        /// <returns>0</returns>
        public string Ability4(List<BaseCharacter> enemy)
        {
            m_cKrakenBaby = new KrakenBaby(this.rand);
            enemy.Add(m_cKrakenBaby);
            counter -= 100;

            return name + " used Depths of the Ocean. It gave birth and now you must face a Kraken Baby. Mwahahaha. It is a bad parent.";
        }

        public override string Attack(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            int randNum = rand.Next(1, 101);

            if (randNum > 90)
            {
                return Ability1(ally, enemy);
            }
            else if (randNum > 60)
            {
                return Ability2(ally);
            }
            else if (randNum > 50)
            {
                return Ability3();
            }
            else if (randNum > 10 && enemy.Count() > 0 && enemy.Count() < 3)
            {
                return Ability4(enemy);
            }
            else
            {
                return Attack(ally[rand.Next(0, ally.Count)]);
            }
            
        }

        #endregion
    }
}
