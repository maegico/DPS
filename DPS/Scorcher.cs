using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class Scorcher
        :PlayerCharacter
    {
        public Scorcher(Random rand)
            : base(rand)
        {
            classType = EClassType.Scorcher;
            className = "Scorcher";

            hp=100;
            maxHp=100;
            counter=0;
            speed=10;
            baseSpeed=10;
            power=10;
            defence=5;

            ability2Target = "multiple";
            SetActions();
        }

        public Scorcher(Random rand, string name)
            : base(rand, name)
        {
            classType = EClassType.Scorcher;
            className = "Scorcher";

            hp = 100;
            maxHp = 100;
            counter = 0;
            speed = 10;
            baseSpeed = 10;
            power = 10;
            defence = 5;

            ability2Target = "multiple";
            SetActions();
        }

        public override string Ability1(BaseCharacter target)
        {
            //Extra Crispy! very high powered burn, also set target on fire
            int damage = target.TakeDamage(power*2);
            Counter -= 100;
            Ability1Timer = 6;
            target.Burned = true;
            target.BurnCounter = power;
            return name + " uses Extra Crispy! on " + target.Name + " inflicting " + damage + " damage and setting "+ target.Name +" ablaze!";
        }
        public override string Ability2(List<PlayerCharacter> allies, List<BaseCharacter> enemies)
        {
            //Smells like BACON! 
            int damage = (rand.Next(power/4, power/2 + 1));

            foreach (BaseCharacter enemy in enemies)
            {
                enemy.TakeDamage(damage);
                enemy.Burned = true;
                enemy.BurnCounter = power/4;
            }
            Counter -= 100;
            Ability2Timer = 3;
            return name + " uses Smells like BACON! All enemies take " + damage + " damage and are set ablaze!";
        }

        public override void LevelUp()
        {
            maxHp += 10;
            hp = maxHp;
            baseSpeed += 2;
            speed = baseSpeed;
            counter = 0;
            power += 5;
            defence += 3;

            slowed = false;
            slowCounter = 0;
            burned = false;
            BurnCounter = 0;
            bleed = false;
            bleedCounter = 0;

            SetActions();
        }

        public override void SetActions()
        {
            attackDescription = "Attack the enemy.\r\n" +
               "Base Damage: " + power / 2 + "-" + power;
            ability1Name = "Extra Crispy!";
            ability1Description = "Completely roasts the target, setting it ablaze!\r\n" +
            "Base Damage:" + power*2 + " | Target Burned for " + power + " turns\r\n" +
            "Cooldown: 6 turns";
            ability2Name = "Smells like BACON!";
            ability2Description = "Torch all your foes and set them on fire!\r\n" +
            "Base Damage: " + power / 4 + "-" + power / 2 + " | All enemies Burned for " + power/4 + " turns\r\n" +
            "Cooldown: 3 turns";

            ability1Timer = 0;
            ability2Timer = 0;
        }
    }
}
