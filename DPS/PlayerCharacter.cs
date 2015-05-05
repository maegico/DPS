using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    public class PlayerCharacter
        :BaseCharacter
    {
        #region Fields

        protected string attackDescription;
        protected string ability1Description;
        protected string ability2Description;

        protected string ability1Target;
        protected string ability2Target;

        /* Targets work as such:
         * "allies" means player targets one ally with the ability.
         * "enemies" means player targets one enemy with the ability.
         * "both" means player targets any one character with the ability.
         * "allAllies" targets all allies with ability when ability is selected.
         * "allEnemies" targets all enemies with ability when ability is selected.
         * "all" targets all characters on the field of play when ability is selected.
         */

        #endregion

        #region Properties

        public string AttackDescription
        {
            get { return attackDescription; }
        }

        public string Ability1Description
        {
            get { return ability1Description; }
        }

        public string Ability2Description
        {
            get { return ability2Description; }
        }

        public string Ability1Target
        {
            get { return ability1Target; }
        }

        public string Ability2Target
        {
            get { return ability2Target; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Levels the character.
        /// </summary>
        public virtual void LevelUp()
        {
            //Improve Attributes
            maxHp += 10;
            hp = maxHp;
            baseSpeed += 1;
            speed = baseSpeed;
            counter = 0;
            power += 5;
            defence += 5;

            // Reset Ailments
            slowed = false;
            slowCounter = 0;
            burned = false;
            BurnCounter = 0;
            bleed = false;
            bleedCounter = 0;

            // Reset Actions
            attackDescription = "Attack the enemy.\r\n" +
                "Base Damage: " + power / 2 + "-" + power;
            ability1Description = "Deals half damage. Penetrates enemy's defence.\r\n" +
                "Base Damage: " + power / 4 + "-" + power / 2;
            ability2Description = "Activate ability2.\r\n" +
                "Base Damage: ?\r\n" +
                "Other Effects: ?";
            ability1Timer = 0;
            ability2Timer = 0;
        }

        //single target abilities
        /// <summary>
        /// Causes something to happen to the target. Lowers counter of attacker. Sets ability cooldown.
        /// </summary>
        /// <param name="target">An enemy target chosen by the player.</param>
        /// <returns>String description of what happens to display in combat log.</returns>
        public virtual string Ability1(BaseCharacter target)
        {
            int damage = target.TakeDamage(rand.Next(power / 4, power / 2 + 1) + (target.Defence / 3));
            target.Bleed = true;
            target.BleedCounter = 5;
            Counter -= 100;
            Ability1Timer = 2;
            return name + " uses Penetrating Blow on " + target.Name + ", causing bleeding and " + damage + " damage.";
        }

        /// <summary>
        /// For use by computer. Sets a target and executes Ability1 for it
        /// </summary>
        /// <param name="ally">List of allies. Can affect allies.</param>
        /// <param name="enemy">List of enemies. Can affect enemies.</param>
        /// <returns>String description of what happens to display in combat log.</returns>
        public override string Ability1(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
                int target = rand.Next(0, enemy.Count);
                while (enemy[target].ClassType == classType)
                    target = rand.Next(0, enemy.Count);
                return Ability1(enemy[target]);
        }

        //multi target abilities
        /// <summary>
        /// Causes something to happen to the target. Lowers counter of attacker. Sets ability cooldown.
        /// Parameter can also be set to one or both lists, depending on what shall be targeted.
        /// </summary>
        /// <param name="target">An enemy target chosen by the player.</param>
        /// <returns>String description of what happens to display in combat log.</returns>
        public virtual string Ability2(BaseCharacter target)
        {
            return "";
        }

        public virtual string Ability2(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            return "";
        }

        /// <summary>
        /// Sets action descriptions and names. Resets cooldown timers. - Called in every constructor and in LevelUp();
        /// </summary>
        public virtual void SetActions()
        {
            //Action Names and Descriptions
            attackDescription = "Attack the enemy.\r\n" +
                "Base Damage: " + power / 2 + "-" + power;
            ability1Name = "Penetrating Blow";
            ability1Description = "Deals half damage. Penetrates enemy's defence.\r\n" +
                "Base Damage: " + power / 4 + "-" + power / 2;
            ability2Name = "Ability 2";
            ability2Description = "Activate ability2.\r\n" +
                "Base Damage: ?\r\n" +
                "Other Effects: ?";

            //Set ability cooldown timers to 0
            ability1Timer = 0;
            ability2Timer = 0;
        }

        #endregion

        #region Constructor

        public PlayerCharacter()
            : base()
        {
            //Ability Targets - "allies" to manually choose allies
            ability1Target = "enemies";
            ability2Target = "enemies";
            SetActions();
        }

        public PlayerCharacter(Random rand)
            : base()
        {
            this.rand = rand;

            //Abilities
            ability1Target = "enemies";
            ability2Target = "enemies";
            SetActions();

            //Creates a random name
            int nameInt = rand.Next(0, 26);
            switch (nameInt)
            {
                case 0:
                    name = "Alfredo";
                    break;

                case 1:
                    name = "Bongo";
                    break;

                case 2:
                    name = "Caswell";
                    break;

                case 3:
                    name = "Drako";
                    break;

                case 4:
                    name = "Emmanuel";
                    break;

                case 5:
                    name = "Fred";
                    break;

                case 6:
                    name = "Giovanni";
                    break;

                case 7:
                    name = "Hilda";
                    break;

                case 8:
                    if (classType == EClassType.Scorcher) // Ivellian is a mage.
                        name = "Ivellian";
                    else
                        name = "Ivan";
                    break;

                case 9:
                    name = "Jillian";
                    break;

                case 10:
                    name = "Kathleen";
                    break;

                case 11:
                    name = "Lars";
                    break;

                case 12:
                    name = "Martha";
                    break;

                case 13:
                    name = "Natalie";
                    break;

                case 14:
                    name = "Oscar";
                    break;

                case 15:
                    name = "Parthe";
                    break;

                case 16:
                    name = "Quagmire";
                    break;

                case 17:
                    name = "Refearian";
                    break;

                case 18:
                    name = "Sean";
                    break;

                case 19:
                    name = "Terra";
                    break;

                case 20:
                    name = "Udela";
                    break;

                case 21:
                    name = "Veronica";
                    break;

                case 22:
                    name = "Wyatt";
                    break;

                case 23:
                    name = "Xavier";
                    break;

                case 24:
                    name = "Yue";
                    break;

                case 25:
                    name = "Zendaya";
                    break;
            }
        }

        public PlayerCharacter(Random rand, string name)
            : base()
        {
            classType = EClassType.ShadowDancer;
            this.rand = rand;

            //Abilities
            ability1Target = "enemies";
            ability2Target = "enemies";
            SetActions();

            this.name = name;
        }

        public PlayerCharacter(Random rand, EClassType classType, string _name, int _maxHp, int baseSpd, int pwr, int def)
            : base(rand, classType, _name, _maxHp, baseSpd, pwr, def)
        {
            //Abilities
            ability1Target = "enemies";
            ability2Target = "enemies";
            SetActions();
        }

        #endregion
    }
}
