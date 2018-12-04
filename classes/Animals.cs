using System;
using System.Collections.Generic;

namespace youre_bluffing_console
{
    class Animals
    {
        public static Dictionary<string, int> cardValues = new Dictionary<string, int>(){
            {"Chicken", 10},
            {"Goose", 40},
            {"Cat", 90},
            {"Dog", 160},
            {"Sheep", 250},
            {"Goat", 350},
            {"Donkey", 500},
            {"Pig", 650},
            {"Cow", 800},
            {"Horse", 1000}
        };

        private static string[] cardTypesSortedByValue = new string[] { "Chicken", "Goose", "Cat", "Dog", "Sheep", "Goat", "Donkey", "Pig", "Cow", "Horse" };
        public string[] deck = new string[40];

        public Animals()
        {
            deck = GenerateDeck();
        }

        private static string[] GenerateDeck()
        {
            string[] deck = new string[40];
            for (int i = 0; i < cardTypesSortedByValue.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck[i * 4 + j] = cardTypesSortedByValue[i];
                }
            }
            return ShuffleDeck(deck);
        }

        private static string[] ShuffleDeck(string[] deck)
        {
            Random random = new Random();

            for (int i = deck.Length - 1; i > 1; i--)
            {
                int j = random.Next(0, i + 1);
                string key = deck[j];
                deck[j] = deck[i];
                deck[i] = key;
            }
            return deck;
        }

        public static int GetValueOfQuartets(string[] quartets)
        {
            int accumulator = 0;
            for (int i = 0; i < quartets.Length; i++)
            {
                accumulator += cardValues[quartets[i]];
            }
            return accumulator * quartets.Length;
        }

        public string DrawCard(int turn)
        {
            try
            {
                if (turn > 39) throw new Exception("The deck is empty, move on to the trading section of the game");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + "\nMessage: " + ex.Message);
            };
            return deck[turn];
        }
    }
}