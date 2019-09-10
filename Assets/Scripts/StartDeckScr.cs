using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartDeckScr : MonoBehaviour
{
    public List<Card> StartDeck;
    public TMP_InputField attack;
    public TMP_InputField defense;
    public TMP_InputField heal;
    public TMP_InputField crit;
    public TMP_InputField counter_attack;
    public TMP_InputField vampire;
    public GameObject PanelStartDeck;
    public GameObject PanelGame;

    public int TotalCards;



    private void Start()
    {
        StartDeck = new List<Card>();
    }

    public void Fill()
    {
        if (attack.text!= "")
        {
            for (int i = 0; i < Convert.ToInt32(attack.text); i++) 
            {
                StartDeck.Add(CardManager.AllCards[0]);
            }
            TotalCards += Convert.ToInt32(attack.text);
        }
        if (defense.text != "")
        {
            for (int i = 0; i < Convert.ToInt32(defense.text); i++)
            {
                StartDeck.Add(CardManager.AllCards[1]);
            }
            TotalCards += Convert.ToInt32(defense.text);
        }
        if (heal.text != "")
        {
            for (int i = 0; i < Convert.ToInt32(heal.text); i++)
            {
                StartDeck.Add(CardManager.AllCards[2]);
            }
            TotalCards += Convert.ToInt32(heal.text);
        }
        if (crit.text != "")
        {
            for (int i = 0; i < Convert.ToInt32(crit.text); i++)
            {
                StartDeck.Add(CardManager.AllCards[3]);
            }
            TotalCards += Convert.ToInt32(crit.text);
        }
        if (counter_attack.text != "")
        {
            for (int i = 0; i < Convert.ToInt32(counter_attack.text); i++)
            {
                StartDeck.Add(CardManager.AllCards[4]);
            }
            TotalCards += Convert.ToInt32(counter_attack.text);
        }
        if (vampire.text != "")
        {
            for (int i = 0; i < Convert.ToInt32(vampire.text); i++)
            {
                StartDeck.Add(CardManager.AllCards[5]);
            }
            TotalCards += Convert.ToInt32(vampire.text);
        }
        PanelGame.SetActive(true);
        PanelStartDeck.SetActive(false);
    }
}
