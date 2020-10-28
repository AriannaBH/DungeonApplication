using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessaLibrary
{
    public class Opponent : Character
    {
        //fields
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public string Description { get; set; }


        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than MaxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //ctors
        public Opponent() { } //default ctor
        public Opponent(string name, int startHealth, int maxHealth, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxHealth = maxHealth;
            MaxDamage = maxDamage;
            Name = name;
            StartHealth = startHealth;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("---- OPPONENT ----\nMonster Type: {0}\nHealth: {1} of {2}\nPower: {3} to {4}\nBlock: {5}\nDescription: {6}",
                Name,
                StartHealth,
                MaxHealth,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int EstDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }
    }
}
