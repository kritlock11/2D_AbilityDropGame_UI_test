//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeckMngr : MonoBehaviour
//{
//    public Transform PPos, PParent;
//    public Transform EPos, EParent;
//    public int PoolSize;
//    public GameObject PPrefab;
//    public GameObject EPrefab;

//    private int index;

//    public List<CardInfoScr> PlayerDeckPool;
//    public List<CardInfoScr> EnemyDeckPool;

//    //public List<CardInfoScr> PlayerInCardPool;
//    //public List<CardInfoScr> EnemyInCardPool;

//    //public List<CardInfoScr> PlayerOutCardPool;
//    //public List<CardInfoScr> EnemyOutCardPool;

//    private float timeBtwSpawn;
//    public float startTimeBtwSpawn;


//    private PlayerController playerController;
//    private EnemyController enemyController;

//    private void Start()
//    {
//        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
//        enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();

//        PlayerDeckPool = new List<CardInfoScr>();
//        EnemyDeckPool = new List<CardInfoScr>();
//        FillDeckPool(PlayerDeckPool, PPrefab, PPos, PParent);
//        FillDeckPool(EnemyDeckPool, EPrefab, EPos, EParent);
//    }

//    void FillDeckPool(List<CardInfoScr> deck, GameObject prefab, Transform Pos, Transform Parent)
//    {
//        for (int i = 0; i < PoolSize; i++)
//        {
//            var obj = Instantiate(prefab, Pos.position, Quaternion.identity, Parent);
//            obj.SetActive(false);
//            deck.Add(obj.GetComponent<CardChainController>().transform.GetChild(0).GetComponent<CardInfoScr>());
//        }
//    }


//    void CardsFight(CardInfoScr PlayerCard, CardInfoScr EnemyCard)
//    {

//    }


//    void ChainMovement(List<CardInfoScr> obj)
//    {
//        if (timeBtwSpawn <= 0)
//        {
//            if (index >= PoolSize)
//            {
//                return;
//            }

//            obj[index].gameObject.transform.parent.SetActive(true);
//            index++;
//            timeBtwSpawn = startTimeBtwSpawn;
//        }
//        else
//        {
//            timeBtwSpawn -= Time.deltaTime;
//        }
//    }

//    private void FixedUpdate()
//    {
//        ChainMovement(PlayerDeckPool);
//        ChainMovement(EnemyDeckPool);
//    }
//    private void Update()
//    {
//        //ActionMngr(PlayerDeckPool);
//        //ActionMngr(EnemyDeckPool);

//    }


//    void DeActivate(GameObject CardChain)
//    {
//        CardChain.SetActive(false);
//        CardChain.transform.position = transform.position;
//    }
//    public bool IsAttackingPlayerChain(GameObject CardChain)
//    {
//        return CardChain.transform.position.y <= playerController.transform.position.y &&
//           ((Mathf.Abs(CardChain.transform.position.x - playerController.transform.position.x) <= 0.5f));

//    }
//    public bool IsAttackingEnemyChain(GameObject CardChain)
//    {
//        return CardChain.transform.position.y <= enemyController.transform.position.y &&
//           ((Mathf.Abs(CardChain.transform.position.x - enemyController.transform.position.x) <= 0.5f));

//    }

//    List<CardInfoScr> CardChain;
//    CardChainController CCC;

//    //void ActionMngr(List<CardInfoScr> List)
//    //{
//    //    for (int i = 0; i < List.Count; i++)
//    //    {
//    //        //List<CardInfoScr> CardChain = DeckPool[i].GetComponent<CardChainController>().CardChain;
//    //        //CardChainController CCC = DeckPool[i].GetComponent<CardChainController>();

//    //        if (playerController != null && List[i] != null && IsPlayerDeckPool(List[i].gameObject))
//    //        {
//    //            CardChain = List[i].GetComponent<CardChainController>().CardChain;
//    //            CCC = List[i].GetComponent<CardChainController>();
//    //            playerController.playerCAcounter = CCC.counterAttackCounter;

//    //            for (int j = 0; j < CardChain.Count; j++)
//    //            {
//    //                switch (CCC.critCounter)
//    //                {
//    //                    case 1:
//    //                        if (CardChain[j])
//    //                        {
//    //                            CardChain[j].Attack = CardChain[j].Attack * 2;
//    //                            CardChain[j].Defense = CardChain[j].Defense * 2;
//    //                            CardChain[j].Heal = CardChain[j].Heal * 2;
//    //                        }
//    //                        break;
//    //                    case 2:
//    //                        if (CardChain[j])
//    //                        {
//    //                            CardChain[j].Attack = CardChain[j].Attack * 4;
//    //                            CardChain[j].Defense = CardChain[j].Defense * 4;
//    //                            CardChain[j].Heal = CardChain[j].Heal * 4;
//    //                        }
//    //                        break;
//    //                }
//    //                switch (CardChain[j].ID)
//    //                {
//    //                    case 1:
//    //                        enemyController.Hurt(CardChain[j].Attack);
//    //                        switch (CCC.vampireCounter)
//    //                        {
//    //                            case 1:
//    //                                if (CardChain[j])
//    //                                {
//    //                                    playerController.MaxHP += CardChain[j].Attack;
//    //                                    //playerController.Heal(CardChain[j].Attack);
//    //                                }
//    //                                break;
//    //                            case 2:
//    //                                if (CardChain[j])
//    //                                {
//    //                                    playerController.MaxHP += CardChain[j].Attack * 2;
//    //                                    //playerController.Heal(CardChain[j].Attack*2);
//    //                                }
//    //                                break;
//    //                        }
//    //                        break;
//    //                    case 2:
//    //                        playerController.AddDefense(CardChain[j].Defense);
//    //                        break;
//    //                    case 3:
//    //                        if (CCC.healCounter == 3)
//    //                        {
//    //                            playerController.MaxHP += 1;
//    //                        }
//    //                        else
//    //                        {
//    //                            playerController.Heal(CardChain[j].Heal);
//    //                        }
//    //                        break;
//    //                    case 5:
//    //                        enemyController.Hurt(CardChain[j].Attack);
//    //                        switch (CCC.vampireCounter)
//    //                        {
//    //                            case 1:
//    //                                if (CardChain[j])
//    //                                {
//    //                                    playerController.MaxHP += CardChain[j].Attack;
//    //                                    //playerController.Heal(CardChain[j].Attack);
//    //                                }
//    //                                break;
//    //                            case 2:
//    //                                if (CardChain[j])
//    //                                {
//    //                                    playerController.MaxHP += CardChain[j].Attack * 2;
//    //                                    //playerController.Heal(CardChain[j].Attack*2);
//    //                                }
//    //                                break;
//    //                        }
//    //                        break;

//    //                    default:
//    //                        CardPool.Remove(CardChain[j]);
//    //                        OutCardPool.Add(CardChain[j]);
//    //                        break;
//    //                }
//    //            }
//    //            DeActivate(DeckPool[i]);
//    //        }
//    //        else if (enemyController != null && DeckPool[i] != null && IsEnemyDeckPool(DeckPool[i]))
//    //        {
//    //            List<CardInfoScr> CardChain = DeckPool[i].GetComponent<CardChainController>().CardChain;
//    //            CardChainController CCC = DeckPool[i].GetComponent<CardChainController>();
//    //            enemyController.enemyCAcounter = CCC.counterAttackCounter;

//    //            for (int j = 0; j < CardChain.Count; j++)
//    //            {
//    //                switch (CardChain[j].ID)
//    //                {
//    //                    case 1:
//    //                        playerController.Hurt(CardChain[j].Attack);
//    //                        break;
//    //                    case 2:
//    //                        enemyController.AddDefense(CardChain[j].Defense);
//    //                        break;
//    //                    case 3:
//    //                        enemyController.Heal(CardChain[j].Heal);
//    //                        break;
//    //                    case 5:
//    //                        playerController.Hurt(CardChain[j].Attack);
//    //                        break;

//    //                    default:
//    //                        CardPool.Remove(CardChain[j]);
//    //                        OutCardPool.Add(CardChain[j]);
//    //                        break;
//    //                }
//    //            }
//    //            DeActivate(DeckPool[i]);
//    //        }
//    //    }
//    //}
//}
