using UnityEngine;
using System.Collections;

public class MoveTrigger : MonoBehaviour
{
    public Pipe pipe1;
    public Pipe pipe2;
    public Transform currentBg;

    public void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            Transform firstBg= GameManager.Instance.firstBg;
            currentBg.position = new Vector3(firstBg.position.x+10,currentBg.position.y,currentBg.position.z);
            GameManager.Instance.firstBg = currentBg;

            //更新管道位置
            pipe1.RandomGeneratePosition();
            pipe2.RandomGeneratePosition();

        }
    }
}
