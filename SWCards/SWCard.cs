using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftWiseCards
{
    /// <summary>
    /// The order of the suits is determined by alphabetical order (same ranking is used in bridge)
    /// Spades are high       
    /// </summary>
    public enum CardSuit { clubs = 1, diamonds, hearts, spades };
    /// <summary>
    /// The face value of the card, Ace is high
    /// </summary>
    public enum CardValue { two = 2, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace };

    public class Card
    {
        private CardSuit _cardSuit;
        private CardValue _cardValue;

        public CardSuit Suit
        {
        get { return _cardSuit; }
        }

        public CardValue Value
        {
            get { return _cardValue; }
        }

        public int SortOrder 
        {
            get { return (int)this._cardSuit * 100 + (int)this._cardValue; }
        }

        public Card(CardSuit suit, CardValue value)
        {
            _cardSuit = suit;
            _cardValue = value;

        }
    }
}
