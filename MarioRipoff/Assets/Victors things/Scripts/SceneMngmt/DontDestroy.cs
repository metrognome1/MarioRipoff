using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
    private bool created = false;

    void Awake() {
        if (!created) {
            //First instance - make persist
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else {
            //Destroys duplicates
            Destroy(this.gameObject);
        }

    }
}