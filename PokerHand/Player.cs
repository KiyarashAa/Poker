using PokerHand.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand
{
    public class Player : IComparable
    {

        public Player(string playerName)
        {
            Name = playerName;
            Cards = new List<CardPlay>();
        }

        public string Name { get; set; }
        public List<CardPlay> Cards { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return -1;
            var player = obj as Player;
            if (player == null)
                throw new ArgumentException("Object is not a Player.");
            int result;
            if (this.RoyalFlush > 0 || player.RoyalFlush > 0)
            {
                result = player.RoyalFlush.CompareTo(RoyalFlush);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (this.StraightFlush > 0 || player.StraightFlush > 0)
            {
                result = player.StraightFlush.CompareTo(StraightFlush);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (this.FourOfKind > 0 || player.FourOfKind > 0)
            {
                result = player.FourOfKind.CompareTo(FourOfKind);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (this.FullHouse > 0 || player.FullHouse > 0)
            {
                result = player.FullHouse.CompareTo(FullHouse);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (this.Flush > 0 || player.Flush > 0)
            {
                result = player.Flush.CompareTo(Flush);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (this.Straight > 0 || player.Straight > 0)
            {
                result = player.Straight.CompareTo(Straight);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (ThreeOfKind > 0 || player.ThreeOfKind > 0)
            {
                return player.ThreeOfKind.CompareTo(ThreeOfKind);//Descending
            }
            if (TwoPair > 0 || player.TwoPair > 0)
            {
                result = player.TwoPair.CompareTo(TwoPair);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if (OnePair > 0 || player.OnePair > 0)
            {
                result = player.OnePair.CompareTo(OnePair);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            result = player.HighCard.CompareTo(HighCard);//Descending
            return result == 0 ? WhoIsWinnerInSameHand(player) : result;
        }
        private int WhoIsWinnerInSameHand(Player player)
        {
            Cards.Sort();
            player.Cards.Sort();
            for (int i = 1; i < 4; i++)//initial is 1 because the first index values are same
            {
                var result = player.Cards[i].Value.CompareTo(Cards[i].Value);//Descending
                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }
        public int RoyalFlush
        {
            get
            {
                if (StraightFlush != 0)
                {
                    Cards.Sort();
                    if (Cards.First().Value == 14)
                        return 14;
                }
                return 0;
            }
        }
        public int StraightFlush
        {
            get
            {
                if (Flush != 0)
                {
                    if (Cards.First().Value - Cards.Last().Value == 4)
                        return Cards.First().Value;
                }
                return 0;
            }
        }
        public int Flush
        {
            get
            {
                if (Cards.GroupBy(c => c.Suit).ToList().Count == 1)
                {
                    Cards.Sort();
                    return Cards.First().Value;
                }
                return 0;
            }
        }
        public int Straight
        {
            get
            {
                if (Cards.First().Value - Cards.Last().Value == 4)
                    return Cards.First().Value;
                return 0;
            }

        }
        public int FourOfKind
        {
            get
            {
                return GetNumberOfKind(4);
            }

        }
        public int ThreeOfKind
        {
            get
            {
                return GetNumberOfKind(3);
            }
        }
        public int TwoPair
        {
            get
            {
                var highPair = GetNumberOfKind(2, out int lowPair);
                return highPair * 100 + lowPair;
            }
        }
        public int FullHouse
        {
            get
            {
                if (ThreeOfKind != 0 && OnePair != 0)
                    return ThreeOfKind * 100 + OnePair;
                return 0;
            }
        }
        public int OnePair
        {
            get
            {
                return GetNumberOfKind(2);
            }
        }
        public int HighCard
        {
            get
            {
                Cards.Sort();
                return Cards.First().Value;//First one is High Card
            }
        }
        private int GetNumberOfKind(int number)
        {
            return GetNumberOfKind(number, out int lowPair);
        }
        private int GetNumberOfKind(int number, out int lowPair)
        {
            lowPair = 0;
            var list = from l in Cards
                       group l.Value by l.Value into g
                       let count = g.Count()
                       orderby count descending
                       select new
                       {
                           Count = count,
                           Value = g.Key
                       };
            if (list.ToArray()[1].Value == 2)
            {
                lowPair = list.ToArray()[1].Value;
            }
            if (list.First().Count == number)//First item is highest
                return list.First().Value;
            return 0;
        }
    }
}
