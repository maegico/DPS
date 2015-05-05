using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class ShadowDancer
        :PlayerCharacter
    {
        public ShadowDancer(Random rand)
            : base(rand)
        {
            classType = EClassType.ShadowDancer;
            className = "Shadow Dancer";

            hp=80;
            maxHp=80;
            counter=0;
            speed=12;
            baseSpeed=12;
            power=10;
            defence=7;

            ability2Target = "multiple";
            SetActions();
        }

        public ShadowDancer(Random rand, string name)
            : base(rand, name)
        {
            classType = EClassType.ShadowDancer;
            className = "Shadow Dancer";

            hp = 80;
            maxHp = 80;
            counter = 0;
            speed = 12;
            baseSpeed = 12;
            power = 10;
            defence = 7;

            ability2Target = "multiple";
            SetActions();
        }

        public override string Ability1(BaseCharacter target)
        {
 	        //We'll just use Penetrating Blow 
            return base.Ability1(target);
        }

        public override string Ability2(List<PlayerCharacter> allies, List<BaseCharacter> enemies)
        {
            //all allies targeted heal or medicine
            int heal = (rand.Next(power / 2, power + 1)) * 2;
            foreach (BaseCharacter ally in allies)
            {
                ally.Hp += heal;
            }
            Counter -= 100;
            Ability2Timer = 2;
            return name + " uses Group Medicine. All allies heal " + heal + " health.";
        }

        public override void LevelUp()
        {
            maxHp += 20;
            hp = maxHp;
            baseSpeed += 3;
            speed = baseSpeed;
            counter = 0;
            power += 2;
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
            ability1Name = "Penetrating Blow";
            ability1Description = "Deals half damage. Penetrates enemy's defence and causes bleeding.\r\n" +
                "Base Damage: " + power / 4 + "-" + power / 2 + " | Target bleeds for 5 turns.\r\n" +
                "Cooldown: 2 turns";
            ability2Name = "Group Medicine";
            ability2Description = "Releases a healing mist that heals all allies for " + power + "-" + power*2 + " health.\r\n" +
                "Cooldown: 2 turns";

            ability1Timer = 0;
            ability2Timer = 0;
        }
    }
}
