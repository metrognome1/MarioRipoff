using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    int maxHealth = 100;
    int currentHealth = 50;
    public Image greenbar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        greenbar.fillAmount = (float)currentHealth / maxHealth;
	}
}
