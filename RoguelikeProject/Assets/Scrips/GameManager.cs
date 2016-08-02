using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip dieAudio;
    public int level = 1;
    public int hp = 100;
    public List<Enemy> EnemyList = new List<Enemy>();
   [HideInInspector] public bool isEnd = false;

    private Text hpText;
    private Text failText;

    private bool isSleep = true;
    private static GameManager _instance;
    private Player palyer;
    private MapManager mapManager;
    private Image DayImage;
    private Text DayText;

    public static GameManager Instance
    {
        get
        {
              return _instance;
        }
      
    }
  

    void Awake()
    {
        _instance = this;
      //  mapManager.InitMap();
        DontDestroyOnLoad(gameObject);
      
        
        InitGame();
    }


    void InitGame()
    {
        mapManager = GetComponent<MapManager>();
        mapManager.InitMap();
    //    Debug.Log("test");

        failText = GameObject.Find("FailText").GetComponent<Text>();
        failText.enabled = false;
        hpText = GameObject.Find("HpText").GetComponent<Text>();
        hpText.text = "Hp:" + hp;
        palyer=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        isEnd = false;
        EnemyList.Clear();

        //加载天数
        DayImage = GameObject.Find("DayImage").GetComponent<Image>();
        DayText = GameObject.Find("DayText").GetComponent<Text>();
        Invoke("HideBack",1);
        DayText.text = "Day " + level;
       
    }

    void UpdateHp(int count)
    {
        string str = "";
        if (count == 0)
        {
            hpText.text = "Hp:" + hp;
        }
        else
        {
            if (count > 0)
            {
                str = "+";
            }
            hpText.text = str+count + " Hp:" + hp;
        }
    }

    public void ReduceHp(int count)
    {
        hp -= count;
        UpdateHp(-count);
        if (hp <= 0) {
            AudioManager.Instance.RandomPlay(dieAudio);
            AudioManager.Instance.StopBgMusic();
            failText.enabled = true;
        }
            
    }

    public void AddHp(int count)
    {
        hp += count;
        UpdateHp(count);
    }

    public void OnPlayerMove()
    {
        if (isSleep)
        {
            //提醒enemy移动
            foreach (var enemy in EnemyList)
            {
                enemy.Move();
            }


            isSleep = false;
        }
        else
        {
            isSleep = true;
        }
    //   Debug.Log(isSleep);

        //检测是否到终点
        if (palyer.targetPos.x == mapManager.cols - 2 && palyer.targetPos.y == mapManager.rows - 2)
        {
            isEnd = true;

            //进入下一关
            Application.LoadLevel(Application.loadedLevel);
        }
        
    }


    // 进入下一关的函数
    void OnLevelWasLoaded(int scenelevel)
    {
        level++;
        InitGame();
        

    }

    void HideBack() {

        DayImage.gameObject.SetActive(false);
    }
}
