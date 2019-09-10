using System;
using System.Collections.Generic;
using UnityEngine;

public class CardChainController : MonoBehaviour
{
    public List<CardInfoScr> CardChain;
    public event Action OnChildCountChange;
    [SerializeField] private int childCount;

    public float attackCritMultiplier;

    public float attackCounter;
    public float defenseCounter;
    public float healCounter;
    public float critCounter;
    public float counterAttackCounter;
    public float vampireCounter;

    private CardInfoScr card;

    public int ChildCount
    {
        get => childCount;
        set
        {
            childCount = value;
            if (OnChildCountChange != null)
            {
                OnChildCountChange.Invoke();
            }
        }
    }
    private void Awake()
    {
        ChangeChildList();
        //attackCounter = defenseCounter = healCounter = critCounter = counterAttackCounter = vampireCounter = 0;
    }
    private void Start()
    {
        OnChildCountChange += ChangeChildList;

        //GetChildCunt();
    }
    private void Update()
    {
        GetChildCunt();
        //Debug.Log($"{attackMultiplier}");
    }
    void GetChildCunt()
    {
        ChildCount = transform.childCount;
    }
    void ChangeChildList()
    {
        CardChain = ChildList();
    }
    List<CardInfoScr> ChildList()
    {
        List<CardInfoScr> list = new List<CardInfoScr>();
        attackCounter = defenseCounter = healCounter = critCounter = counterAttackCounter = vampireCounter = 0;
        for (int i = 0; i < ChildCount; i++)
        {
            card = transform.GetChild(i).gameObject.GetComponent<CardInfoScr>();

            if (card)
            {
                list.Add(card);
                switch (card.ID)
                {
                    case 1:
                        attackCounter++;
                        break;
                    case 2:
                        defenseCounter++;
                        break;
                    case 3:
                        healCounter++;
                        break;
                    case 4:
                        critCounter++;
                        break;
                    case 5:
                        counterAttackCounter++;
                        break;
                    case 6:
                        vampireCounter++;
                        break;
                }

                if (attackCounter == 3 || defenseCounter == 3 || healCounter == 3 || critCounter == 3 || counterAttackCounter == 3 || vampireCounter == 3)
                {
                    var card_0 = transform.GetChild(0).gameObject.GetComponent<CardInfoScr>();
                    var card_1 = transform.GetChild(1).gameObject.GetComponent<CardInfoScr>();
                    var card_2 = transform.GetChild(2).gameObject.GetComponent<CardInfoScr>();

                    int max = 0;
                    for (int j = 0; j < transform.childCount; j++)
                    {
                        var attack = transform.GetChild(j).gameObject.GetComponent<CardInfoScr>().Attack;
                        var defense = transform.GetChild(j).gameObject.GetComponent<CardInfoScr>().Defense;
                        var heal = transform.GetChild(j).gameObject.GetComponent<CardInfoScr>().Heal; 
                        var crit = transform.GetChild(j).gameObject.GetComponent<CardInfoScr>().CritMultiplier; 

                        if (attack > max) max = attack;
                        if (defense > max) max = defense;
                        if (heal > max) max = heal;
                        if (crit > max) max = crit;

                    }

                    if (card_0.Attack == max && card_1.Attack == max && card_2.Attack == max)
                    {
                        card_1.Attack = card_1.Attack * 3;
                        card_1.AttackText.text = card_1.Attack.ToString();
                        Destroy(transform.GetChild(0).gameObject);
                        Destroy(transform.GetChild(2).gameObject);
                    }
                    if (card_0.Defense == max && card_1.Defense == max && card_2.Defense == max)
                    {
                        card_1.Defense = card_1.Defense * 3;
                        card_1.DefenseText.text = card_1.Defense.ToString();
                        Destroy(transform.GetChild(0).gameObject);
                        Destroy(transform.GetChild(2).gameObject);
                    }
                    if (card_0.Heal == max && card_1.Heal == max && card_2.Heal == max)
                    {
                        card_1.Heal = card_1.Heal * 3;
                        card_1.HealText.text = card_1.Heal.ToString();
                        Destroy(transform.GetChild(0).gameObject);
                        Destroy(transform.GetChild(2).gameObject);
                    }
                    if (card_0.CritMultiplier == max && card_1.CritMultiplier == max && card_2.CritMultiplier == max)
                    {
                        card_1.CritMultiplier = card_1.CritMultiplier * 3;
                        card_1.CritMultiplierText.text = card_1.CritMultiplier.ToString();
                        Destroy(transform.GetChild(0).gameObject);
                        Destroy(transform.GetChild(2).gameObject);
                    }
                }
            }
        }
        return list;
    }
}
