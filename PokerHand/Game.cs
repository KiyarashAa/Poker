using PokerHand.Enums;
using PokerHand.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand
{
    public class Game
    {
        public void Dispose()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
        private Game()
        {
            var cards = new List<CardPlay>();
            var suits = new List<CardPlaySuit>
            {
                CardPlaySuit.Club,
                CardPlaySuit.Diamond,
                CardPlaySuit.Spade,
                CardPlaySuit.Heart
            };
            foreach (var suit in suits)
            {
                for (int i = 2; i < 15; i++)
                {
                    cards.Add(new CardPlay(i, suit));
                }
            }
            AvailableCards = new List<CardPlay>();
            while (true)
            {
                lock (_lockDealCards)
                {
                    var index = _random.Next(cards.Count());
                    AvailableCards.Add(cards[index]);
                    cards.Remove(cards[index]);
                    if (!cards.Any())
                        break;
                }
            }
        }

        public List<Player> Players { get; set; }
        public List<Player> Winners
        {
            get
            {
                Players.Sort();
                var winners = new List<Player>();
                var length = Players.Count;
                for (int i = 0; i < length; i++)
                {
                    winners.Add(Players[i]);
                    if (i == length - 1 || Players[i].CompareTo(Players[i + 1]) != 0)
                        break;
                }
                return winners;
            }
        }

        private Random _random = new Random();
        private object _lockDealCards = 1;
        private object _lockAvailableCards = 1;
        public List<CardPlay> AvailableCards { get; set; }

        private static Game _instance;
        private static object _lock = 1;

        public static Game Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Game();
                    return _instance;
                }
            }
        }
        public CardPlay GetCardPlay(string cardGameString)
        {
            var cardPlay = new CardPlay();
            cardPlay.SetSuitAndValue(cardGameString);
            lock (_lockAvailableCards)
            {
                cardPlay = AvailableCards.FirstOrDefault(c => c.Suit == cardPlay.Suit && c.Value == cardPlay.Value);
                if (cardPlay != null)
                    AvailableCards.Remove(cardPlay);
            }
            return cardPlay;
        }

        public void ClearSelectedCards(List<CardPlay> cards)
        {
            if (!cards.Any())
                return;
            lock (_lockAvailableCards)
            {
                AvailableCards.AddRange(cards);
            }
            cards.Clear();
        }
    }
}
