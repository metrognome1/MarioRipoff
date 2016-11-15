using UnityEngine;
using System.Collections;

public class damageSource : MonoBehaviour
{

    public int damage = 1;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided");
        IDamageable hit = (IDamageable)col.gameObject.GetComponent(typeof(IDamageable));
        if (hit != null)
        {
            hit.TakeDamage(damage);
        }
        //it might be better to place code that destroys projectiles elsewhere
        //the biggest problem is for projectiles that are not damage sources
        if (gameObject.tag == "projectile")
            //For non array ammo version
            //Destroy(gameObject);
            gameObject.SetActive(false);


    }
}