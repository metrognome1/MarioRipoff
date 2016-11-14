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
            kill();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void kill() {
        Debug.Log("Died");
        Destroy(gameObject);
    }
}