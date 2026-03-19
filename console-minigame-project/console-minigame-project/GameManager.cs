using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

class GameManager
{
    Player player = new Player();
    WordData wordData = new WordData();

    private string[] Current_Category;
    private List<string> Current_MineWords;
    private int Minecount = 10;     // 기초 구현 완료 후 난이도 조절할 시에 사용
    private int TurnCount = 1;
    private string UserInput;
    private bool isGameOver = false;
    private string Current_keyword;
    public GameManager()
    {

    }

    // 카테고리 선택, 랜덤 지뢰 생성
    public void SetCategory()
    {
        Random random = new Random();
        Current_MineWords = new List<string>();
        while (true)
        {
            Console.WriteLine("키워드를 선택해주세요(한글만 입력 가능): \n\t1. 과일\n\t2. ??\n\t3. ??\n\t4. \n\t5. ");
            string input = Console.ReadLine() ?? "";
            if (input is "과일" or "2" or "3" or "4" or "5")
            {
                // 현재 카테고리 단어들만 변수에 담아두기
                // 지뢰 단어 n 개 랜덤 생성하기 
                Current_Category = wordData.CategoryNames[input];
                Current_keyword = input;
                for (int i = 0; i < Minecount; i++)
                {
                    if (Current_MineWords.Contains(Current_Category[random.Next(1, Current_Category.Length)]))
                    {
                        i--;
                    }
                    else
                    {
                        Current_MineWords.Add(Current_Category[random.Next(1, Current_Category.Length)]);
                    }
                }
                Status();
                Console.WriteLine("그럼 단어 지뢰 찾기를 시작합니다  :)\n");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("키워드를 다시 입력해주세요!");
                continue;
            }
        }
    }

    // 사용자 단어 입력
    public void Input()
    {
        //단어 유효성 검사 (null 일때, 저장된 단어리스트에 사용자 입력 단어가 없을때
        Status();
        Console.Write("숨겨진 지뢰를 피해 단어를 입력해주세요!: ");
        while (true)
        {
            string input = Console.ReadLine();
            Console.Clear();
            if (string.IsNullOrWhiteSpace(input))
            {
                Status();
                Console.Write("공백입니다. 키워드에 맞춰 다시 한번 입력해주세요: ");
                continue;
            }
            else if (!Current_Category.Contains(input.Trim()))
            {
                Status();
                Console.Write("저장되어 있지 않는 단어입니다. 키워드에 맞춰 다시 한번 입력해주세요!: ");
                continue;
            }
            else if (player.InputHistory.Contains(input.Trim()))
            {
                Status();
                Console.Write("지뢰가 통과된 단어입니다. 키워드에 맞춰 다시 한번 입력해주세요!: ");
                continue;
            }
            else
            {
                UserInput = input.Trim();
                player.InputHistory.Add(UserInput);
                break;
            }
        }
    }
    public void Status()
    {
        Console.WriteLine($"[키워드] {Current_keyword} \n[현재 턴] {TurnCount} \n[스코어] {player.Score}점\n");
    }

    // 지뢰 검사 메서드
    public void CheckIsMine()
    {
        char[] mineWords = string.Concat(Current_MineWords).ToCharArray();
        char[] userWords = UserInput.ToCharArray();
        var interction = new HashSet<char>(mineWords);
        interction.IntersectWith(userWords);

        Status();
        // 지뢰와 완전히 일치할 경우
        if (Current_MineWords.Contains(UserInput))
        {
            Console.WriteLine($"파방!! {UserInput}은(는) 지뢰입니다. .");
            isGameOver = true;
            // 사망 시 행동할 로직
        }
        // 지뢰와 n 글자 일치할 경우
        switch (interction.Count)
        {
            case 0:
                Console.WriteLine("지뢰가 감지되지 않았습니다! [안전]");
                break;

            case 1:
                Console.WriteLine("삐빅-! 지뢰가 감지되었습니다. [주의: 1글자]");
                break;

            case 2:
                Console.WriteLine("지뢰가 터지기 일보 직전입니다!! [위험: 2글자]");
                break;

            case 3:
                Console.WriteLine("지뢰가 바로 눈앞에 있습니다!! [긴급: 3글자]");
                break;
            default:
                Console.WriteLine("지뢰가 바로 눈앞에 있습니다!! [긴급: 4글자 이상]");
                break;
        }
        TurnCount++;
        player.Score += 10;
        Console.WriteLine("다음 턴으로 넘어갑니다 -- go!.");
        Console.WriteLine("(Enter를 눌러주세요.)");
        Console.ReadLine();

    }

    public void Play()
    {
        SetCategory();
        while (!isGameOver || TurnCount < 11)
        {
            Console.Clear();
            Input();
            Console.Clear();
            CheckIsMine();
        }
    }


}
