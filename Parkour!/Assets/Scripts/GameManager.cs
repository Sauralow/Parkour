using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraController playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.P)) 
        {
            player.StartGame();
            playerCamera.gameOn = true;
        }
    }
}
