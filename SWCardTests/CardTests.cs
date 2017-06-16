using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShiftWiseCards;
using System.Collections.Generic;


namespace SWCardTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CheckNumberOfCards()
        {
            var TestDeck = new Deck();  //New deck for testing
            var shouldBeThisMany = 52;  //Standard Deck has 52 cards excluding jokers

            //Verify total number of cards are correct
            Assert.AreEqual(shouldBeThisMany, TestDeck.Cards.Count);
        }

        [TestMethod]
        public void CheckAllUnique()
        {
            var TestDeck = new Deck();  //New deck for testing
            var shouldBeThisMany = 52;  //Standard Deck has 52 unique cards excluding jokers
            //var thereAreThisMany = TestDeck.Cards.Distinct().ToList().Count;
            var thereAreThisMany = TestDeck.Cards.Select(card => card.SortOrder).Distinct().Count();

            //Verify all cards are unique
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckSuits()
        {
            var TestDeck = new Deck(); //New deck for testing
            var shouldBeThisMany = 4; //Standard Deck has 4 suits
            var thereAreThisMany = TestDeck.Cards.Select(card => card.Suit).Distinct().Count();

            //Verify there are the correct number of suits
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckFaceValues()
        {
            var TestDeck = new Deck();  //New deck for testing
            var shouldBeThisMany = 13;  //Standard Deck has 13 face values ace to king
            var thereAreThisMany = TestDeck.Cards.Select(card => card.Value).Distinct().Count();

            //Verify there are the correct number of card values
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckSorted()
        {
            // Create a test deck and sort cards explicitly. 
            // Suits low to high - Clubs, Diamonds, Hearts, Spades
            // Next card value low to high - Ace, Two, Three ... Jack, Queen, King
            var TestDeckExplicitSort = new Deck();
            var explicitlySortedCards = TestDeckExplicitSort.Cards.OrderBy(c => c.Suit).ThenBy(c => c.Value);

            // Create a test deck and sort using the Sort method. 
            var TestDeckSorted = new Deck();
            TestDeckSorted.Sort();
            //TestDeckSorted.DefaultOrderDeck();
            var sortResult = TestDeckSorted.Cards.ToList();

            // Verify that explict sort is the same as Sort(). 
            Assert.IsTrue(explicitlySortedCards.SequenceEqual(sortResult, new CardComparer()));
        }

        [TestMethod]
        public void CheckShuffled()
        {
            // Create a test deck and sort using the Sort method. 
            var TestDeckSorted = new Deck();
            TestDeckSorted.Sort();

            // Create a test deck and shuffle. 
            var TestDeckSuffle = new Deck();
            TestDeckSuffle.Shuffle();
            var shuffleResult = TestDeckSuffle.Cards.ToList();

            // Verify that Shuffle() deck sequence does not match Sort() deck. 
            Assert.IsFalse(TestDeckSorted.Cards.SequenceEqual(shuffleResult, new CardComparer()));
        }

        [TestMethod]
        public void CheckNumberOfCardsAfterSort()
        {
            var TestDeckSorted = new Deck();  //New deck for testing
            var shouldBeThisMany = 52;  //Standard Deck has 52 cards excluding jokers
            TestDeckSorted.Sort();

            //Verify total number of cards are correct after sorting
            Assert.AreEqual(shouldBeThisMany, TestDeckSorted.Cards.Count);
        }
        [TestMethod]
        public void CheckNumberOfCardsAfterSortAceHi()
        {
            var TestDeckSorted = new Deck();  //New deck for testing
            var shouldBeThisMany = 52;  //Standard Deck has 52 cards excluding jokers
            TestDeckSorted.Sort(1);  //Ace high overload sort

            //Verify total number of cards are correct after sorting
            Assert.AreEqual(shouldBeThisMany, TestDeckSorted.Cards.Count);
        }

        [TestMethod]
        public void CheckAllUniqueAfterSort()
        {
            var TestDeckSorted = new Deck(); //New deck for testing
            TestDeckSorted.Sort();
            var shouldBeThisMany = 52; //Standard Deck has 52 unique cards excluding jokers
            var thereAreThisMany = TestDeckSorted.Cards.Select(card => card.SortOrder).Distinct().Count();

            //Verify all cards are unique after sorting
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckSuitsAfterSort()
        {
            var TestDeckSorted = new Deck(); //New deck for testing
            TestDeckSorted.Sort();
            var shouldBeThisMany = 4;  //Standard Deck has 4 suits
            var thereAreThisMany = TestDeckSorted.Cards.Select(card => card.Suit).Distinct().Count();

            //Verify there are the correct number of suits after sorting
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckFaceValuesAfterSort()
        {
            var TestDeckSorted = new Deck(); //New deck for testing
            TestDeckSorted.Sort();
            var shouldBeThisMany = 13;  //Standard Deck has 13 face values ace to king
            var thereAreThisMany = TestDeckSorted.Cards.Select(card => card.Value).Distinct().Count();

            //Verify there are the correct number of card values after sorting
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckNumberOfCardsAfterShuffle()
        {
            var TestDeckShuffled = new Deck(); //New deck for testing
            var shouldBeThisMany = 52; //Standard Deck has 52 cards excluding jokers
            TestDeckShuffled.Shuffle();

            //Verify total number of cards are correct after shuffling
            Assert.AreEqual(shouldBeThisMany, TestDeckShuffled.Cards.Count);
        }

        [TestMethod]
        public void CheckAllUniqueAfterShuffle()
        {
            var TestDeckShuffled = new Deck(); //New deck for testing
            TestDeckShuffled.Shuffle();
            var shouldBeThisMany = 52;  //Standard Deck has 52 unique cards excluding jokers
            var thereAreThisMany = TestDeckShuffled.Cards.Select(card => card.SortOrder).Distinct().Count();

            //Verify all cards are unique after shuffling
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckSuitsAfterShuffle()
        {
            var TestDeckShuffled = new Deck(); //New deck for testing
            TestDeckShuffled.Shuffle();
            var shouldBeThisMany = 4;  //Standard Deck has 4 suits
            var thereAreThisMany = TestDeckShuffled.Cards.Select(card => card.Suit).Distinct().Count();

            //Verify there are the correct number of suits after shuffling
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }

        [TestMethod]
        public void CheckFaceValuesAfterShuffle()
        {
            var TestDeckShuffled = new Deck(); //New deck for testing
            TestDeckShuffled.Shuffle();
            var shouldBeThisMany = 13;  //Standard Deck has 13 face values ace to king
            var thereAreThisMany = TestDeckShuffled.Cards.Select(card => card.Value).Distinct().Count();

            //Verify there are the correct number of card values after shuffling
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);
        }
        [TestMethod]
        public void DoubleNullCheck()
        {
            var TestDeck1 = new Deck(); //New deck for testing
            var TestDeck2 = new Deck();
            TestDeck1.Sort();
            TestDeck2.Sort();

            TestDeck1.Cards[2] = null;
            TestDeck2.Cards[2] = null;

            var sortResult1 = TestDeck1.Cards.ToList();
            var sortResult2 = TestDeck2.Cards.ToList();

            //Verify double null 
            Assert.IsTrue(sortResult1.SequenceEqual(sortResult2, new CardComparer()));
        }
        [TestMethod]
        public void AceHighCheck()
        {
            var TestDeck1 = new Deck(); //New deck for testing
            TestDeck1.Sort(1);  //Sort overload for ace high
            var lastIndex = TestDeck1.Cards.ToList().Count - 1;  //deck starts at 0

            var topCard = TestDeck1.Cards[lastIndex];  //get last card
            
            //Verify top card is Ace of Spades
            Assert.IsTrue(topCard.Suit==CardSuit.spades && topCard.Value==CardValue.ace);
        }   
    }

    /// <summary>
    /// Determine whether two sequences of cards are the same. 
    /// </summary>
    public class CardComparer : IEqualityComparer<Card>
    {
        //Cards are equal if their suit and value are equal.
        public bool Equals(Card x, Card y)
        {
            //Check whether the compared cards reference the same data.
            if (object.ReferenceEquals(x, y)) return true;

            //Check whether both of the compared cards are null.
            if (object.ReferenceEquals(x, null) && object.ReferenceEquals(y, null)) return true;

            //Check whether any of the compared cards is null.
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            //Check whether the cards suits and values are equal.
            return x.Suit == y.Suit && x.Value == y.Value;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Card obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeRank = obj.Value.GetHashCode();
            int hashCodeSuite = obj.Value.GetHashCode();

            return hashCodeRank ^ hashCodeSuite;
        }
    }
}