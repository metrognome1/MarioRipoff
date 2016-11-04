using UnityEngine;
using System.Collections;

public class playercontroller_zhu : MonoBehaviour {
	public float speed;
	public float jump_power;
	//public float speed_limit;
	private Rigidbody2D rb2D;
	private bool jumpflag;
	private bool ladderflag;
	private SpriteRenderer playersprite;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		playersprite = GetComponent<SpriteRenderer> ();
		jumpflag = true;
		ladderflag = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float jump = Input.GetAxis ("Jump");
		Vector2 movement = new Vector2 (moveHorizontal * speed, rb2D.velocity.y);
		rb2D.velocity = movement;
		if ((jumpflag == true) && Input.GetButton("Jump")) {
			rb2D.AddForce (new Vector2 (0, jump_power));
			jumpflag = false;
		}
		if (rb2D.velocity.x >= 0) {
			playersprite.flipX = false;
		} else {
			playersprite.flipX = true;
		}



		//for the ladder, please modify variable number, still in alpha stage 
		if (ladderflag) {
			//this is up
			rb2D.isKinematic = true;
			if (Input.GetAxis ("Vertical") > 0) {
				//turn off gravity
				rb2D.gravityScale = 0;
				//move up the ladder at a slow pace
				//did that for testing
				transform.Translate (0, 1 * Time.deltaTime, 0);
				//SendMessage("onClimb",SendMessageOptions.DontRequireReceiver);
			}
			if(Input.GetButton("Jump") && Input.GetButton("Horizontal")){
				rb2D.AddForce (new Vector2 (0, jump_power));
				movement = new Vector2 (moveHorizontal * speed, rb2D.velocity.y);
				rb2D.velocity = movement;
			}
			//this is down
			else if (Input.GetAxis ("Vertical") < 0) {
				rb2D.gravityScale = 0;
				transform.Translate (0, -1 * Time.deltaTime, 0);
				//	SendMessage("onClimb",SendMessageOptions.DontRequireReceiver);
			}
		} else {
			rb2D.gravityScale = 1;
			rb2D.isKinematic = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		jumpflag = true;
		if (other.tag == "ladder") {
			ladderflag = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "ladder") {
			ladderflag = false;
		}

	}
	void OnTriggerStay2D(Collider2D other){
		jumpflag = true;
	}
}	