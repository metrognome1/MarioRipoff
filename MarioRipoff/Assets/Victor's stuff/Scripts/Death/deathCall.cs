using UnityEngine;
using System.Collections;

public class deathCall : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        IKillable killable = col.gameObject.GetComponent<IKillable>();
        if (killable != null) {
            killable.Kill();
        }
    }
}
