using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{

    public GameObject selfExplosion;
    public GameObject palyerExplosion;
    public int getScore;

    private GameController gameController;
    

    void Start()
    {
        GameObject gameControllerObject =GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("can't find GameController Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.Gameover();
        }

      
            gameController.AddScore(getScore);
            Instantiate(selfExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
           
      
      
    }
}
