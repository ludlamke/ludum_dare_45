using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manger : MonoBehaviour
{

    private Player_controler playerControler;
    private Camera_Controler camera;
    [SerializeField]
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        // testing code
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera.cameraEnabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SummonPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddPlayerMov();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AddPlayerJump();
        }
    }

    // event to add camera
    void activateCamera()
    {

        if (camera.cameraEnabled != true)
        {
            camera.cameraEnabled = true;
        }

        
    }
    // event to summon player
    void SummonPlayer()
    {
        if(!playerControler)
        {
            Instantiate(player, this.transform.position, this.transform.rotation);
            playerControler = FindObjectOfType<Player_controler>();
            camera.assignplayer();
        }
        
    }

    // event to enable player movment 
    void AddPlayerMov()
    {
        playerControler.isContreolabe = true;
    }

    // event to enable player jump
    void AddPlayerJump()
    {
        playerControler.canJump = true;
    }
}
