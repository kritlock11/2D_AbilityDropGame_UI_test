using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardCardMngr : MonoBehaviour
{
    public PlayerController playerController;
    public EnemyController enemyController;
    private DeckPoolCards deckPoolCards;
    private void Start()
    {
        deckPoolCards = FindObjectOfType<DeckPoolCards>();
    }

    public static List<GameObject> onBoardPlayer = new List<GameObject>();
    //public static List<GameObject> onBoardEnemy = new List<GameObject>();

    private void Update()
    {
        //for (int i = 0; i < onBoardPlayer.Count; i++)
        //{
        //    if (playerController != null && onBoardPlayer[i] != null && onBoardPlayer[i].transform.position.y <= playerController.transform.position.y)
        //    {
        //        var CardChain = onBoardPlayer[i].GetComponent<CardChainController>().CardChain;
        //        for (int j = 0; j < CardChain.Count; j++)
        //        {
        //            if (CardChain[j].GetComponent<CardInfoScr>().Name.text == "attack")
        //            {
        //                Debug.Log($"{CardChain.Count}");
        //                playerController.Hurt(CardChain[j].GetComponent<CardInfoScr>().Attack);
        //            }
        //            else if (CardChain[j].GetComponent<CardInfoScr>().Name.text == "defense")
        //            {
        //                playerController.AddDefense(CardChain[j].GetComponent<CardInfoScr>().Defense);
        //            }
        //        }
        //        Destroy(onBoardPlayer[i]);
        //    }
        //}
    }





    //public static List<GameObject> onBoardPlayer = new List<GameObject>();
    ////public static List<GameObject> onBoardEnemy = new List<GameObject>();

    //private void Update()
    //{
    //    for (int i = 0; i < onBoardPlayer.Count; i++)
    //    {
    //        if (playerController != null && onBoardPlayer[i] != null && onBoardPlayer[i].transform.position.y <= playerController.transform.position.y)
    //        {
    //            var CardChain = onBoardPlayer[i].GetComponent<CardChainController>().CardChain;
    //            for (int j = 0; j < CardChain.Count; j++)
    //            {
    //                if (CardChain[j].GetComponent<CardInfoScr>().Name.text == "attack")
    //                {
    //                    Debug.Log($"{CardChain.Count}");
    //                    playerController.Hurt(CardChain[j].GetComponent<CardInfoScr>().Attack);
    //                }
    //                else if (CardChain[j].GetComponent<CardInfoScr>().Name.text == "defense")
    //                {
    //                    playerController.AddDefense(CardChain[j].GetComponent<CardInfoScr>().Defense);
    //                }
    //            }
    //            Destroy(onBoardPlayer[i]);
    //        }
    //    }
    //}






}
