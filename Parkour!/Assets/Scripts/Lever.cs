using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool contacted = false;
    [SerializeField] private bool on = false;
    [SerializeField] private Vector3 angle = new Vector3(0, 0, -50f);
    [SerializeField] private float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted && !on)
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, angle, rotationSpeed);
            if(transform.eulerAngles.z <= angle.z)
            {
                on = true;
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        contacted = true;
    }
}
