using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrincessaLibrary;
using PrincessaMonsters;

namespace Princessa
{
    class PrincessaApplication
    {
        static void Main(string[] args)
        {
            int level = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = string.Format("Rescue the Princess");
            Console.WriteLine("Objective:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Rescue the Princess!\n");

            Weapon sword = new Weapon(20, 80, "Heavy Sword", true); 
            Weapon lightSword = new Weapon(20, 80, "Light Sword", false); 

            

            Player p1 = new Player("Arianna", 30, 40, 100, 100, Roles.Ninja, sword);
            


            bool leave = false;
            
            do
            {
                Console.WriteLine(Levelz());


                Dragon d1 = new Dragon("Slick Dragon", 50, 50, 20, 25, 34, 55, "It is so cold...", false);
                Dragon d2 = new Dragon("Spiked Dragon", 50, 50, 20, 20, 20, 50, "It is so hot...", true);
                Dragon d3 = new Dragon();
                Opponent[] monsters = { d3, d1, d2, d2, d3, d1 };

                Random rand = new Random();
                int randomMon = rand.Next(monsters.Length);
                Opponent monster = monsters[randomMon];

                Console.WriteLine("\nIn this room: " + monster.Name);


                bool nextLevel = false;
                do
                {
                    #region MENU
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExecute An Action:\n1) ATTACK THE MONSTER!\n2) I WANNA RUN AWAY\n" +
                        "3) Give me some more on my character. \n4) What is this that I am fighting!?\n5) I'm over this.. (exit game)\n");


                    ConsoleKey userChoice = Console.ReadKey(true).Key;


                    Console.Clear();


                    switch (userChoice)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:

                            Combat.LetsFight(p1, monster);
                            if (monster.StartHealth <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                nextLevel = true;
                                level++;
                            }
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("You run away from the room, just to enter another! aha");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.YesAttack(monster, p1);
                            Console.WriteLine();
                            nextLevel = true;
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Oh, you wanna know some information on yourself, here you go!\n{0}", p1);
                            break;
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ah yes, you are the type to know what you are fighting against.." +
                                "I see, no worries..here's a bit about them..\n{0}", monster);
                            break;
                        case ConsoleKey.NumPad5:
                        case ConsoleKey.D5:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You fool! You're leaving!? Looks like the princess is never getting rescued....");

                            leave = true;
                            break;
                        default:
                            Console.WriteLine("That input was incorrect. Please try again!");
                            break;
                    }
                    #endregion
                    if (p1.StartHealth <= 0)
                    {
                        Console.WriteLine("You died...");
                        leave = true;
                    }
                    else if (level >= 12)
                    {
                        leave = true;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You beat the levels! And rescued the princess, awesome!");

                    }
                }
                while (!leave && !nextLevel);
            } while (!leave);


            Console.WriteLine("You reached level {0} out of 12!", level);


        }//end main

        private static string Levelz()
        {
            //make an array for each level
            //figure to make them increase as they defeat a monster and stay if they choose to run.
            string[] rooms = { "A small pair of granite doors in a bleak forest marks the entrance to this dungeon. Beyond the pair of granite doors lies a large, worn room. It's covered in dirt, small bones and dead insects.Your torch allows you to see empty shelves and broken pots, worn and devoured by time itself. Further ahead are two paths, you take the right. Its twisted trail leads onwards and soon you enter a ghostly area. Remnants of a makeshift barricade still 'guard' the group of skeletons behind it. What happened in this place? You slowly move onwards, deeper into the dungeon's expanse. You pass dozens of similar rooms and passages, some are dead ends, others seem to have no end at all. You eventually make it to what is likely the final room. A huge wooden door blocks your path. Countless runes are all over it, somehow untouched by time and the elements. You step closer to inspect it and.. wait.. you hear a faint laugh coming from behind the door.", "This room is hung with hundreds of dusty tapestries. All show signs of wear: moth holes, scorch marks, dark stains, and the damage of years of neglect. They hang on all the walls and hang from the ceiling to brush against the floor, blocking your view of the rest of the room.", "In the center of this large room lies a 30-foot-wide round pit, its edges lined with rusting iron spikes. About 5 feet away from the pit's edge stand several stone semicircular benches. The scent of sweat and blood lingers, which makes the pit's resemblance to a fighting pit or gladiatorial arena even stronger.", "A pit yawns open before you just on the other side of the door's threshold. The entire floor of the room has fallen into a second room beneath it. Across the way you can spy a door in the wall now 15 feet off the rubble-strewn floor, and near the center of the room stands a thick column of mortared stone that appears to hold the spiral staircase that leads down to what was the lower level.", "You open the door to confront a room of odd pillars. Water rushes down from several holes in the ceiling, and each hole is roughly a foot wide. The water pours in columns that fall through similar holes in the floor, flowing down to some unknown depth. Each of the eight pillars of water drops as much liquid as a stream in winter thaw. The floor is damp and looks slippery.", "The strong, sour-sweet scent of vinegar assaults your nose as you enter this room. Sundered casks and broken bottle glass line the walls of this room. Clearly this was someone's wine cellar for a time. The shards of glass are somewhat dusty, and the spilled wine is nothing more than a sticky residue in some places. Only one small barrel remains unbroken amid the rubbish.", "This room is a tomb. Stone sarcophagi stand in five rows of three, each carved with the visage of a warrior lying in state. In their center, one sarcophagus stands taller than the rest. Held up by six squat pillars, its stone bears the carving of a beautiful woman who seems more asleep than dead. The carving of the warriors is skillful but seems perfunctory compared to the love a sculptor must have lavished upon the lifelike carving of the woman.", "Burning torches in iron sconces line the walls of this room, lighting it brilliantly. At the room's center lies a squat stone altar, its top covered in recently spilled blood. A channel in the altar funnels the blood down its side to the floor where it fills grooves in the floor that trace some kind of pattern or symbol around the altar. Unfortunately, you can't tell what it is from your vantage point.", "This hall is choked with corpses. The bodies of orcs and ogres lie in tangled heaps where they died, and the floor is sticky with dried blood. It looks like the orcs and ogres were fighting. Some side was the victor but you're not sure which one. The bodies are largely stripped of valuables, but a few broken weapons jut from the slain or lie discarded on the floor.", "When looking into this chamber, you're confronted by a thousand reflections of yourself looking back. Mirrored walls set at different angles fill the room. A path seems to wind through the mirrors, although you can't tell where it leads", "This room smells strange, no doubt due to the weird sheets of black slime that drip from cracks in the ceiling and spread across the floor. The slime seeps from the shattered stone of the ceiling at a snails crawl, forming a mess of dangling walls of gook. As you watch, a bit of the stuff separates from a sheet and drops to the ground with a wet plop.", "You open the door and a gout of flame rushes at your face. A wave of heat strikes you at the same time and light fills the hall. The room beyond the door is ablaze! An inferno engulfs the place, clinging to bare rock and burning without fuel." };
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }

    }//end class
}//end namespace
