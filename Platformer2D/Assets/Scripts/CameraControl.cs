using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    //
    public GameObject player;
    [SerializeField]
    private float maxX = 2.8f;
    [SerializeField]
    private float minX = -2.7f;
    [SerializeField]
    private float maxY = 1.5f;
    [SerializeField]
    private float minY = -1.13f;
 
     void Update()
    {   //make the camera follow the player around
        transform.position = player.transform.position;
    }


    void LateUpdate()
    {
        //restrict camera movement to the scene size
        transform.position = new Vector3( transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), -1);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, -1);
    }
}