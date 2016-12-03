using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    public delegate void levelChange();
    public static event levelChange onDoorEnter;

	
    void OnTriggerStay2D (Collider2D other) {
        if (Input.GetAxis("Vertical") > 0)
            if(onDoorEnter != null)
                onDoorEnter();
        
    }
}
