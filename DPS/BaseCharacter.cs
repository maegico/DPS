using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    public abstract class BaseCharacter
    {
        #region Fields

        protected Random rand;

        protected EClassType classType;
            /*Classes:
             * shadowDancer, - melee, magic, fast
             *psionicArcher, - ranged, magic, fast
             *shockyJocky, - melee, tech, fast
             *bulletmancer, - ranged, tech, fast
             *spiritSwordsman, - melee, magic, slow
             *scorcher, - ranged, magic, slow
             *cyberEnforcer, - melee, tech, slow
             *streetSamurai, - ranged, tech, slow
             *kraken, - Kraken
             *spawn - Kraken Baby*/

        protected string name;
        protected string className;

        //below uses base 100
        protected int hp;
        protected int maxHp;
            //counter relates to speed
        protected int counter;

        //below uses base 10
        protected int speed;
        protected int baseSpeed;
        protected int power;
        protected int defence;

        protected string ability1Name;
        protected string ability2Name;

        protected int ability1Timer;
        protected int ability2Timer;

        protected bool slowed;
        protected bool burned;
        protected bool bleed;
        protected int slowCounter;
        protected int burnCounter;
        protected int bleedCounter;
        #endregion

        #region Properties

        public EClassType ClassType
        {
            get { return classType; }
            set { classType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ClassName
        {
            get { return className; }
        }

        public int Hp
        {
            get { return hp; }
            set
            {
                if (value < 0)
                {
                    hp = 0;
                }
                else if(value > maxHp)
                {
                    hp = maxHp;
                }
                else
                {
                    hp = value;
                }
            }
        }

        public int MaxHp
        {
            get { return maxHp; }
        }

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int BaseSpeed
        {
            get { return baseSpeed; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        public string Ability1Name
        {
            get { return ability1Name; }
            set { ability1Name = value; }
        }

        public string Ability2Name
        {
            get { return ability2Name; }
            set { ability2Name = value; }
        }

        public int Ability1Timer
        {
            get { return ability1Timer; }
            set
            {
                if (value < 0)
                    ability1Timer = 0;
                else
                    ability1Timer = value;
            }
        }

        public int Ability2Timer
        {
            get { return ability2Timer; }
            set
            {
                if (value < 0)
                    ability2Timer = 0;
                else
                    ability2Timer = value;
            }
        }

        public bool Slowed
        {
            get { return slowed; }
            set { slowed = value; }
        }

        public int SlowCounter
        {
            get { return slowCounter; }
            set
            {
                if (value >= 0)
                    slowCounter = value;
            }
        }

        public bool Burned
        {
            get { return burned; }
            set { burned = value; }
        }

        public int BurnCounter
        {
            get { return burnCounter; }
            set 
            {
                if (value >= 0)
                burnCounter = value;
            }
        }

        public bool Bleed
        {
            get { return bleed; }
            set { bleed = value; }
        }

        public int BleedCounter
        {
            get { return bleedCounter; }
            set 
            { 
                bleedCounter = value; 
            }
        }

        #endregion

        #region Constructors

        //default non paramatized constructor
        /// <summary>
        /// A Default Constructer
        /// </summary>
        public BaseCharacter()
        {
            rand = new Random();

            classType = EClassType.ShadowDancer;
            className = "Class0";

            // Action Names
            ability1Name = "Ability 1";
            ability2Name = "Ability 2";
            ability1Timer = 0;
            ability2Timer = 0;

            name = "you done fucked up now";
            hp = 100;
            maxHp = 100;
            counter = 0;
            baseSpeed = 10;
            speed = 10;
            power = 10;
            defence = 10;
        }

        /// <summary>
        /// A Parameterized Constructer
        /// </summary>
        /// <param name="_name">the name</param>
        /// <param name="_hp"> the health</param>
        /// <param name="ctr">the number of counters</param>
        /// <param name="spd">the speed</param>
        /// <param name="pwr">the power/attack strength</param>
        /// <param name="def">the defence</param>
        /// <param name="rand">the Random class that needs to be instantiated</param>
        public BaseCharacter(Random rand, EClassType classType, string _name, int _maxHp, int _basespd, int pwr, int def)
        {
            this.rand = rand;

            this.classType = classType;
            className = "Class0";

            // Action Names
            ability1Name = "Ability 1";
            ability2Name = "Ability 2";
            ability1Timer = 0;
            ability2Timer = 0;

            name = _name;
            maxHp = _maxHp;
            hp = maxHp;
            counter = 0;
            baseSpeed = _basespd;
            speed = baseSpeed;
            power = pwr;
            defence = def;
        }

        #endregion

        #region Methods

        //attack method shell
        /// <summary>
        /// Calculates base damage.
        /// </summary>
        /// <returns>int damage (before defence)</returns>
        public virtual int Attack()
        {
            int damage = rand.Next(power / 2, power + 1);
            return damage;
        }

        /// <summary>
        /// Basic attack on a target enemy. Deals damage to the enemy and reduces attacker's counter.
        /// </summary>
        /// <param name="target">Takes a BaseCharacter as a target. Target is set by button push.</param>
        /// <returns>String description of what happened to place in combat log.</returns>
        public virtual string Attack(BaseCharacter target)
        {
            int damage = target.TakeDamage(Attack());
            Counter -= 100;
            return name + " hits " + target.Name + " for " + damage + " damage.";
        }

        /// <summary>
        /// Initiates an attack made by an enemy. Rolls chance for each action. If an ability indicated by chance is off cooldown, execute. Otherwise, execute attack.
        /// </summary>
        /// <param name="ally">List of allies. Can affect any player-side character.</param>
        /// <param name="enemy">List of enemies. Can affect any computer-side character.</param>
        /// <returns>String description of what happened to place in combat log.</returns>
        public virtual string Attack(List<PlayerCharacter> ally, List<BaseCharacter> enemy)
        {
            int chance = rand.Next(0, 100);
            if (chance < 50 && ability1Timer == 0)
                return Ability1(ally, enemy);
            else
            {
                int target = rand.Next(0, enemy.Count);
                while (enemy[target].classType == classType)
                    target = rand.Next(0, enemy.Count);
                return Attack(enemy[target]);
            }
        }

        /// <summary>
        /// Takes damage. If damage is lower than 0, make 0.
        /// </summary>
        /// <param name="damage">int base damage</param>
        /// <returns>int damage to be dealt to character</returns>
        public int TakeDamage(int damage)
        {
            int damage2 = damage - (defence / 3);
            if (damage2 < 0)
                damage2 = 0;
            Hp -= damage2;
            return damage2;
        }

        //ability method shells
        abstract public string Ability1(List<PlayerCharacter> ally, List<BaseCharacter> enemy);
        
        //IsDead method shell
        public bool IsDead()
        {
            if (hp == 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
