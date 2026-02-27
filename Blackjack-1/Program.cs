using System;
using System.Diagnostics;

BlackJack player = new BlackJack("플레이어");
BlackJack dealer = new BlackJack("딜러");

Card card  = new Card();

Console.WriteLine("=== 블랙잭 게임 ===\n");
Console.WriteLine("카드를 섞는 중...\n");

player.GameStart(card);
dealer.GameStart(card);

Console.WriteLine("=== 초기 패 ===");
dealer.DealerFirstShowInfo();
Console.WriteLine();
player.ShowInfo();
Console.WriteLine();

bool IsPlayerBust = false;
bool IsDealerBust = false;

while (true)
{
    if (player.Total > 21)
    {
        IsPlayerBust = true;
        Console.WriteLine("버스트! 21을 초과했습니다.");
        Console.WriteLine();
        break;
    }

    Console.Write("H(Hit) 또는 S(Stand)를 선택하세요: ");
    string input  = Console.ReadLine().ToUpper();
    Console.WriteLine();

    if (input == "H")
    {
        player.CardDraw(card);
        string DrawCard = player.Card.ToString();
        Console.WriteLine();
        Console.WriteLine($"{player.Name}가 카드를 받았습니다: [{DrawCard}]");
        player.ShowInfo();
        Console.WriteLine();
    }

    else if (input == "S")
    {
        Console.WriteLine($"{player.Name}가 Stand를 선택했습니다.");
        Console.WriteLine();
        break;
    }

    else
    {
        Console.WriteLine("'H'나 'S'중 선택하세요.");
    }
}

Console.WriteLine($"{dealer.Name}의 숨겨진 카드: [{dealer.DealerFirstCard}]");
dealer.ShowInfo();
Console.WriteLine();

while (true)
{
    if (player.Total > 21)
    {
        break;
    }    

    if (dealer.Total > 21)
    {
        IsDealerBust = true;
        Console.WriteLine("버스트! 21을 초과했습니다.");
        Console.WriteLine();
        break;
    }

    if (dealer.Total >= 17 && dealer.Total <= 21)
    {
        break;
    }

    while (dealer.Total < 17)
    {
        dealer.CardDraw(card);
        string DrawCard = dealer.Card.ToString();
        Console.WriteLine();
        Console.WriteLine($"{dealer.Name}가 카드를 받았습니다: [{DrawCard}]");
        dealer.ShowInfo();
        Console.WriteLine();
    }
}

Console.WriteLine("=== 게임 결과 ===");
Console.WriteLine($"{player.Name}: {player.Total}점");
Console.WriteLine($"{dealer.Name}: {dealer.Total}점");
Console.WriteLine();


if (IsPlayerBust == true || (player.Total < dealer.Total && IsDealerBust == false))
{
    Console.WriteLine("플레이어 패배...");
    Console.WriteLine();
}

else if (player.Total == dealer.Total)
{
    Console.WriteLine("무승부!");
    Console.WriteLine();
}

else
{
    Console.WriteLine("플레이어 승리!");
    Console.WriteLine();
}

Console.Write("새 게임을 하시겠습니까? (Y/N): ");
string newGame = Console.ReadLine().ToUpper();

if (newGame == "Y")
{
    Console.Clear();
    Process.Start(Environment.ProcessPath);
    Environment.Exit(0);
}

if (newGame == "N")
{
    Environment.Exit(0);
}