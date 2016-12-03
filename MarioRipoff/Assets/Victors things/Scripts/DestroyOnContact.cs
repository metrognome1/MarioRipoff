using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col) {
        Destroy(gameObject);
    }
}
