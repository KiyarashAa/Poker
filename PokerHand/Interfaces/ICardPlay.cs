using PokerHand.Enums;

namespace PokerHand.Interfaces
{
    public interface ICardPlay
    {
        int Value { get;}
        CardPlaySuit Suit { get;}
        void SetSuitAndValue(string suitValue);
    }
}
