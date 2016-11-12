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
    }
}