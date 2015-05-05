using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class CyberEnforcer
        :PlayerCharacter
    {
        public CyberEnforcer(Random rand)
            : base(rand)
        {
            classType = EClassType.CyberEnforcer;
            className = "Cyber Enforcer";

            hp=125;
            maxHp=125;
            counter=0;
            speed=6;
            baseSpeed=6;
            power=12;
            defence=10;

            ability2Target = "multiple";
            SetActions();
        }

        public CyberEnforcer(Random rand, string name)
            : base(rand, name)
        {
            classType = EClassType.CyberEnforcer;
            className = "Cyber Enforcer";

            hp = 125;
            maxHp = 125;
            counter = 0;
            speed = 6;
            baseSpeed = 6;
            power = 12;
            defence = 10;

            ability2Target = "multiple";
            SetActions();
        }

        public override string Ability1(BaseCharacter target)
        {
            //stun ability with improved damage
            int damage = target.TakeDamage(power);
            target.Speed = 1;
            target.Slowed = true;
            target.SlowCounter = 5;
            Counter -= 100;
            Ability1Timer = 4;
            return name + " uses Cyber Slam on " + target.Name + ", inflicting " + damage + " damage and stunning.";
        }
        public override string Ability2(List<PlayerCharacter> allies, List<BaseCharacter> enemies)
        {
            //big swing multi hit ability
            int damage = (rand.Next(power / 2, (power + 1)));
            
            foreach (BaseCharacter enemy in enemies)
            {
                enemy.TakeDamage(damage);
            }
            Counter -= 100;
            Ability2Timer = 3;
            return name + " uses Big Swinger. All enemies take " + damage + " damage.";
        }

        public override void LevelUp()
        {
            maxHp += 0;
            hp = maxHp;
            baseSpeed += 1;
            speed = baseSpeed;
            counter = 0;
            power += 3;
            defence += 5;

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
            ability1Name = "Cyber Slam";
            ability1Description = "Deals the full potential of the Cyber Enforcer's power and stuns the target!\r\n" +
                "Base Damage: " + power + " | Enemy stunned for 5 rounds. Allows minimal movement.\r\n" +
                "Cooldown: 4 turns";
            ability2Name = "Big Swinger";
            ability2Description = "Large arching swing hitting all enemies.\r\n" +
                "Base Damage: " + power/2 + "-" + (power) + "\r\n" +
                "Cooldown: 3 turns";

            ability1Timer = 0;
            ability2Timer = 0;
        }
    }
}
