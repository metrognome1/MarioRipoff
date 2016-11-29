using UnityEngine;
using System.Collections;

public class HelicopterBomb : MonoBehaviour {
    public GameObject graphics;
    



    void OnCollisionEnter2D(Collision2D coll)
    {
        graphics.GetComponent<Animator>().SetBool("isExploding",true);
        Destroy(gameObject, .667f);
    }
}
