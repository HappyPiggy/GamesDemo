using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {


    public GameObject[] outWallArray;
    public GameObject[] floorArray;
    public GameObject[] wallArray;
    public GameObject[] foodArray;
    public GameObject[] enemyArray;
    public GameObject exitPrefab;
    
    public int rows = 10;
    public int cols = 10;

    public Transform mapHolder;

    private List<Vector2> postionList = new List<Vector2>();
    private GameManager gameManager;

    public int minCountWall = 2;
    public int maxCountWall = 8;


	// Use this for initialization
    //void Awake ()
    //{
    //  //  gameManager = GetComponent<GameManager>();
    //    InitMap();
	    
    //}




    public void InitMap() {
       gameManager = GetComponent<GameManager>();
        mapHolder = new GameObject("Map").transform; //封装到Map 目录下

        //生成围墙、地板
        for (int x = 0; x < rows; x++) {
            for (int y = 0; y < cols; y++) {
                if (x == 0 || y == 0 || x == cols - 1 || y == rows - 1)
                {
                    int index = Random.Range(0, outWallArray.Length);
                   GameObject go= GameObject.Instantiate(outWallArray[index], new Vector3(x, y, 0), Quaternion.identity)as GameObject;
                   go.transform.SetParent(mapHolder);
                }
                else {
                    int index = Random.Range(0, floorArray.Length);
                   GameObject go= GameObject.Instantiate(floorArray[index], new Vector3(x, y, 0), Quaternion.identity)as GameObject;
                   go.transform.SetParent(mapHolder);
                }
            }
        }

        //用数组记录位置 为以后取随机位置准备
        postionList.Clear();
        for (int i = 2; i < cols-2; i++)
        {
            for (int j = 2; j < rows-2; j++)
            {
                postionList.Add(new Vector2(i,j));
            }
            
        }


        //生产障碍物

        int wallCount = Random.Range(minCountWall,maxCountWall+1);
        InstantiateItems(wallCount, wallArray);


        //生成食物
        int max = Mathf.Max(1, 10 - gameManager.level * 2);
        int  foodCount= Random.Range(1, max);
        InstantiateItems(foodCount, foodArray);


           
        //生成敌人
        int enemyCount = Random.Range(2,gameManager.level/2+2);
        InstantiateItems(enemyCount, enemyArray);

        //生成出口
        GameObject go4= Instantiate(exitPrefab, new Vector2(rows - 2, cols - 2), Quaternion.identity) as GameObject;
        go4.transform.SetParent(mapHolder);

    }

 

    //实例化对象
    private void InstantiateItems(int count,GameObject[] prefabArray)
    {
        for (int i = 0; i < count; i++)
        {
            //取随机位置
            Vector2 pos = RandomPosition();

            //取得随机障碍物
            GameObject Prefab = RandomPrefab(prefabArray);

            GameObject go = GameObject.Instantiate(Prefab, pos, Quaternion.identity) as GameObject;
            go.transform.SetParent(mapHolder);
        }
    }


    //取得随机位置函数
    private Vector2 RandomPosition()
    {
        int positionIndex = Random.Range(0, postionList.Count);
        Vector2 pos = postionList[positionIndex];
        postionList.RemoveAt(positionIndex);
        return pos;
    }

    //取得随机物品函数
    private GameObject RandomPrefab(GameObject[] prefabs)
    {
        int index = Random.Range(0,prefabs.Length);
        return prefabs[index];
    }
}
