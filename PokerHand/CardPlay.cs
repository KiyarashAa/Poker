using PokerHand.Enums;
using PokerHand.Extenstions;
using PokerHand.Interfaces;
using System;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleToAttribute("PokerHand.Tests")]
namespace PokerHand
{
    public class CardPlay : ICardPlay,IComparable
    {
        public CardPlay()
        {

        }
        public CardPlay(int value,CardPlaySuit suit)
        {
            Value = value;
            Suit = suit;
        }
        public int Value { get; private set; }

        public void SetSuitAndValue(string suitValue)
        {
            if (string.IsNullOrEmpty(suitValue?.Trim()))
                throw new ArgumentNullException("The suitValue of CradGame can not be null or empty.");
            suitValue = suitValue.Trim().ToLower();
            if (suitValue.Length == 1)
                throw new ArgumentException("The suitValue must have at least 2 charachters");
            SetSuit(suitValue[suitValue.Length - 1]);
            SetValue(suitValue.Substring(0, suitValue.Length - 1));
        }

        private void SetSuit(char suit)
        {
            switch (suit)//it's always lower char
            {
                case 'h':
                    Suit = CardPlaySuit.Heart;
                    break;
                case 'd':
                    Suit = CardPlaySuit.Diamond;
                    break;
                case 'c':
                    Suit = CardPlaySuit.Club;
                    break;
                case 's':
                    Suit = CardPlaySuit.Spade;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The card suit is unkown. please use one of this suits H for Heart, D for Diamond, C for Club, S for Spade");
            }
        }

        private void SetValue(string value)
        {
            value = value.Trim().ToLower();
            switch (value)
            {
                case "j":
                case "jack":
                    Value = 11;
                    break;
                case "q":
                case "queen":
                    Value = 12;
                    break;
                case "k":
                case "king":
                    Value = 13;
                    break;
                case "a":
                case "ace":
                    Value = 14;
                    break;
                default:
                    if (!int.TryParse(value, out int number) || number < 2 || number > 14) // Invalid Input
                    {
                        throw new ArgumentOutOfRangeException($"The value {value} is not acceptable for card game. please set the value correctly.");
                    }
                    Value = number;
                    break;
            }
        }

        public CardPlaySuit Suit { get; private set; }
        public override string ToString()
        {
            string str;
            switch (Value)
            {
                case 11:
                    str = "J";
                    break;
                case 12:
                    str = "Q";
                    break;
                case 13:
                    str = "K";
                    break;
                case 14:
                    str = "A";
                    break;
                default:
                    str = Value.ToString();
                    break;
            }
            str += Suit.ToStringCode();
            return str;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            var cardPlay = obj as CardPlay;
            if (cardPlay == null)
                throw new ArgumentException("The object is not a CardPlay.");
            return cardPlay.Value.CompareTo(Value);//Descending
        }
    }
}
