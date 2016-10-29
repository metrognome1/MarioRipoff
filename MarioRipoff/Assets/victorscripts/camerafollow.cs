using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {

    private Transform player;
    private Vector3 moveTemp;

    public string focus = "Square";

    public float speed = 3;
    public float xDifference;
    public float yDifference;

    public float movementThreshold = 3;

    void Start ()
    {
        //Change the Square to our player object. Whatever it's string name is.
        player = (GameObject.Find(focus)).transform;
    }

	void Update () {
        if (player.transform.position.x > transform.position.x)
        {
            xDifference = player.transform.position.x - transform.position.x;
        } else
        {
            xDifference = transform.position.x - player.transform.position.x;
        }

        if (player.transform.position.y > transform.position.y)
        {
            yDifference = player.transform.position.y - transform.position.y;
        } else
        {
            yDifference = transform.position.y - player.transform.position.y;
        }

        // The rate at which the camera moves here should depend on the speed of the focus.
        // The focus's speed can be calculated using vectors and their speed?
        if (xDifference >= movementThreshold || yDifference >= movementThreshold)
        {
            moveTemp = player.transform.position;
            moveTemp.z = -1;
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.deltaTime);
        }
	
	}
}
