using UnityEngine;
using System.Collections;

public class HelicopterBehavior : MonoBehaviour {
    //for the boundaries of helicopter movement
    public Transform leftEnd;
    public Transform rightEnd;

    public GameObject graphics;

    public float velocity = 5;

    private Rigidbody2D rb2D;

    //control the movement
    private bool movingLeft = false;
    private float pauseTime = 1;
    private float timePaused;
    private bool stayPaused = false;

    public GameObject bombPrefab;
    public Transform bombSpawn;

    //bullets
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //where bullets should shoot
    private Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Target").transform;
        rb2D = GetComponent<Rigidbody2D>();

        //helicopter attacks
        DropBomb();
        InvokeRepeating("ShootBullets", 2, .5f);
    }


    Vector3 DetermineDirection()
    {
        //calculates x and y for vector for ShootBullets()

        float bulletX = Player.transform.position.x - transform.position.x;
        float bulletY = Player.position.y - transform.position.y;

        Vector3 bulletDirection = new Vector3(bulletX*70,bulletY*70,0);
        return bulletDirection;
    }



    void DropBomb()
    {
        GameObject Bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity) as GameObject;
    }

    void ShootBullets()
    {
       
        GameObject Bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity) as GameObject;

        Rigidbody2D instantiatedRB = Bullet.GetComponent<Rigidbody2D>();
        instantiatedRB.AddForce(DetermineDirection());
    }


    //death
    public bool dead = false;
    void Dead()
    {
        if (dead)
        {
            rb2D.isKinematic = false;
           
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (dead)
        {
            graphics.GetComponent<Animator>().SetBool("helicopterFell",true);
        }
    }


	
	
	void Update () {
        //moves the helicopter back and forth between the "end" transform positions
        //makes the helicopter pause after it reaches one of the ends for a moment
        

        if (stayPaused)
        {
            timePaused += Time.fixedDeltaTime;
            if (timePaused >= pauseTime)
            {
                stayPaused = false;
                timePaused = 0;
            }
        }

        else
        {

            if (movingLeft)
            {
               
                transform.position += Vector3.left * velocity * Time.fixedDeltaTime;

                if (transform.position.x <= leftEnd.position.x)
                {
                    movingLeft = false;
                    stayPaused = true;
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

            else
            {
               
                transform.position += Vector3.right * velocity * Time.fixedDeltaTime;

                if (transform.position.x >= rightEnd.position.x)
                {
                    movingLeft = true;
                    stayPaused = true;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
}
