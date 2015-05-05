using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class Bulletmancer
        :PlayerCharacter
    {
        public Bulletmancer(Random rand)
            : base(rand)
        {
            classType = EClassType.Bulletmancer;
            className = "Bulletmancer";

            hp = 75;
            maxHp = 75;
            counter = 0;
            speed = 12;
            baseSpeed = 12;
            power = 12;
            defence = 7;

            ability2Target = "multiple";
            SetActions();
        }

        public Bulletmancer(Random rand, string name)
            : base(rand, name)
        {
            classType = EClassType.Bulletmancer;
            className = "Bulletmancer";

            hp = 75;
            maxHp = 75;
            counter = 0;
            speed = 12;
            baseSpeed = 12;
            power = 12;
            defence = 7;

            ability2Target = "multiple";
            SetActions();
        }

        public override string Ability1(BaseCharacter target)
        {
 	        //Rapid Fire, hits same enemy many times
            int damage = target.TakeDamage(rand.Next(power/4, power/2));
            Counter -= 10;
            Ability1Timer = 3;
            return name + " uses Rapid Fire on " + target.Name + " and inflicts " + damage + " damage.";
        }
        public override string Ability2(List<PlayerCharacter> allies, List<BaseCharacter> enemies)
        {
 	        //Scattershot, hit many targets 
            int damage = (rand.Next(power / 2, power + 1));

            foreach (BaseCharacter enemy in enemies)
            {
                enemy.TakeDamage(damage);
            }
            counter -= 100;
            ability2Timer = 4;
            return name + " uses Scattershot. All enemies take " + damage + " damage.";
        }

        public override void LevelUp()
        {
            maxHp += 10;
            hp = maxHp;
            baseSpeed += 2;
            speed = baseSpeed;
            counter = 0;
            power += 3;
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
            ability1Name = "Rapid Fire";
            ability1Description = "Quickly shoots an enemy for lower damage. Reduces counter by 10 instead of 100.\r\n" +
                "Base Damage: " + power / 4 + "-" + power / 2 + "\r\n" +
                "Cooldown: 3 turns";
            ability2Name = "Scattershot";
            ability2Description = "Wide spreading Buckshot hits all enemies.\r\n" +
            "Base Damage: " + power / 2 + "-" + power + "\r\n" +
            "Cooldown: 4 turns";

            ability1Timer = 0;
            ability2Timer = 0;
        }
    }
}
