using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShiftWiseCards;


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
            thereAreThisMany = TestDeck.Cards.Select(c => c.SortOrder).Distinct().Count();  //Count distint card values through the sort order property

            //assert
            Assert.AreEqual(shouldBeThisMany, thereAreThisMany);


        }

        [TestMethod]
        public void CheckSorted()
        {
            //arrange

            Deck TestDeckSorted;  //Sorted deck for checking
            var distanceFromSorted = 0;

            //act
            TestDeckSorted = new Deck();  //New deck sorted by default 

            int i = 0;
            for (int s = 1; s < 5; s++) //Suit counter
                for(int f = 2; f < 15; f++) //Face counter
            {
                    distanceFromSorted += Math.Abs((s*100 + f) - TestDeckSorted.Cards[i].SortOrder);
                    i++;
            }

            //assert
            Assert.AreEqual(distanceFromSorted, 0);


        }
        [TestMethod]
        public void CheckShuffled()
        {
            //arrange

            Deck TestDeckSorted;  //Default Sorted Deck
            Deck TestDeckShuffled;  //Shuffled Deck 

            var distanceFromSorted = 0;  //very small (1/52!) chance a shuffled deck comes back sorted

            //act
            TestDeckSorted = new Deck();
            TestDeckShuffled = new Deck();
            TestDeckShuffled.Shuffle();

            for (int i = 0; i < 52; i++)
            {
                distanceFromSorted += Math.Abs(TestDeckSorted.Cards[i].SortOrder - TestDeckShuffled.Cards[i].SortOrder) ;
            }

            //assert
            Assert.AreNotEqual(0, distanceFromSorted); 

        }

    }
}
