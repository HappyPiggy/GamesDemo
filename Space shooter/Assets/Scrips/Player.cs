using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}


public class Player : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boudary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement*speed;


        //限制边界
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x,boudary.minX,boudary.maxX),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z,boudary.minZ,boudary.maxZ)
            );

        //飞船角度
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x*-tilt);
    }
}
