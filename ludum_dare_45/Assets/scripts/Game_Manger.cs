using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manger : MonoBehaviour
{

    private Player_controler playerControler;
    private Camera_Controler camera;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject backDrop;

    [SerializeField]
    private Button chose1;
    [SerializeField]
    private Button chose2;
    [SerializeField]
    private Button chose3;
    [SerializeField]
    private Text boxHid;

    private bool beginingDone;
    private int instance = 99;
    int part = 0;
    private diologSystem dilog;   
    // Start is called before the first frame update
    void Start()
    {
        dilog = FindObjectOfType<diologSystem>();
        camera = FindObjectOfType<Camera_Controler>();
        chose1.gameObject.SetActive(false);
        chose2.gameObject.SetActive(false);
        chose3.gameObject.SetActive(false);
        boxHid.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // testing code
        if(Input.anyKey && instance == 99)
        {
            instance = 0;
        }

        switch(instance)
        {
            case 0:
                string[] beging = 
                new string[] {"oh someones hear welcom to the game are you injoring yourself",
                                "why",
                                "right games have those hang on",
                                "right games have those hang on",
                                "there if theres anything else press space to call me"
                                };
                boxHid.gameObject.SetActive(true);
                dilog.resetArray(5, beging);
                dilog.runInstance(part);
                if (Input.anyKey && part == 0)
                {
                    chose1.gameObject.SetActive(true);
                    chose1.GetComponentInChildren<Text>().text = "No";
                    chose1.GetComponent<Button>().onClick.AddListener(changPath1);
                    break;
                }

                else if(part == 1)

                {
                    dilog.runInstance(part);
                    chose1.GetComponent<Button>().onClick.RemoveListener(changPath1);
                    chose1.GetComponentInChildren<Text>().text = "a player would be nice";
                    chose1.gameObject.SetActive(true);
                    chose1.GetComponent<Button>().onClick.AddListener(changPath2);
                    chose2.GetComponentInChildren<Text>().text = "some senery would be nice";
                    chose2.gameObject.SetActive(true);
                    chose2.GetComponent<Button>().onClick.AddListener(changPath3);
                    break;
                }

               else if(part == 2)

                {
                    dilog.runInstance(part);
                    chose1.GetComponent<Button>().onClick.RemoveListener(changPath2);
                    chose2.GetComponent<Button>().onClick.RemoveListener(changPath2);
                    chose1.gameObject.SetActive(false);
                    chose2.gameObject.SetActive(false);
                    chose3.gameObject.SetActive(false);
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        SummonPlayer();
                        part = 4;
                    }
                    break;
                }
               else if (part == 3)

                {
                    dilog.runInstance(part);
                    chose1.GetComponent<Button>().onClick.RemoveListener(changPath2);
                    chose2.GetComponent<Button>().onClick.RemoveListener(changPath2);
                    chose1.gameObject.SetActive(false);
                    chose2.gameObject.SetActive(false);
                    chose3.gameObject.SetActive(false);
                    if(Input.GetKeyUp(KeyCode.Space))
                    {
                        addEnvionment();
                        part = 4;
                    }

                    break;
                }

               else if(part == 4)
                {
                    dilog.runInstance(part);
                    chose1.gameObject.SetActive(false);
                    chose2.gameObject.SetActive(false);
                    chose3.gameObject.SetActive(false);
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        instance = 98;
                        part = 0;
                    }
                    break;
                }
                //chose1.gameObject.SetActive(true);
                
            break;

            default:
                chose1.gameObject.SetActive(false);
                chose2.gameObject.SetActive(false);
                chose3.gameObject.SetActive(false);
                boxHid.gameObject.SetActive(false);
                break;
        }
            
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

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            addEnvionment();
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

    void addEnvionment()
    {

        backDrop.SetActive(false);

    }

    void changPath1()
    {
        part = 1;
    }

    void changPath2()
    {
        part = 2;
    }

    void changPath3()
    {
        part = 3;
    }

    IEnumerator wate()
    {
        yield return new WaitForSeconds(500);
    }
}
