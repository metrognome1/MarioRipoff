using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

    public float moveDelay;
    public float farLeft = -10;
    public float farRight = 10;

    Rigidbody2D rgBody;



	// Use this for initialization
	void Start () {
        rgBody = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rgBody);
        StartCoroutine(move());
	
	}

    IEnumerator move() {
        while (true) {
            yield return new WaitForSeconds(moveDelay);
            Debug.Log("In coroutine move");
            rgBody.AddForce(new Vector2(Random.Range(farLeft, farRight), rgBody.velocity.y));
        }
    }
}
