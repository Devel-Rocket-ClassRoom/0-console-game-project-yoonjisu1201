using System;
using System.Collections.Generic;

public class Player
{
    public int Score { get; set; } = 0;
    // public int Iife { get; set; } = 3; 나중에 심화 모드 추가 가능하면 사용
    public List<string> InputHistory = new List<string>();
    public bool HasItem = false;
    
}
