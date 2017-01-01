using UnityEngine;
using System.Collections;

public class enemyBody : MonoBehaviour {
    public bool facingRight = false;
    public Transform playerTransform;
    public string targetTag = "Player";

    void OnEnable() {
        playerHealth.onDeath += Disable;
    }

    void OnDisable() {
        playerHealth.onDeath -= Disable;
    }

    //Need to add some way to populate the playerTransform without having to drag and drop
    void Start() {
        if (playerTransform == null) {
            //playerTransform = GameObject.FindWithTag("Player").transform;
            playerTransform = GameObject.FindWithTag(targetTag).transform;
        }

    }

    void Update() {
        if (transform.position.x < playerTransform.position.x && !facingRight)
            Flip();
        else if (transform.position.x >= playerTransform.position.x && facingRight)
            Flip();



    }
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    //Disables this component
    void Disable() {
        this.enabled = false;
    }
}
