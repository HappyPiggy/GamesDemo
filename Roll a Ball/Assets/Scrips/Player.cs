using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private int count;
    private Rigidbody rb;


	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    winText.text = "";
	    SetCountText();

	}

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMove,0,verticalMove);

        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Food"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (count == 15)
        {
            winText.text = "YOU WIN!";
        }
    }

    private void SetCountText()
    {
        countText.text = "Count:" + count;
    }
}
