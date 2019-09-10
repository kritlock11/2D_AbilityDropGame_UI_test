//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;


//public class Game : MonoBehaviour
//{
//    public float DeckCardsCount;

//    public List<GameObject> PlayerDeck, EnemyDeck;
//    public Game()
//    {
//        PlayerDeck = GiveDeckCard();
//        EnemyDeck = GiveDeckCard();
//    }

//    List<Card> GiveDeckCard()
//    {
//        List<GameObject> list = new List<GameObject>();
//        for (int i = 0; i < 10; i++)
//        {
//            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
//        }
//        return list;
//    }
//    //List<Card> GiveDeckCard()
//    //{
//    //    List<Card> list = new List<Card>();
//    //    for (int i = 0; i < 10; i++)
//    //    {
//    //        list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
//    //    }
//    //    return list;
//    //}

//}
//public class GameManagerScr : MonoBehaviour
//{
//    public Game CurrentGame;
//    public Transform PlayerField, EnemyField;
//    public GameObject CardPrefab;

//    private void Start()
//    {
//        CurrentGame = new Game();
//        GiveFieldCards(CurrentGame.PlayerDeck, PlayerField);
//        GiveFieldCards(CurrentGame.EnemyDeck, EnemyField);
//    }

//    void GiveFieldCards(List<Card> deck, Transform fielf)
//    {
//        int i = 0;
//        while (i++< 10) //CurrentGame.DeckCardsCount
//        {
//            GiveCardsToField(deck, fielf);
//        }
//    }

//    void GiveCardsToField(List<Card> deck, Transform fielf)
//    {
//        if (deck.Count==0)
//        {
//            return;
//        }
//        Card card = deck[0];
//        GameObject cardGO = Instantiate(CardPrefab,fielf,false);
//        cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
//        deck.RemoveAt(0);
//    }


//}
