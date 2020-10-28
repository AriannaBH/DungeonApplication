using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessaLibrary
{
    public class Weapon
    {
        //field
        private int _minDamage;

        //prop
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public bool IsStrong { get; set; }
        
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <=MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //ctor
        public Weapon(int minDamage, int maxDamage, string name, bool isStrong)
       
        {
            MinDamage = MaxDamage;
            MaxDamage = maxDamage;
            Name = name;
            IsStrong = isStrong;
            
          
        }

        //method
        public override string ToString()
        {
           
            
            return string.Format("You yeild a {0}! You can attack an opponenet up to {1} to {2} damage with using this {3} weapon at hand!",
                Name,
                MinDamage,
                MaxDamage,
                IsStrong ? "stronger" : "weaker");
        }
    }
}
