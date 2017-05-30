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
    public enum CardSuit { clubs , diamonds, hearts, spades };
    /// <summary>
    /// The face value of the card, ace is low, king is high
    /// </summary>
    public enum CardValue { ace, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king };

    public class Card 
    {
        public CardSuit Suit { get; set; }

        public CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            this.Suit = suit;
            this.Value = value;
        }
    }
}
