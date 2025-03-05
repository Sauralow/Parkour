using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    [SerializeField] ButtonScript button;
    [SerializeField] Transform[] points;
    [SerializeField] private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);

        }
    }


}
