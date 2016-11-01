using UnityEngine;
using System.Collections;

public class MeleeAI : EnemyAI {


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mEnemyDistance")
        {
            CanMove = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mEnemyDistance")
        {
            CanMove = true;
        }
    }


}
