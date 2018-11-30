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
            if (this.Flush > 0 || player.Flush > 0)
            {
                result = player.Flush.CompareTo(Flush);//Descending
                return result == 0 ? WhoIsWinnerInSameHand(player) : result;
            }
            if(ThreeOfKind > 0 || player.ThreeOfKind > 0)
            {
                return player.ThreeOfKind.CompareTo(ThreeOfKind);//Descending
            }
            if(OnePair > 0 || player.OnePair > 0)
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
        public int ThreeOfKind
        {
            get
            {
                var list = from l in Cards
                           group l.Value by l.Value into g
                           let count = g.Count()
                           orderby count descending
                           select new
                           {
                               Count = count,
                               Value = g.Key
                           };
                if (list.First().Count >= 3)//First item is highest
                    return list.First().Value;
                return 0;
            }
        }
        public int OnePair
        {
            get
            {
                var list = from l in Cards
                           group l.Value by l.Value into g
                           let count = g.Count()
                           orderby count descending
                           select new
                           {
                               Count = count,
                               Value = g.Key
                           };
                if (list.First().Count == 2)
                    return list.First().Value;
                return 0;
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
    }
}
