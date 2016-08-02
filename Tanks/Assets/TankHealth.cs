using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {

    public int HP = 100;
    public GameObject TankExplosionPrefab;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;

    private int totalHP;

	// Use this for initialization
	void Start () {
        totalHP = HP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TakeDamage() {
        if (HP <= 0) return;
        HP -= Random.Range(10, 20);
        hpSlider.value = (float)HP / totalHP;
     
        if (HP <= 0) {
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);
            GameObject.Instantiate(TankExplosionPrefab, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
