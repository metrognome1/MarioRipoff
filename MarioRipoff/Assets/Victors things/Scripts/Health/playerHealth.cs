using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour, IDamageable, IKnockbackable, IKillable {
    // change to private eventually
    public delegate void respawn();
    public static event respawn onDeath;

    public int health = 100;

    Rigidbody2D playerRigid;
    Transform objectTransform;

    


	void Start () {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        objectTransform = gameObject.transform;
	}
	
    void Update ()
    {
        //This condition can be replaced for what we choose to do on deaths
        if (health <= 0)
        {
            kill();
            //Creates onDeath() event
        }
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        invulnerable();
    }

    private void kill() {
        //Call some sort of death animation here
        //Using event to cause other things in the game to occur
        if (onDeath != null) {
            onDeath();
        }
        Destroy(gameObject);
    }

    public void Kill() {
        kill();
    }
    // Might want to move Knockback to an area relating to player locality 
    // or something along those lines
    public void Knockback(float knockSourceX, int knockForce) {
        float directionX;
        float curObjX = gameObject.transform.position.x;
        //Knock left
        if (knockSourceX > curObjX)
            directionX = -1.0f;
        //Knock right
        else {
            directionX = 1.0f;
        }
        Vector2 direction = new Vector2(1 * directionX, 1);
        direction.Normalize();
        playerRigid.AddForce(direction * knockForce, ForceMode2D.Impulse);
    }

    private void invulnerable() {

    }

    void OnCollisionEnter2D(Collision2D col) {
        

        //IStompable stomp = col.gameObject.GetComponent<IStompable>;
    }
}
