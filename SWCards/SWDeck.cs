using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShiftWiseCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        private IComparer<Card> _CardComparer = new PlayingCardComparer();

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
                .SelectMany(CardSuit => Enumerable.Range(1, 13)
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
        //public List<Card> Sort()
        //{
        //    return Cards.OrderBy(c => c.Suit)
        //                     .ThenBy(c => c.Value)
        //                     .ToList();
        //}

        /// <summary>
        /// Sort deck of cards ascending on default suit and card value, 
        /// lowest card ace of clubs, highest king of spades
        /// Overload by sending 1 to sort ace high
        /// </summary>
        public void Sort()
        {
            foreach (Card CurrentCard in Cards)
                CurrentCard.SetSortOrder();
            Cards.Sort(_CardComparer);
        }
        public void Sort(int hi)
        {
            if (hi == 1)
            {
                foreach (Card CurrentCard in Cards)
                    CurrentCard.SetSortOrder(hi);
                Cards.Sort(_CardComparer);
            }
        }
    }
    class PlayingCardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.SortOrder < y.SortOrder)
                return -1;
            else if (x.SortOrder > y.SortOrder)
                return 1;
            else
                return 0;
        }
    }
}
