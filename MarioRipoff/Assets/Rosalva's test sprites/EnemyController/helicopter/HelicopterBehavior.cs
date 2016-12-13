using UnityEngine;
using System.Collections;

public class HelicopterBehavior : MonoBehaviour {
    //not used yet
    public GameObject graphics;

    // test
    private Animator anim;

    private Rigidbody2D rb2D;

    public GameObject bombPrefab;
    public Transform bombSpawn;

    //bullets
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    //where bullets should shoot
    private Transform Player;

    void handleMovements()
    {
        int number = Random.Range(0,10);
        if (number < 6) //loop
        {
            anim.SetBool("movingHorizontally", true);
            anim.SetBool("movingVertically", true);
            anim.SetBool("fakeOut", true);
        }
        else //wont loop
        {
            anim.SetBool("movingHorizontally", false);
            anim.SetBool("movingVertically", false);
            anim.SetBool("fakeOut",false);
        }
    }




    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();

        //helicopter attacks
        DropBomb();
        InvokeRepeating("ShootBullets", 2, .5f);

        //movement
        InvokeRepeating("handleMovements", 2, .5f);
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

}
