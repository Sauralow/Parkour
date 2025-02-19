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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            float verticalInput = Input.GetAxis("Vertical");
            _rb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        }
    }

    public void StartGame()
    {
        _rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameStart = true;
    }
}
