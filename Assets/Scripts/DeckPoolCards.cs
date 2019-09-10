using System.Collections.Generic;
using UnityEngine;

public class DeckPoolCards : MonoBehaviour
{
    public Transform Pos, Parent;
    public int PoolSize;
    private GameObject _obj;
    public GameObject Prefab;

    private int index;

    public List<GameObject> DeckPool;
    public List<CardInfoScr> CardPool;
    public List<CardInfoScr> OutCardPool;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;


    private PlayerController playerController;
    private EnemyController enemyController;

    public StartDeckScr startDeckScr;



    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        startDeckScr = Camera.main.GetComponent<StartDeckScr>();

        PoolSize = startDeckScr.TotalCards;

        DeckPool = new List<GameObject>();
        for (int i = 0; i < PoolSize; i++)
        {
            _obj = Instantiate(Prefab, Pos.position, Quaternion.identity, Parent);
            _obj.SetActive(false);

            DeckPool.Add(_obj);
        }
        CardPool = GetCards();
    }
    private void FixedUpdate()
    {
        SetActivePool();
    }
    private void Update()
    {
        ActionMngr();
    }

    private void SetActivePool()
    {
        if (timeBtwSpawn <= 0)
        {
            if (index >= PoolSize)
            {
                return;
            }

            DeckPool[index].SetActive(true);

            if (gameObject.name == "PlayerCardSpawner")
            {
                for (int i = 0; i < DeckPool[index].GetComponent<CardChainController>().transform.childCount; i++)
                {
                    Card card = Camera.main.GetComponent<StartDeckScr>().StartDeck[Random.Range(0, startDeckScr.StartDeck.Count)];
                    DeckPool[index].GetComponent<CardChainController>().transform.GetChild(i).GetComponent<CardInfoScr>().ShowCardInfo(card);
                    Camera.main.GetComponent<StartDeckScr>().StartDeck.Remove(card);
                }
            }
            if (gameObject.name == "EnemyCardSpawner")
            {
                for (int i = 0; i < DeckPool[index].GetComponent<CardChainController>().transform.childCount; i++)
                {
                    Card card = CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)];
                    DeckPool[index].GetComponent<CardChainController>().transform.GetChild(i).GetComponent<CardInfoScr>().ShowCardInfo(card);
                }
            }

            index++;
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    List<CardInfoScr> GetCards()
    {
        List<CardInfoScr> CardPool = new List<CardInfoScr>();

        for (int i = 0; i < DeckPool.Count; i++)
        {
            for (int j = 0; j < DeckPool[i].GetComponent<CardChainController>().transform.childCount; j++)
            {
                CardPool.Add(DeckPool[i].GetComponent<CardChainController>().transform.GetChild(j).GetComponent<CardInfoScr>());
            }
        }
        return CardPool;
    }
    public bool IsPlayerDeckPool(GameObject obj)
    {
        if (obj != null && playerController != null)
            return obj?.transform.position.y <= playerController.transform.position.y &&
           ((Mathf.Abs(obj.transform.position.x - playerController.transform.position.x) <= 0.5f));
        return false;
    }
    public bool IsEnemyDeckPool(GameObject obj)
    {
        if (obj != null && enemyController != null)
            return obj?.transform.position.y <= enemyController.transform.position.y &&
               ((Mathf.Abs(obj.transform.position.x - enemyController.transform.position.x) <= 0.5f));
        return false;
    }
    public List<CardInfoScr> PlayerChainList()
    {
        for (int i = 0; i < DeckPool.Count; i++)
        {
            List<CardInfoScr> CardChain = DeckPool[i].GetComponent<CardChainController>().CardChain;
            if (IsPlayerDeckPool(DeckPool[i]))
            {
                return CardChain;
            }
        }
        return null;
    }
    public List<CardInfoScr> EnemyChainList()
    {
        for (int i = 0; i < DeckPool.Count; i++)
        {
            List<CardInfoScr> CardChain = DeckPool[i].GetComponent<CardChainController>().CardChain;
            if (IsEnemyDeckPool(DeckPool[i]))
            {
                return CardChain;
            }
        }
        return null;
    }
    public void DeActivate(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
    }
    void ActionMngr()
    {
        for (int i = 0; i < DeckPool.Count; i++)
        {
            if (IsPlayerDeckPool(DeckPool[i]))
            {
                DeActivate(DeckPool[i]);
            }
            if (IsEnemyDeckPool(DeckPool[i]))
            {
                DeActivate(DeckPool[i]);
            }
        }
    }
    public void Clear()
    {
        DeckPool.Clear();
        CardPool.Clear();
        OutCardPool.Clear();
    }

}
