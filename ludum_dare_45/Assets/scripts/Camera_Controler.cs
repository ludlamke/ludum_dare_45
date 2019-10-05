using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controler : MonoBehaviour
{
    public bool cameraEnabled;
    private float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Transform target;

    void Start()
    {
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if(cameraEnabled)
        {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.50f, 0.50f, point.z)); 
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        }
        
    }

    public void assignplayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

