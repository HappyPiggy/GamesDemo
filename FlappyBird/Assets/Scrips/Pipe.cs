using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

    private void Start()
    {
        RandomGeneratePosition();
    }

    public void RandomGeneratePosition()
    {
        float posY = Random.Range(-0.61f, -0.16f);
        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
       // Debug.Log(posY);
    }
}
