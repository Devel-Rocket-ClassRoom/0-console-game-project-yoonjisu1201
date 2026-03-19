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
    public GameManager()
    {

    }

    // 카테고리 선택
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
                // 지뢰 단어 랜덤 생성하기
                Current_Category = wordData.CategoryNames[num];
                for (int i = 0; i < length; i++)
                {
                    
                }
                Current_MineWords.Add(Current_Category[random.Next(1, Current_Category.Length)]);



            }


        }

    }

    // 사용자 입력
    public void Input()   
    {
        //단어 유효성 검사 (null 일때, 저장된 단어리스트에 사용자 입력 단어가 없을때
        while (true)   
        {
            Console.WriteLine("입력하세요");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("단어를 다시 입력해주세요!");
                continue;
            }
            else if (!wordData.fruits.Contains(input.Trim()))
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
            wordData.CategoryName.v
        }
    }

    public void MineWords(int count)
    {
        Current_MineWords
    }


}
