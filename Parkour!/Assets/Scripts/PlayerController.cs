using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public bool gameStart = false;
    private GameObject focalPoint;
    [SerializeField] private Transform look;
    [SerializeField] private bool grounded = false;
    [SerializeField] private int collected = 0;
    [SerializeField] public int totalCollectables = 5;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float spawnJumpForce;
    [SerializeField] private bool canDoubleJump = false;
    [SerializeField] private bool hasDoubleJumped = false;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text restartReminder;
    [SerializeField] private TMP_Text collectables;
    
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
            if(Input.GetKeyDown(KeyCode.Space)) { Jump(); }
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
        spawnJumpForce = jumpForce;
        spawnSpeed = speed;
        SetSpawn(startPos);
        gameStart = true;
        UpdateUI();
    }
    private void Jump()
    {
        Vector3 dir = -Physics.gravity.normalized * jumpForce;
        if (grounded)
        {
            _rb.AddForce(dir, ForceMode.Impulse);
            grounded = false;
        }
        else if (canDoubleJump && !hasDoubleJumped) 
        {
            _rb.AddForce(dir, ForceMode.Impulse);
            hasDoubleJumped = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("wall"))
        {
            //Debug.Log("Reset");
            grounded = true;
            if (canDoubleJump) 
            {
                hasDoubleJumped = false;
            }
        }
    }
    public void AddCollectable()
    {
        collected++;
        UpdateUI();
    }
    public void UpdateUI()
    {
        collectables.SetText("Collected: " + collected + "/" + totalCollectables);
        if (gameStart)
        {
            collectables.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            restartReminder.gameObject.SetActive(false);
        }
        else
        {
            collectables.gameObject.SetActive(false);
            title.gameObject.SetActive(true);
            restartReminder.gameObject.SetActive(false);
        }
    }
    public void SetSpawn(Vector3 pos)
    {
        spawnPos = pos;
        restartReminder.gameObject.SetActive(true);
        StartCoroutine("TurnOff");
        //put a coroutine that says you can respawn with r
    }
    private void Respawn()
    {
        transform.position = spawnPos;
        
    }
    public void ApplyPowerup(PowerUpType type)
    {
        RemovePowerups();
        switch (type)
        {
            case PowerUpType.Speed:
                speed *= 2;
                break;

            case PowerUpType.DoubleJump:
                canDoubleJump = true;
                break;
        }
    }
    public void RemovePowerups()
    {
        speed = spawnSpeed;
        jumpForce = spawnJumpForce;
        canDoubleJump = false;
    }
    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(3);
            restartReminder.gameObject.SetActive(false);
    }
    
}
