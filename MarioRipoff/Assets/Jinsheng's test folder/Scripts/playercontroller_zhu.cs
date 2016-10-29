using UnityEngine;
using System.Collections;

public class playercontroller_zhu : MonoBehaviour {
	public float speed;
	public float jump_power;
	//public float speed_limit;
	private Rigidbody2D rb2D;
	private bool jumpflag;
	private SpriteRenderer playersprite;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		playersprite = GetComponent<SpriteRenderer> ();
		jumpflag = true;
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
	}

	void OnTriggerEnter2D(Collider2D other){
		jumpflag = true;
	}

	void OnTriggerStay2D(Collider2D other){
		jumpflag = true;
	}
}	