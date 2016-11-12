using UnityEngine;
using System.Collections;

public class playerhealth : MonoBehaviour, IDamageable {
    // change to private eventually
    public int health;
    
	// Use this for initialization
	void Start () {
        health = 3;
	}
	
    void Update ()
    {
        //This condition can be replaced for what we choose to do on deaths
        if (health <= 0)
        {
            Debug.Log("おまえはもう死んでる");
            Destroy(gameObject, 3f);
        }
    }

    //public void die()
    //{
    //    Debug.Log("お前はもう死んでる");
    //    Destroy(gameObject, 3f);
    //}
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}