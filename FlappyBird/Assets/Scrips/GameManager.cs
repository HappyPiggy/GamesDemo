using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Transform firstBg;

    private static GameManager _instance;

    public static GameManager Instance
    {

        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }
}
