using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformY : MonoBehaviour
{
    //Moves the platform up and down
    public float maxY;
    public float minY;
    public bool directionDown = true;
    // Start is called before the first frame update
    void Start()
    {
        maxY = transform.position.y;
        minY = transform.position.y - 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (directionDown)
        {
            transform.Translate(new Vector2( 0, -1 * Time.deltaTime));

        }
        else
        {
            transform.Translate(new Vector2(0, 1 * Time.deltaTime));
        }

        if (transform.position.y <= minY)
        {
            directionDown = false;
        }

        else if (transform.position.y >= maxY)
        {
            directionDown = true;
        }







    }
}
