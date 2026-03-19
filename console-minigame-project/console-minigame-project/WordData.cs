using System;
using System.Collections;
using System.Collections.Generic;


public class WordData
{
    public Dictionary<string, string[]> CategoryNames;

    public string[] fruits = { "사과", "배", "포도", "딸기", "바나나", "귤", "수박", "복숭아", "참외", "토마토"
        , "감", "밤", "대추", "매실", "살구", "자두", "체리", "앵두", "석류", "무화과", "유자", "모과", "산딸기", "머루", "다래"
        , "망고", "파인애플", "코코넛", "키위", "파파야", "두리안", "망고스틴", "람부탄", "리치", "아보카도"
        , "구아바", "패션후르츠", "잭푸르트", "사포딜라", "슈가애플", "스타후르츠", "체리모야", "타마린드", "대추야자"
        , "블루베리", "라즈베리", "크랜베리", "아로니아", "오디", "복분자", "구기자", "빌베리", "블랙베리", "고지베리"
        , "까마중", "보리수", "피살리스", "엘더베리", "초코베리", "오렌지", "레몬", "라임", "자몽", "한라봉", "천혜향"
        , "레드향", "황금향", "청견", "금귤", "탱자", "깔라만시", "시트론", "포멜", "메론"};

    public string[] animals = { };
    public string[] Category3 = { };
    public string[] Category4 = { };
    public string[] Category5 = { };


    public WordData()
    {
        CategoryNames = new Dictionary<string, string[]> 
        {
            {"과일", fruits }, {"2", animals}, {"3", Category3}, {"4", Category4}, {"5", Category5} 
        };
    }

}
