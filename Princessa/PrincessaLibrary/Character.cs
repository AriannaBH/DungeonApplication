using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessaLibrary
{
    public abstract class Character
    {
        //field
        private int _starthealth;
        //private int _level;
        //private enum _race;
        //private string _gender;

        //prop
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxHealth { get; set; }
        public int StartHealth
        {
            get { return _starthealth; }
            set
            {
                if (value <= MaxHealth) //max health cannot be exceeded by our health so we rule it here
                {
                    _starthealth = value;
                }
                else
                {
                    _starthealth = MaxHealth;
                }
            }
        }
        

        //ctor
        //none needed
        //method
        public virtual int EstBlock()
        {
            return Block;
        }

        public virtual int EstHitChance()
        {
            return HitChance;
        }
        public virtual int EstDamage()
        {
            return 0;
        }
    }
}
