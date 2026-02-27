using System;

BlackJack player = new BlackJack("플레이어");
BlackJack dealer = new BlackJack("딜러");

Card card  = new Card();

Console.WriteLine("=== 블랙잭 게임 ===\n");
Console.WriteLine("카드를 섞는 중...\n");

player.GameStart(card);
dealer.GameStart(card);

Console.WriteLine("=== 초기 패 ===");
dealer.ShowInfo();
Console.WriteLine();
player.ShowInfo();
Console.WriteLine();

while (true)
{
    if (player.Total > 21)
    {
        break;
    }

    Console.Write("H(Hit) 또는 S(Stand)를 선택하세요: ");
    string input  = Console.ReadLine().ToUpper();

    if (input == "H")
    {
        player.CardDraw(card);
        string DrawCard = player.Card.ToString();
        Console.WriteLine();
        Console.WriteLine($"{player.Name}가 카드를 받았습니다: [{DrawCard}]");
        player.ShowInfo();
        Console.WriteLine();
    }

    if (input == "S")
    {
        Console.WriteLine($"{player.Name}가 Stand를 선택했습니다.");
        break;
    }
}

