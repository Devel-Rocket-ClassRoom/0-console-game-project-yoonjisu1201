using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class GameManager
{
    Player player = new Player();
    WordData wordData = new WordData();

    private string[] Current_Category;
    private List<string> Current_MineWords;
    private int TurnCount = 0;
    private string UserInput;
    private bool isGameOver = false;
    public GameManager()
    {

    }

    // 카테고리 선택, 랜덤 지뢰 생성
    public void SetCategory()
    {
        Random random = new Random();
        while (true)
        {
            Console.WriteLine("Word 주제를 선택해주세요(숫자만 입력 가능): \n\t1. 과일\n\t2. ??\n\t3. ??\n\t4. \n\t5. ");
            string input = Console.ReadLine() ?? "";
            if (!int.TryParse(input, out int num) && num >= 1 && num <=5)
            {
                Console.WriteLine("번호를 다시 입력해주세요!");
                continue;
            }
            else
            {
                // 현재 카테고리 단어들만 변수에 담아두기
                // 지뢰 단어 n 개 랜덤 생성하기 
                Current_Category = wordData.CategoryNames[num];
                for (int i = 0; i < 3; i++)
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
            }
        }
    }

    // 사용자 단어 입력
    public void Input()   
    {
        //단어 유효성 검사 (null 일때, 저장된 단어리스트에 사용자 입력 단어가 없을때
        while (true)   
        {
            Console.WriteLine("숨겨진 지뢰를 피해 단어를 입력해주세요!");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("단어를 다시 입력해주세요!");
                continue;
            }
            else if (!Current_Category.Contains(input.Trim()))
            {
                Console.WriteLine("단어를 다시 입력해주세요!");
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

    // 지뢰 검사 메서드
    public void CheckIsMine()
    {
        // 지뢰와 완전히 일치할 경우
        if (Current_MineWords.Contains(UserInput))
        {
            Console.WriteLine("파방!! 지뢰가 터졌습니다. .");
            isGameOver = true;
            // 사망 시 행동할 로직
        }
        // 지뢰와 n 글자 일치할 경우
        switch 
    }


}
