using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionsMngr : MonoBehaviour
{
    public DeckPoolCards playerPoolCards;
    public DeckPoolCards enemyPoolCards;
    private List<CardInfoScr> playerList;
    private List<CardInfoScr> enemyList;

    public GameObject def;
    public GameObject vic;

    public CardChainController playerCardChainController;
    public CardChainController enemyCardChainController;

    private PlayerController playerController;
    private EnemyController enemyController;

    private float defMult;
    private float attMult;

    public GameObject Panel;
    bool active = false;


    private void Start()
    {
        Time.timeScale = 1f;

    }

    private void Update()
    {
        ActionMNGR();
        Die();
        SetActive();
    }
    
    void SetActive()
    {
        if (active== false && Panel.activeInHierarchy == true)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
            active = true;
        }
    }


    void ActionMNGR()
    {
        if (playerPoolCards.PlayerChainList() != null && enemyPoolCards.EnemyChainList() != null)
        {
            playerList = playerPoolCards.PlayerChainList();
            enemyList = enemyPoolCards.EnemyChainList();

            if (playerList.Count > 0)
            {
                playerCardChainController = playerList[0].gameObject.transform.parent.GetComponent<CardChainController>();
                playerController.playerCounterAttackCounter = playerCardChainController.counterAttackCounter;
            }
            if (enemyList.Count > 0)
            {
                enemyCardChainController = enemyList[0].gameObject.transform.parent.GetComponent<CardChainController>();
                enemyController.enemyCounterAttackCounter = enemyCardChainController.counterAttackCounter;
            }


            if (playerList.Exists(x => x.ID == 4) || enemyList.Exists(x => x.ID == 4)) //crit
            {
                int max = 0;
                for (int j = 0; j < playerList.Count; j++)
                {
                    var crit = playerList[j].gameObject.GetComponent<CardInfoScr>().CritMultiplier;
                    if (crit > max) max = crit;
                }
                for (int j = 0; j < playerList.Count; j++)
                {
                    switch (playerCardChainController.critCounter)
                    {
                        case 1:
                        case 2:
                            if (playerList[j])
                            {
                                playerList[j].Attack = playerList[j].Attack * max;
                                playerList[j].Defense = playerList[j].Defense * max;
                                playerList[j].Heal = playerList[j].Heal * max;
                            }
                            break;
                    }
                }
                for (int j = 0; j < enemyList.Count; j++)
                {
                    switch (enemyCardChainController.critCounter)
                    {
                        case 1:
                        case 2:
                            if (enemyList[j])
                            {
                                enemyList[j].Attack = enemyList[j].Attack * max;
                                enemyList[j].Defense = enemyList[j].Defense * max;
                                enemyList[j].Heal = enemyList[j].Heal * max;
                            }
                            break;
                    }
                }
            }

            if (playerList.Exists(x => x.ID == 2) || enemyList.Exists(x => x.ID == 2)) //def
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    switch (playerList[j].ID)
                    {
                        case 2:
                            playerController.AddDefense(playerList[j].Defense);
                            break;
                    }
                }
                for (int j = 0; j < enemyList.Count; j++)
                {
                    switch (enemyList[j].ID)
                    {
                        case 2:
                            enemyController.AddDefense(enemyList[j].Defense);
                            break;
                    }
                }
            }

            if (playerList.Exists(x => x.ID == 3) || enemyList.Exists(x => x.ID == 3)) // heal
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    switch (playerList[j].ID)
                    {
                        case 3:
                            playerController.Heal(playerList[j].Heal);
                            break;
                    }
                }
                for (int j = 0; j < enemyList.Count; j++)
                {
                    switch (enemyList[j].ID)
                    {
                        case 3:
                            enemyController.Heal(enemyList[j].Heal);
                            break;
                    }
                }
            }

            if (playerList.Exists(x => x.ID == 1) || enemyList.Exists(x => x.ID == 1)) // attack
            {
                for (int j = 0; j < playerList.Count; j++)
                {
                    switch (playerList[j].ID)
                    {
                        case 1:
                            if (enemyList.Count != 0)
                            {
                                if (enemyCardChainController.counterAttackCounter > 0)
                                {
                                    enemyController.Hurt(playerList[j].Attack * 0);
                                    enemyCardChainController.counterAttackCounter--;
                                }
                                else
                                {
                                    enemyController.Hurt(playerList[j].Attack);
                                    switch (playerCardChainController.vampireCounter)
                                    {
                                        case 1:
                                            if (playerList[j])
                                            {
                                                playerController.MaxHP += playerList[j].Attack;
                                                //playerController.Heal(playerList[j].Attack);
                                            }
                                            break;
                                        case 2:
                                            if (playerList[j])
                                            {
                                                playerController.MaxHP += playerList[j].Attack * 2;
                                                //playerController.Heal(playerList[j].Attack*2);
                                            }
                                            break;
                                    }
                                }

                            }
                            else
                            {
                                enemyController.Hurt(playerList[j].Attack);
                                switch (playerCardChainController.vampireCounter)
                                {
                                    case 1:
                                        if (playerList[j])
                                        {
                                            playerController.MaxHP += playerList[j].Attack;
                                            //playerController.Heal(playerList[j].Attack);
                                        }
                                        break;
                                    case 2:
                                        if (playerList[j])
                                        {
                                            playerController.MaxHP += playerList[j].Attack * 2;
                                            //playerController.Heal(playerList[j].Attack*2);
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                }
                for (int j = 0; j < enemyList.Count; j++)
                {
                    switch (enemyList[j].ID)
                    {
                        case 1:
                            if (playerList.Count != 0)
                            {
                                if (playerCardChainController.counterAttackCounter > 0)
                                {
                                    playerController.Hurt(enemyList[j].Attack * 0);
                                    playerCardChainController.counterAttackCounter--;

                                }
                                else
                                {
                                    playerController.Hurt(enemyList[j].Attack);
                                }
                            }
                            else
                            {
                                playerController.Hurt(enemyList[j].Attack);
                            }
                            break;
                    }
                }
            }


            if (playerList.Exists(x => x.ID == 5) || enemyList.Exists(x => x.ID == 5))
            {
                if (enemyList.Exists(x => x.ID == 1))
                {
                    for (int j = 0; j < playerList.Count; j++)
                    {
                        switch (playerList[j].ID)
                        {
                            case 5:
                                if (enemyCardChainController.attackCounter > 0)
                                    enemyController.Hurt(playerList[j].Attack);
                                enemyCardChainController.attackCounter--;
                                switch (playerCardChainController.vampireCounter)
                                {
                                    case 1:
                                        if (playerList[j])
                                        {
                                            playerController.MaxHP += playerList[j].Attack;
                                            //playerController.Heal(CardChain[j].Attack);
                                        }
                                        break;
                                    case 2:
                                        if (playerList[j])
                                        {
                                            playerController.MaxHP += playerList[j].Attack * 2;
                                            //playerController.Heal(CardChain[j].Attack*2);
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }
                for (int j = 0; j < enemyList.Count; j++)
                {
                    if (playerList.Exists(x => x.ID == 1))
                    {
                        switch (enemyList[j].ID)
                        {
                            case 5:
                                if (playerCardChainController.attackCounter > 0)
                                    playerController.Hurt(enemyList[j].Attack);
                                playerCardChainController.attackCounter--;
                                break;
                        }
                    }
                }
            }
        }
    }





    void Die()
    {
        if (playerController != null)
        {
            if (playerController.HP <= 0)
            {
                def.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (enemyController != null)
        {
            if (enemyController.HP <= 0)
            {
                vic.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
