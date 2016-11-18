using UnityEngine;
using System.Collections;

public class robotscript : MonoBehaviour {
	
	private Animator anim;
	public bool facdir;
	MODE mode;
	float rotax;
	enum MODE {partrol, attack1, attack2, idle};
	Rigidbody2D rigid; 
	public bool grounded;
	public float groundRadius;
	public Vector2 sizecheck;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public Transform partrolCheck1,partrolCheck2,partrolCheck3,partrolCheck4;
	public Transform parents;
	public bool checkflag1, checkflag2, checkflag3, checkflag4;
	private Vector3 dummy1;
	private Vector3 dummy2;
	private Vector3 dummy3;
	private Vector3 dummy4;
//	public float prev_posix;
//	private float prev_posiy;
//	private Collider2D walldetectl;
//	private Collider2D walldetectr;
	// Use this for initialization
	void Start () {
	//	prev_posix = transform.position.x;
	//	prev_posiy = transform.position.y;
		anim = GetComponent<Animator> ();
		checkflag1 = checkflag2 = checkflag3 = checkflag4 = true;
		facdir = true;
		rotax = transform.localScale.x;
		mode = MODE.partrol;
		rigid = GetComponent<Rigidbody2D>();
		parents = GetComponent<Transform> ();
		partrolCheck1 = gameObject.transform.Find ("partrolcheck1");
		partrolCheck2 = gameObject.transform.Find ("partrolcheck2");
		partrolCheck3 = gameObject.transform.Find ("partrolcheck3");
		partrolCheck4 = gameObject.transform.Find ("partrolcheck4");
	}
	void FixedUpdate () {

		//check trigger
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		checkflag1 = Physics2D.OverlapBox (partrolCheck1.position,sizecheck, whatIsGround);
		checkflag2 = Physics2D.OverlapBox (partrolCheck2.position, sizecheck, whatIsGround);
	 	checkflag3 = Physics2D.OverlapBox (partrolCheck3.position, sizecheck, whatIsGround);
		checkflag4 = Physics2D.OverlapBox (partrolCheck4.position, sizecheck, whatIsGround);

	//	prev_posix = transform.position.x;
	//	prev_posiy = transform.position.y;

	    if (facdir == true) //facing right
		{
			dummy1 = partrolCheck1.position;
			dummy2 = partrolCheck2.position;
			dummy3 = partrolCheck3.position;
			dummy4 = partrolCheck4.position;
			transform.localScale = new Vector3(rotax,transform.localScale.y,transform.localScale.z);
			partrolCheck1.position = dummy1;
			partrolCheck2.position = dummy2;
			partrolCheck3.position = dummy3;
			partrolCheck4.position = dummy4;
			if (mode == MODE.partrol) {
				transform.Translate (Vector3.right * Time.deltaTime);
				anim.SetFloat ("run", 1f);
			}
		}
		else
		{
			dummy1 = partrolCheck1.position;
			dummy2 = partrolCheck2.position;
			dummy3 = partrolCheck3.position;
			dummy4 = partrolCheck4.position;
			transform.localScale = new Vector3(-1*rotax,transform.localScale.y,transform.localScale.z);
			partrolCheck1.position = dummy1;
			partrolCheck2.position = dummy2;
			partrolCheck3.position = dummy3;
			partrolCheck4.position = dummy4;
			if (mode == MODE.partrol) {
				transform.Translate (Vector3.right* Time.deltaTime);
				anim.SetFloat ("run", 1f);
			}
		}
		//anim.speed = Mathf.Max (transform.position.x - prev_posix, transform.position.y - prev_posiy);
		if (grounded == true) {
			rigid.isKinematic = true;
		}			
		else {
     		rigid.isKinematic = false;
		}
		if (checkflag1 == true) {
			mode = MODE.partrol; 
			if (checkflag2 == false) { 
				facdir = false;
			}
		}
		if (checkflag2 == true) {
			mode = MODE.partrol; 
			if (checkflag1 == false) { 
				facdir = true;
			}
		}
		if (checkflag3 == true) {
			facdir = false;
		}
		if (checkflag4 == true) {
			facdir = true;
		}
		if (((checkflag1 == false) && (checkflag2 == false)) || ((checkflag3 == true) && (checkflag4 == true))) {
			mode = MODE.idle;
		}
       
	} 
	/*
	void Switch (){
    	dummy = partrolCheck1.position;
     	partrolCheck1.position = partrolCheck2.position;
	    partrolCheck2.position = dummy;
	}
*/
}


