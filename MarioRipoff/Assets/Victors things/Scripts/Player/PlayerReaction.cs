using UnityEngine;
using System.Collections;

public class PlayerReaction : MonoBehaviour {

    void OnEnable() {
        EnemyManager.onNoEnemies += celebration;
    }

    void OnDisable() {
        EnemyManager.onNoEnemies -= celebration;
    }

    void celebration() {
    }
}
