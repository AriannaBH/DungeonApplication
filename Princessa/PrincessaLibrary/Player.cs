using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessaLibrary
{
    public sealed class Player : Character
    {
        //fields

        //props
        public Roles CharacterRole { get; set; }
        public Weapon UserPower { get; set; }

        //ctors
        public Player(string name, int hitChance, int block, int startHealth, int maxHealth, Roles characterRole, Weapon userPower)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            StartHealth = startHealth;
            MaxHealth = maxHealth;
            CharacterRole = characterRole;
            UserPower = userPower;

            switch (CharacterRole)
            {
                case Roles.Villager:
                    HitChance += 8;
                    StartHealth += 100;
                    break;
                case Roles.Worker:
                    HitChance += 12;
                    StartHealth += 100;
                    break;
                case Roles.Priest:
                    HitChance += 15;
                    StartHealth += 100;
                    break;
                case Roles.Ranger:
                    HitChance += 20;
                    StartHealth += 100;
                    break;
                case Roles.Mage:
                    HitChance += 15;
                    StartHealth += 100;
                    break;
                case Roles.Warrior:
                    HitChance += 30;
                    StartHealth += 100;
                    break;
                case Roles.Pirate:
                    HitChance += 25;
                    StartHealth += 100;
                    break;
                case Roles.Ninja:
                    HitChance += 40;
                    StartHealth += 100;
                    break;
                case Roles.Giant:
                    HitChance += 50;
                    StartHealth += 100;
                    break;
                default:
                    break;
            }
        }

        //methods
        public override string ToString()
        {
            string description = "";

            switch (CharacterRole)
            {
                case Roles.Villager:
                    description = "The villager is not meant to fight, but when needed you must push on!";
                    break;
                case Roles.Worker:
                    description = "A worker's axe has poor range, but still deals a fair amount of damage.";
                    break;
                case Roles.Priest:
                    description = "A priest is designed to heal others, can you rescue the princess by healing yourself?";
                    break;
                case Roles.Ranger:
                    description = "Just like the mage you require a distanced fight, but you have greater power.";
                    break;
                case Roles.Mage:
                    description = "A mage does not need to get close to your opponent, so you won't get damages as much, lucky you, am I right!?";
                    break;
                case Roles.Warrior:
                    description = "As a warrior you are a powerhouse, prepare to deal great damage!";
                    break;
                case Roles.Pirate:
                    description = "As a pirate you have bombs to attack and or your pistol of course..use it all wisely...";
                    break;
                case Roles.Ninja:
                    description = "A ninja, holder of the greatest skills ever to be achieved...always silent yet deadly.";
                    break;
                case Roles.Giant:
                    description = "Fe Fi Fo Fum, You are a very big big one...stomp away your enimies giant.";
                    break;
                default:
                    break;
            }
            return string.Format("---- {0} ----\nHealth: {1} of {2}\nHit Chance: {3}\nMax Power: {4}\nBlock: {5}\nDescription: {6}",
                Name,
                StartHealth,
                MaxHealth,
                EstHitChance(),
                UserPower,
                Block,
                description);
        }

        public override int EstHitChance()
        {
            return base.EstHitChance() + 1;
        }

        public override int EstDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(UserPower.MinDamage, UserPower.MaxDamage + 1);
            return damage;
        }
    }
}
