using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour
{
    public float leftTime;

    void Start()
    {
        Destroy(gameObject, leftTime);
    }
}
