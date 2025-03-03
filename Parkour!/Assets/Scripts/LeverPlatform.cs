using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPlatform : MonoBehaviour
{
    [SerializeField] Lever lever;
    [SerializeField] Transform[] points;
    [SerializeField] private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.on)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[1].position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed);

        }
    }
}
