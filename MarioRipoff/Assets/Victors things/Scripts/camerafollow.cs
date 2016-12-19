using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    

    public GameObject focus;
    public float xDifference;
    public float yDifference;
    public float movementThreshold = 2;

    private Transform player;
    private Vector3 moveTemp;
    private Rigidbody2D playerRg2D;

    void OnEnable() {
        playerHealth.onDeath += Disable;
    }

    void OnDisable() {
        playerHealth.onDeath -= Disable;
    }

    void Start ()
    {
        player = focus.transform;
        playerRg2D = focus.GetComponent<Rigidbody2D>();
    }
    void Update () {
        moveCamera();
    }

    private void moveCamera() {
        if (player.transform.position.x > transform.position.x) {
            xDifference = player.transform.position.x - transform.position.x;
        }
        else {
            xDifference = transform.position.x - player.transform.position.x;
        }

        if (player.transform.position.y > transform.position.y) {
            yDifference = player.transform.position.y - transform.position.y;
        }
        else {
            yDifference = transform.position.y - player.transform.position.y;
        }

        if (xDifference >= movementThreshold || yDifference >= movementThreshold) {
            moveTemp = player.transform.position;
            moveTemp.z = -1;
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, playerRg2D.velocity.magnitude * Time.deltaTime);
        }
    }

    //Disables this component
    void Disable() {
        this.enabled = false;
    }
}
