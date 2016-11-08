using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text time;

    float TimeLeft = 100;//seconds
    int changeNumber;
	// Use this for initialization
	void Start () {
        time = GetComponent<Text>();
        string Stime = TimeLeft.ToString();
        time.text = Stime;

        time.color = Color.white;
	}

    void FixedUpdate()
    {

       // print(Time.fixedDeltaTime);
        TimeLeft -= Time.fixedDeltaTime;
        changeNumber += 1;
        if (changeNumber == 50)
        {
            int ITIME = (int)TimeLeft;
            time.text = ITIME.ToString();
            changeNumber = 0;
        }
    }
}
