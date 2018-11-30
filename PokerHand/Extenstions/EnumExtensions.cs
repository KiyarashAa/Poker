using PokerHand.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Extenstions
{
    public static class EnumExtensions
    {
        public static string ToStringCode(this CardPlaySuit cardPlaySuit)
        {
            string result;
            switch (cardPlaySuit)
            {
                case CardPlaySuit.Spade:
                    result = "S";
                    break;
                case CardPlaySuit.Diamond:
                    result = "D";
                    break;
                case CardPlaySuit.Heart:
                    result = "H";
                    break;
                case CardPlaySuit.Club:
                    result = "C";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The card suit is unkown");
            }
            return result;
        }
    }
}
