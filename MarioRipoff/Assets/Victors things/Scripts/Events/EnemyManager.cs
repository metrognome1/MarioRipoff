using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public static int EnemyCount = 0;

    public delegate void reaction();
    public static event reaction onNoEnemies;

    void Update() {
        if (EnemyCount == 0)
            if(onNoEnemies != null)
                onNoEnemies();
    }
}

