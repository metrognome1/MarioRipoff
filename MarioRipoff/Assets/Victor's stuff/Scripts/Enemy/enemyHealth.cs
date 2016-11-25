using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour, IDamageable, IStompable, IKnockbackable, IKillable {
    public int health = 10;
    Rigidbody2D enemyRigid;
    Transform objectTransform;

    void OnEnable () {
        EnemyManager.EnemyCount += 1; 
    }

    void OnDisable () {
        EnemyManager.EnemyCount -= 1;
    }

        

	void Start () {
        enemyRigid = gameObject.GetComponent<Rigidbody2D>();
        objectTransform = gameObject.transform;
	
	}
	
	void Update () {
        if (health <= 0)
            kill();
	
	}

    public void TakeDamage(int damage) {
        health -= damage;

    }

    public void Stomp() {
        
        if(health <= 0) {
            //Implement stomp animation
            kill();
        }


    }

    private void kill() {
        Destroy(gameObject);
    }

    public void Kill() {
        kill();
    }

    public void Knockback(float knockSource, int knockForce) {

    }
}
