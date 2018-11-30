using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            Game.Instance.Players = players;
            Console.WriteLine("Please enter player counts a number between 2 to 5...");
            int playerCount;
            while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount > 5 || playerCount < 2)
            {
                Console.WriteLine("Invalid Data!");
                Console.WriteLine("Please enter player counts a number between 2 to 5...");
            }
            Console.WriteLine($"{playerCount} Players added.");
            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Please enter player {i + 1}'s name...");
                var playerName = Console.ReadLine();
                players.Add(new Player(playerName));
            }
            while (true)
            {
                foreach (var item in players)
                {
                    Console.WriteLine($"Write 5 cards to add for {item.Name}. Use Space key to seperate them. ex 8S 5D 10H JH QH");
                    while (true)
                    {
                        var input = Console.ReadLine();
                        if (AddInputToCardList(input, item.Cards))
                            break;
                    }

                }
                if (players.Last().Cards.Count == 5)
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(new string('*', 15));
            foreach (var item in players)
            {
                Console.WriteLine(item.Name);
                foreach (var card in item.Cards)
                {
                    Console.Write(card.ToString() + " ");
                }
                Console.WriteLine();
            }
            foreach (var item in Game.Instance.Winners)
            {
                Console.WriteLine($"{item.Name} is winner.");
            }
            Console.ReadLine();
        }

        private static bool AddInputToCardList(string input, List<CardPlay> cards)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            List<string> inputCards = input.Split(' ').ToList();
            if (inputCards.Count < 5)
            {
                Console.WriteLine("Invalid Data!");
                Console.WriteLine("Please enter 5 cards seperated by Space Key");
                return false;
            }
            try
            {
                Game.Instance.ClearSelectedCards(cards);
                for (int i = 0; i < 5; i++)
                {
                    var cardPlay = Game.Instance.GetCardPlay(inputCards[i]);
                    if (cardPlay == null)
                    {
                        Console.WriteLine("Invalid Data!");
                        Console.WriteLine($"{inputCards[i]} is selected before. select another card.");
                        return false;
                    }
                    cards.Add(cardPlay);
                }
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Failed to add new card -> " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Failed to add new card -> " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unkwon error -> " + ex.Message);
            }
            return false;
        }
    }
}
