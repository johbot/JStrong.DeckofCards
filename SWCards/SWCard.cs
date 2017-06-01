namespace ShiftWiseCards
{
    /// <summary>
    /// The order of the suits is determined by alphabetical order (same ranking is used in bridge)
    /// Spades are high       
    /// </summary>
    public enum CardSuit { clubs = 1, diamonds, hearts, spades };
    /// <summary>
    /// The face value of the card, ace is low, king is high
    /// </summary>
    public enum CardValue { ace = 1, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king };

    public class Card 
    {
        public CardSuit Suit { get; set; }

        public CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
