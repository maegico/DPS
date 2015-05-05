using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    abstract class BaseCharacter
    {
        #region Fields

        protected List<BaseCharacter> ally;
        protected List<BaseCharacter> enemy;
        protected Random rand;
        protected int target;

        protected string name;

        //below uses base 100
            //base stats that we agreed on
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

        bool dead = false;

        protected bool slowed;
        protected bool burned;
        protected bool bleed;
        protected int slowCounter;
        protected int burnCounter;
        protected int bleedCounter;
        #endregion

        #region Properties
        
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
            set { maxHp = value; }
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
            set { baseSpeed = value; }
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
        public bool Slowed
        {
            get { return slowed; }
            set { slowed = value; }
        }
        public int SlowCounter
        {
            get { return slowCounter; }
            set { slowCounter = value; }
        }
        public bool Burned
        {
            get { return burned; }
            set { burned = value; }
        }
        public int BurnCounter
        {
            get { return burnCounter; }
            set { burnCounter = value; }
        }
        public bool Bleed
        {
            get { return bleed; }
            set { bleed = value; }
        }
        public int BleedCounter
        {
            get { return bleedCounter; }
            set { bleedCounter = value; }
        }
        #endregion

        #region Constructors

        //default non paramatized constructor
        /// <summary>
        /// A Default Constructer
        /// </summary>
        public BaseCharacter()
        {
            ally = new List<BaseCharacter>();
            enemy = new List<BaseCharacter>();
            rand = new Random();

            target = rand.Next(0, ally.Count());

            name = "you done fucked up now";
            hp = 100;
            maxHp = 100;
            counter = 0;
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
        public BaseCharacter(string _name, int _maxHp, int _hp, int spd, int pwr, int def, Random rand, EClassType classType)
        {
            ally = new List<BaseCharacter>();
            enemy = new List<BaseCharacter>();
            this.rand = rand;

            target = rand.Next(0, ally.Count());

            name = _name;
            hp = _hp;
            maxHp = _maxHp;
            counter = 0;
            speed = spd;
            power = pwr;
            defence = def;
        }

        #endregion

        #region Methods

        //attack method shell
        //public virtual int Attack()
        //{
        //    return rand.Next(power / 2, power + 1);
        //}
        public virtual void Attack(BaseCharacter character)
        {
            character.hp =- rand.Next(power / 2, power + 1);
        }

        //take damage method
        public int TakeDamage(int damage)
        {
            return damage - (defence / 2);
        }

        //ability method shells
        abstract public void Ability1();
        abstract public void Ability2();
        abstract public void Ability2(BaseCharacter character);
        
        //IsDead method shell
        public bool IsDead()
        {
            if (hp == 0)
            { dead = true; }
            return dead;
        }

        #endregion
    }
}
