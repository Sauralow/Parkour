using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed = 50f;
    [SerializeField] private float jumpForce = 100f;
    public bool gameStart = false;
    private GameObject focalPoint;
    [SerializeField] private Transform look;
    [SerializeField] private bool grounded = false;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            Move();
            if(Input.GetKeyDown(KeyCode.Space) && grounded) { Jump(); }

        }
    }
    private void Move()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        
        Vector3 dir = look.right * x + look.forward * z;
        dir *= speed;

        _rb.AddForce(dir, ForceMode.Force);
    }

    public void StartGame()
    {
        _rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameStart = true;
    }
    private void Jump()
    {
        grounded = false;
        Vector3 dir = Vector3.up * jumpForce;
        _rb.AddForce(dir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Reset");
            grounded = true;
        }
    }
}
