using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{


   //Parent the platform to the player so he moves along with it
  void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
       
            other.collider.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.collider.transform.SetParent(null);
        }
    }
}
