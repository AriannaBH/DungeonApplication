using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrincessaLibrary; //added

namespace PrincessaMonsters
{
    public class Dragon : Opponent
    {
        //no fields
        //props
        public bool IsFire { get; set; }
        

        //ctors
        //FQCtor
        public Dragon(string name, int startHealth, int maxHealth, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFire) :base(name, startHealth, maxHealth, hitChance, block, minDamage, maxDamage, description)
        {
            IsFire = isFire;
        }

        //basic values for dragon
        public Dragon()
        {
            MaxHealth = 50;
            MaxDamage = 15;
            Name = "Dragon";
            StartHealth = 50;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "What a beasty ";
            IsFire = false;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFire ? "Fire Dragon!" : "Ice Dragon!");
        }

        //overriding for fire dragon to have posibility to deal twice more damage on players and nonfire to have better block (33%)
        public override int EstBlock()
        {
            int estimatedBlock = Block;

            if (IsFire == false)
            {
                estimatedBlock += estimatedBlock / 3;
            }
            
            return estimatedBlock;
        }

        public override int EstDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(MinDamage, MaxDamage + 1);

            if (IsFire == true)
            {
                damage += damage * 2;
            }
            return damage;
        }
        
    }
}
