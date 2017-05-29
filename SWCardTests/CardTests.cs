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
            //arrange
            Deck TestDeck;
            var shouldBeThisMany = 52;

            //act
            TestDeck = new Deck();

            //assert
            Assert.AreEqual(shouldBeThisMany, TestDeck.Cards.Count);

        }
        [TestMethod]
        public void CheckAllUnique()
        {
            //arrange
            Deck TestDeck;
            var shouldBeThisMany = 52;
            var thereAreThisMany = 0;

            //act
            TestDeck = new Deck();

            thereAreThisMany = TestDeck.Cards.Distinct().ToList().Count;

            //assert
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);


        }
        [TestMethod]

        public void CheckSuits()
        {
            //arrange
            Deck TestDeck;
            var shouldBeThisMany = 4;
            var thereAreThisMany = 0;

            //act
            TestDeck = new Deck();

            thereAreThisMany = TestDeck.Cards.Select(card => card.Suit).Distinct().Count();

            //assert
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);

        }
        [TestMethod]

        public void CheckFaceValues()
        {
            //arrange
            Deck TestDeck;
            var shouldBeThisMany = 13;
            var thereAreThisMany = 0;

            //act
            TestDeck = new Deck();

            thereAreThisMany = TestDeck.Cards.Select(card => card.Value).Distinct().Count();

            //assert
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);

        }

        [TestMethod]
        public void CheckSorted()
        {
            //arrange
            Deck TestDeck; //Test deck to use sort method and manual sort

            //act
            TestDeck = new Deck();
            var TestDeckManualSort = new List<Card>(TestDeck.Cards.OrderBy(c => c.Suit).ThenBy(c => c.Value).ToList());

            TestDeck.Sort();

            //assert
            Assert.IsTrue(TestDeck.Cards.SequenceEqual(TestDeckManualSort));
        }

        [TestMethod]
        public void CheckShuffled()
        {
            //arrange
            Deck TestDeckSorted;  //Default Sorted Deck
            Deck TestDeckShuffled;  //Shuffled Deck 

            //act
            TestDeckSorted = new Deck();
            TestDeckShuffled = new Deck();
            TestDeckSorted.Sort();
            TestDeckShuffled.Shuffle();

            //assert
            Assert.IsFalse(TestDeckSorted.Cards.SequenceEqual(TestDeckShuffled.Cards));
        }
    }
}
