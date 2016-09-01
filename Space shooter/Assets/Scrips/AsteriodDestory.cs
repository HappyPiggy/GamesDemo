﻿using UnityEngine;
using System.Collections;

public class AsteriodDestory : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}