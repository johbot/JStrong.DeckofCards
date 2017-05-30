using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftWiseCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Initializes a new instance of the Deck class
        /// </summary>
        public Deck()
        {
            InitializeDeck();
        }
        private void InitializeDeck()
        {
            Cards = new List<Card>();

            //First get suit for each card 
            Cards.AddRange(Enumerable.Range(0, 4)
                //Then get the value for each card
                .SelectMany(CardSuit => Enumerable.Range(0, 13)
                    //Then assign these to a card
                    .Select(Value => new Card((CardSuit)CardSuit, (CardValue)Value))));
        }


        /// <summary>
        /// Shuffle Cards using sort by GUID
        /// </summary>
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// Sort deck of cards ascending on default suit and card value, lowest card ace of clubs, highest king of spades
        /// </summary>
        public List<Card> Sort()
        {
            return Cards.OrderBy(c => c.Suit)
                             .ThenBy(c => c.Value)
                             .ToList();
        }
    }
}
