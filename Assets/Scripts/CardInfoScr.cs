using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScr : MonoBehaviour
{
    public int ID;
    public Card SelfCard;
    public TextMeshProUGUI Name;
    public Image Logo;
    public int Attack, Defense, Heal, CritMultiplier;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI HealText;
    public TextMeshProUGUI CritMultiplierText;

    public void ShowCardInfo(Card card)
    {
        ID = card.ID;
        SelfCard = card;
        Name.text = card.Name;
        //Multiplier.text = intMultiplier.ToString();
        Logo.sprite = card.Logo;
        Attack = card.Attack;
        Defense = card.Defense;
        Heal = card.Heal;
        CritMultiplier = card.CritMultiplier;
        //Logo.preserveAspect = true;
    }

    private void Start()
    {
        //ShowCardInfo(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
    }




}
