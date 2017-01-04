using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class camerafollow : MonoBehaviour {
    

    public GameObject focus;
    public float xDifference;
    public float yDifference;
    public float movementThreshold = 1.5f;

    private modifiedMove modMove;
    private Transform player;
    private Vector3 moveTemp;
    private Rigidbody2D playerRg2D;

    void OnEnable() {
        playerHealth.onDeath += Disable;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        playerHealth.onDeath -= Disable;
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void Start () {
        player = focus.transform;
        playerRg2D = focus.GetComponent<Rigidbody2D>();
    }

    void Update () {
        moveCamera();
    }

    private void moveCamera() {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 0)
            xDifference = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (Mathf.Abs(player.transform.position.y - transform.position.y) > 0)
            yDifference = Mathf.Abs(player.transform.position.y - transform.position.y);

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

    //Sets camera on player
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        transform.position = player.transform.position;
    }
}