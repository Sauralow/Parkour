using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    Vector3 normalGrav = Physics.gravity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {//Set gravity sideways
        Vector3 direction = /*col.point*/ - transform.position;
        direction = direction.normalized;
    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {

                   //collision is came from right
                }
                else
                {
                   //collision came from left

                }
         }
            else
            {
                if (direction.y > 0)
                {

                   //collision is came from top
                }
                else
                {
                   //collision came from down

                }
         }
        }
        else
        {
            if (Mathf.Abs(direction.z) > Mathf.Abs(direction.y))
            {
                if (direction.z > 0)
                {

                   //collision is came from front
                }
                else
                {
                   //collision came from back

                }
          }
            else
            {
                if (direction.y > 0)
                {

                    //collision is came from top
                }
                else
                {

                    //collision came from down
                }
             }
        }
        Physics.gravity = new Vector3(-0.1f, 0, 0);
    }
    private void OnCollisionExit(Collision collision)
    {
        Physics.gravity = normalGrav;
    }
}
