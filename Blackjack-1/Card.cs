using System;

class Card
{
    public string[,] CardNumber = {
        {"♦A", "♦2", "♦3", "♦4", "♦5", "♦6", "♦7", "♦8", "♦9", "♦10", "♦J", "♦Q", "♦K"},
        {"♠A", "♠2", "♠3", "♠4", "♠5", "♠6", "♠7", "♠8", "♠9", "♠10", "♠J", "♠Q", "♠K"},
        {"♥A", "♥2", "♥3", "♥4", "♥5", "♥6", "♥7", "♥8", "♥9", "♥10", "♥J", "♥Q", "♥K"},
        {"♣A", "♣2", "♣3", "♣4", "♣5", "♣6", "♣7", "♣8", "♣9", "♣10", "♣J", "♣Q", "♣K"}
        };

    Random rand = new Random();

    public string ChoiceCard()
    {
        while (true)
        {
            int randomNumber = rand.Next(0, 52);

            int first = randomNumber / 13;
            int second = randomNumber % 13;

            string temp = CardNumber[first, second];

            if (temp != "-1")
            {
                CardNumber[first, second] = "-1";

                return temp;
            }
                     
        }        
    }
}