using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    private bool isGrounded;
    public Text coins;
    public static bool won = false;
    //current image of the health bars
    public Image heartCurrent;
    //number of health hearts left
    public static int health = 3;
    //images of different health hearts
    public Sprite[] hearts;
    //reference to the player
    private Rigidbody2D rb;
    public int coinsCollected = 0;
    //direction in which player is going
    public int direction = 1;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        coins.text =  coinsCollected.ToString();
    }
	
	// Update is called once per frame
	void Update () {
      
        heartCurrent.sprite = hearts[health];
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(moveHorizontal * Time.deltaTime * 2, 0.0f));
         
        //restrict players movement not to go outside the map
        transform.position = new Vector2( Mathf.Clamp(transform.position.x, -8.6f, 8.5f), transform.position.y);

        //update directions
        if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 1;
            }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = -1;
            }

        //jump if grounded
            if (isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(direction * moveHorizontal * Time.deltaTime + (direction * 1), 6),
                        ForceMode2D.Impulse);

                }
            }
        
       


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if we are on top tiles we are grounded
        if (collision.gameObject.tag == "Top Tiles")
        {
            isGrounded = true;
        }
        //reached the end of level
        if (collision.gameObject.tag == "Finish")
        {
            won = true;
            SceneManager.LoadScene("menu");
        }

        //picked up a coin
            if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            coinsCollected++;
            coins.text =  coinsCollected.ToString();
        }
            //collided with a hazard
            //reload scene if we have health left 
            //else switch menu scene
            if (collision.gameObject.tag == "Cactus")
           {
          
            if (health > 0)
            {
                health = health - 1;
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.LoadLevel("menu");
            }
           
        }
    }

   
    void OnCollisionExit2D(Collision2D theCollision)
    {

      // not touching the ground anymore
        if (theCollision.gameObject.name != "Top Tiles")
        {
          
            isGrounded = false;
        }
    }




    //wait few seconds before reloading
    void DelayRestart()
    {
      health = health - 1;
      SceneManager.LoadScene(0);
    }
}

