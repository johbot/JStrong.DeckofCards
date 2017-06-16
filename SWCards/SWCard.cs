using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftWiseCards
{
    /// <summary>
    /// The order of the suits is determined by alphabetical order (same ranking is used in bridge)
    /// Spades are high       
    /// </summary>
    public enum CardSuit { clubs, diamonds, hearts, spades };
    /// <summary>
    /// The face value of the card, ace is low, king is high
    /// </summary>
    public enum CardValue { ace = 1, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king };


    public class Card //: IComparable<Card>
    {
        public CardSuit Suit { get; set; }

        public CardValue Value { get; set; }

        private int _SortOrder;
        public int SortOrder
        {
            get { return _SortOrder; }
        }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
            SetSortOrder();
        }
        /// <summary>
        /// Sort deck of cards ascending on default suit and card value, 
        /// lowest card ace of clubs, highest king of spades
        /// Overload sending 1 to sort ace high
        /// </summary>
        public void SetSortOrder()
        {
            _SortOrder = ((int)Suit * 13) + (int)Value;
        }
        /// <summary>
        /// Sort deck of cards ascending on default suit and card value, 
        /// lowest card two of clubs, highest ace of spades
        /// Overload sending 1 to sort ace high
        /// </summary>
        public void SetSortOrder(int hi)
        {
            if (hi == 1 )
            {
                if (Value == CardValue.ace)
                {
                    _SortOrder = ((int)Suit * 13) + 13  ;
                }
                else
                {
                    _SortOrder = ((int)Suit * 13) + (int)Value - 1;
                }
            }
        }
    }
}
