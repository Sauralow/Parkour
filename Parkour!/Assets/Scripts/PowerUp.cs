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
  
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ApplyPowerup(type);
        }
        MovingWall wall = GameObject.Find("Moving Wall").GetComponent<MovingWall>();
        if (wall != null)
        {
            wall.move = true;
        }
        Destroy(this.gameObject);
    }
}
