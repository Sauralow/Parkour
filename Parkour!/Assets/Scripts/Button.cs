using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, points[1].position, Time.deltaTime);
            //Debug.Log("Pressed & moving");
        }
        else
        {
            transform. position = Vector3.MoveTowards(transform.position, points[0].position, Time.deltaTime);
            //Debug.Log("unPressed & moving");

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        pressed = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        pressed = false;
    }
}
