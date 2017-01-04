using UnityEngine;
using System.Collections;

public class modifiedMove : MonoBehaviour {
    public float maxSpeed = 6f;
    public bool facingRight = true;
    public bool FacingRight {
        get {
            return facingRight;
        }
    }
    Animator anim;
    Rigidbody2D rBody;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;

    public float jumpHeld = 0.0f;
    public float fullJumpTime = 0.8f;
    public float minJump = 0.2f;
    public float extendJump = 70;
    public bool side_collision = false;

    private float side_col_thresh_dist = .14f;

	void Start () {
        jumpHeld = 0.01f;
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();

    }
	
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", rBody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
    }
    // Update is called once per frame
    void Update() {
        float move = 0;
        move = Input.GetAxis("Horizontal");
        if (move != 0 && (!side_collision || grounded))
            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();


        if (grounded && Input.GetButtonDown("Jump")) {
            anim.SetBool("Ground", false);
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump() {
        anim.SetBool("Ground", false);
        rBody.AddForce(new Vector2(0, minJump), ForceMode2D.Impulse);
        while (Input.GetButton("Jump") && jumpHeld < fullJumpTime) {
            jumpHeld += Time.deltaTime;
            //The various kinds of extended jumps
            //rBody.velocity += new Vector2(0f, maxJump * Time.deltaTime);
            //rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Force);
            rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Impulse);
            yield return null;
        }
        jumpHeld = 0f;
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionStay2D(Collision2D col) {
        //Checks distance between game object and contact position in x axis.
        if (Mathf.Abs(gameObject.transform.position.x - col.contacts[0].point.x) > side_col_thresh_dist) {
            side_collision = true;
        }
        else {
            side_collision = false;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (side_collision == true)
            side_collision = false;
    }
}
