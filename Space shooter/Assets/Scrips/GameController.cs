using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject[] asteriods;
    public Vector3 spawnPosition;
    public int asteriodCount;
    public float waitTime;
    public float startTime;
    public float waveTime;

    public Text scoreText;
    private int score;

    public Text gameoverText;
    public Text restartText;

    private bool gameover;
    private bool restart;




    void Start()
    {
        gameoverText.text = "";
        restartText.text = "";
        gameover = false;
        restart = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves()); 
    }


    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }

    public void Gameover()
    {
        gameover = true;
        gameoverText.text = "Game Over";
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startTime);
        while (true)
        {
           
            for (int i = 0; i < asteriodCount; i++)
            {
                GameObject asteriod = asteriods[Random.Range(0, asteriods.Length)];
                Vector3 randomPos = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
                Instantiate(asteriod, randomPos, Quaternion.identity);

                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waveTime);

            if (gameover)
            {
                restartText.text = "Press R for Restart";
                restart = true;
                break;
            }
        }

       
       
    }
}
