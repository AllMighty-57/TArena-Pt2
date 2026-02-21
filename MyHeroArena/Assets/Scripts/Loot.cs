using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1
public struct Loot
{
    // 2
    public string Name;
    public int Rarity;

    // 3
    public Loot(string name, int rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
    }
}