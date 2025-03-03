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
    [SerializeField] private int collected = 0;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 spawnPos;

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
            if(Input.GetKeyDown(KeyCode.R)) { Respawn(); }


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
        startPos = transform.position;
        SetSpawn(startPos);
        gameStart = true;
    }
    private void Jump()
    {
        grounded = false;
        Vector3 dir = -Physics.gravity.normalized * jumpForce;
        _rb.AddForce(dir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("wall"))
        {
            //Debug.Log("Reset");
            grounded = true;
        }
    }
    public void AddCollectable()
    {
        collected++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        //update collectables
    }
    public void SetSpawn(Vector3 pos)
    {
        spawnPos = pos;
        //put a coroutine that says you can respawn with r
    }
    private void Respawn()
    {
        transform.position = spawnPos;
    }
}
