using UnityEngine;
using System.Collections;

public class AsteriodDestory : MonoBehaviour
{

    public GameObject asteriodExplosion;
    public GameObject palyerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);
        }

        Instantiate(asteriodExplosion,transform.position,transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
