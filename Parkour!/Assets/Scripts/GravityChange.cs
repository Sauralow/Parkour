using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField] bool reset = false;
    Vector3 normalGrav = Physics.gravity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            Physics.gravity = normalGrav;
            reset = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {//Set gravity sideways
        if (col.gameObject.CompareTag("wall"))
        {
            Vector3 direction = col.GetContact(0).point - transform.position;
            direction = direction.normalized;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                    {
                        Physics.gravity = new Vector3(9.8f, 0, 0);

                        //Debug.Log("collision is came from right");
                    }
                    else
                    {
                        Physics.gravity = new Vector3(-9.8f, 0, 0);
                        //Debug.Log("collision came from left");

                    }
                }
                else
                {
                    if (direction.y > 0)
                    {

                        Physics.gravity = new Vector3(0, 9.8f, 0);
                        //Debug.Log("collision is came from top");
                    }
                    else
                    {

                        Physics.gravity = new Vector3(0, -9.8f, 0);
                        //Debug.Log("collision came from down");

                    }
                }
            }
            else
            {
                if (Mathf.Abs(direction.z) > Mathf.Abs(direction.y))
                {
                    if (direction.z > 0)
                    {

                        Physics.gravity = new Vector3(0, 0, 9.8f);
                        //Debug.Log("collision is came from front");
                    }
                    else
                    {
                        //Debug.Log("collision came from back");
                        Physics.gravity = new Vector3(0, 0, -9.8f);

                    }
                }
                else
                {
                    if (direction.y > 0)
                    {

                        Physics.gravity = new Vector3(0, 9.8f, 0);
                        //Debug.Log("collision is came from top");
                    }
                    else
                    {

                        Physics.gravity = new Vector3(0, -9.8f, 0);
                        //Debug.Log("collision came from down");
                    }
                }
            }
        }

        //Physics.gravity = new Vector3(-0.1f, 0, 0);
    }
    private void OnCollisionExit(Collision collision)
    {
         
        Physics.gravity = normalGrav;
    }
}
