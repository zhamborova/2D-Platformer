using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //Moves the platform along the x axis
    public float maxX;
    public float minX;
    public bool directionRight = true;
    // Start is called before the first frame update
    void Start()
    {
       maxX = transform.position.x + 2.32f;
       minX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight)
        {
            transform.Translate(new Vector2(1 * Time.deltaTime, 0));

        }
        else {
            transform.Translate(new Vector2(-1 * Time.deltaTime, 0));
        }

        if (transform.position.x >= maxX)
        {
            directionRight = false;
        }

        else if (transform.position.x <= minX)
            {
                directionRight = true;
            }







    }
}
