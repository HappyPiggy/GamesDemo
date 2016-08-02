using UnityEngine;
using System.Collections;

public class Loaded : MonoBehaviour {
    public GameObject gameManager;

    void Awake() {

        //如果没有时 才实例化这个当前物体
        if(GameManager.Instance==null)
        GameObject.Instantiate(gameManager);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
