using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum PowerUpType
    {
        DoubleJump,
        Speed
    }

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ApplyPowerup(type);
        }
        MovingWall wall = GameObject.Find("Moving Wall").GetComponent<MovingWall>();
    }
}
