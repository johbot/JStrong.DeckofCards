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
        this.Cards = new List<Card>();

        foreach (CardSuit CurrentSuit in Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardValue CurrentValue in Enum.GetValues(typeof(CardValue)))
            {
                this.Cards.Add(new Card(CurrentSuit, CurrentValue));
            }
        }
            DefaultDeckSort();

    }
        /// <summary>
        /// Sort deck of cards ascending on default suit and card value, lowest card 2 of clubs, highest ace of spades
        /// </summary>
        public void DefaultDeckSort()
        {
            Cards = Cards.OrderBy(c => c.SortOrder).ToList();
        }
        /// <summary>
        /// Shuffle Cards using sort by GUID
        /// </summary>
        public void Shuffle()
        {
            // May not be statictically random since GUID still has some time factors
            // If this is for online casino, might need a better random number generator
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }


    }
}
