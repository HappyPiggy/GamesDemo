using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject asteriod;
    public Vector3 spawnPosition;
    public int asteriodCount;
    public float waitTime;
    public float startTime;
    public float waveTime;

    void Start()
    {
        StartCoroutine(SpawnWaves()); 
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startTime);
        while (true)
        {
           
            for (int i = 0; i < asteriodCount; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
                Instantiate(asteriod, randomPos, Quaternion.identity);

                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waveTime);
        }

       
       
    }
}
