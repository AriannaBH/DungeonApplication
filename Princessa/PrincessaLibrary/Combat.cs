using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessaLibrary
{
    public class Combat
    {
        //warehouse for methods to conduct our battle sequences

        public static void LetsFight (Player player, Opponent opponent)
        {
            YesAttack(player, opponent);

            if (opponent.StartHealth > 0)
            {
                YesAttack(opponent, player);
            }
        }

        public static void YesAttack(Character offense, Character defense)
        {
            Random rand = new Random();
            int rollTurn = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);

            if (rollTurn <= (offense.EstHitChance() - defense.EstBlock()))
            {
                //offense attacked defense, so we calculat the damage dealt here
                int damageDeal = offense.EstDamage();

                //assigning damage dealt here
                defense.StartHealth -= damageDeal;

                //screen result
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage, oof!",
                    offense.Name,
                    defense.Name,
                    damageDeal);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} has missed their shot!", offense.Name);
            }
        }
    }
}
