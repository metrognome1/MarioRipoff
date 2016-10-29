using UnityEngine;
using System.Collections;

public class EasyMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
    }
}


