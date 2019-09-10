using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject[] Pattern;
    public Transform Parent;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private void FixedUpdate()
    {
        if (timeBtwSpawn <= 0)
        {
            Debug.Log($"{OnBoardCardMngr.onBoardPlayer.Count}");
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
