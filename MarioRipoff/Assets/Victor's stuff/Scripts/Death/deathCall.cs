using UnityEngine;
using System.Collections;

public class deathCall : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        IKillable killable = col.gameObject.GetComponent<IKillable>();
        Debug.Log(col.gameObject);
        if (killable != null) {
            Debug.Log("killable not null");
            killable.Kill();
        }
        Debug.Log(killable);

    }
}
