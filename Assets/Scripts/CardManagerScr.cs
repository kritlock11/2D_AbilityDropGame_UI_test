using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public enum AbilityType
    {
        NO_ABILITY,
        BUFF,
        DEBUFF,
        CRIT,
        CHANCE,
        COUNTER_ATTACK
    }

    public int ID;
    public string Name;
    public Sprite Logo;
    public int Attack, Defense, Heal, CritMultiplier;

    public Card(int id, string name, string logoPath, int attack, int defense, int heal, int critMultiplier = 0)
    {
        ID = id;
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
        Heal = heal;
        CritMultiplier = critMultiplier;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}


public class CardManagerScr : MonoBehaviour
{
    private void Awake()
    {
        CardManager.AllCards.Add(new Card(1, "attack", "Sprites/Cards/attack", 1, 0, 0));
        CardManager.AllCards.Add(new Card(2, "defense", "sprites/Cards/defense", 0, 1, 0));
        CardManager.AllCards.Add(new Card(3, "heal", "Sprites/Cards/heal", 0, 0, 1));
        CardManager.AllCards.Add(new Card(4, "crit", "Sprites/Cards/crit", 0, 0, 0, 2));
        CardManager.AllCards.Add(new Card(5, "counter_attack", "Sprites/Cards/counter_attack", 1, 0, 0));
        CardManager.AllCards.Add(new Card(6, "vampire", "Sprites/Cards/vampire", 0, 0, 0));

        //CardManager.AllCards.Add(new Card(7, "debuff", "Sprites/Cards/debuff", 0, 0, 0, Card.AbilityType.DEBUFF));
        //CardManager.AllCards.Add(new Card(8, "chance", "Sprites/Cards/chance", 0, 0, 0, Card.AbilityType.CHANCE));
    }


}
