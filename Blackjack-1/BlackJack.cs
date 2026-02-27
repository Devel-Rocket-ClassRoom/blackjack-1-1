using System;

class BlackJack
{
    Random rand = new Random();

    private string[] _card = new string[52];
    private string _name;
    private bool _isStand = false;
    private int _total = 0;
    private int _count = 0;

    public string Name => _name;
    public string Card => _card[_count - 1];

    public int Total => _total;

    public BlackJack(string name)
    {
        _name = name;
    }

    public void CardDraw(Card choice)
    {
        _card[_count] = choice.ChoiceCard();

        switch (_card[_count].Substring(1))
        {
            case "A":
                if (_total + 11 <= 21)
                {
                    _total += 11;
                    break;
                }
                else
                {
                    _total += 1;
                    break;
                }
            case "2":
                _total += 2;
                break;

            case "3":
                _total += 3;
                break;

            case "4":
                _total += 4;
                break;

            case "5":
                _total += 5;
                break;

            case "6":
                _total += 6;
                break;

            case "7":
                _total += 7;
                break;

            case "8":
                _total += 8;
                break;

            case "9":
                _total += 9;
                break;

            case "10":
            case "J":
            case "Q":
            case "K":
                _total += 10;
                break;
        }

        _count++;
    }

    public void GameStart(Card choice)
    {
        CardDraw(choice);
        CardDraw(choice);
    }

    public void ShowInfo()
    {      
        Console.Write($"{_name}의 패: ");
        for (int i = 0; i < _count; i++)
        {
            Console.Write($"[{_card[i]}] ");
        }

        Console.WriteLine();
        Console.WriteLine($"{_name}의 점수: {_total}");
    }


}