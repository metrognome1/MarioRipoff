using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject enemyPrefab;
    bool usedSpawn = false;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && usedSpawn == false)
        {
            Transform locationofTarget = GameObject.FindGameObjectWithTag("Target").transform;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, locationofTarget.position + new Vector3(2,0,0), Quaternion.identity) as GameObject;
            usedSpawn = true;


        } 
    }
}
