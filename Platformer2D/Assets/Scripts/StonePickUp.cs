using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StonePickUp : MonoBehaviour
{
    //struct to hold stones information along with their index in the list of images
    public struct StoneIndex
    {
        public GameObject st1;
        public int indx;

    }
    //empty slot sprite
    public Sprite empty;
    //text to display once we try to pick up 6th stone
    public Text full;
    //current stone we are colliding with
    private GameObject currentObj;
    //number of stones we picked
    private int stonesPicked = 0;
    //are touchingthe stone?
    private bool touching;
    //list of stone's structs
    private List<StoneIndex> stored = new List<StoneIndex>();
    //stones images on the ui
    public Image[] stones;
    //indexes count
    private int i = 0;
   

    public void Update()
    {
         
        //if we are touchinghte stone and we have space add a new stone to the next available slot
        if (Input.GetKeyDown(KeyCode.E) && touching)
        {

            if (stonesPicked < 5)
            {

                StoneIndex pickedUp = new StoneIndex();
                pickedUp.st1 = currentObj;

                stones[i].sprite = pickedUp.st1.GetComponent<SpriteRenderer>().sprite;
                pickedUp.indx = i;
                stored.Add(pickedUp);
                stonesPicked++;
                touching = false;
                stored[i].st1.SetActive(false);
                i++;
                
            }
            //display the message we we try to pick up extra stone
            else if (Input.GetKeyDown(KeyCode.E) && touching && stonesPicked == 5)
                {

                full.text = "Inventory is full!";
                //delay for visually pleasant timing
                Invoke("ShowMessage", 1);
            }


        }
     

        //drop the blue stone if we have it
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (exists("BlueStone")) {
                rem(stored.FindLast(element => element.st1.tag == "BlueStone").indx);
                stored.RemoveAt(stored.FindLastIndex(element => element.st1.tag == "BlueStone"));

            }
        }



        //drop the green stone if we have it
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (exists("GreenStone"))
            {
                rem(stored.FindLast(element => element.st1.tag == "GreenStone").indx);
                stored.RemoveAt(stored.FindLastIndex(element => element.st1.tag == "GreenStone"));
            }
         
        }

        if (Input.GetKeyDown(KeyCode.V))

        {
            if (exists("VolcanicStone"))
             
            {
                rem(stored.FindLast(element => element.st1.tag == "VolcanicStone").indx);
                stored.RemoveAt(stored.FindLastIndex(element => element.st1.tag == "VolcanicStone"));
            }
        }


        //drop the while stone if we have it
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (exists("WhiteStone"))
            {
                rem(stored.FindLast(element => element.st1.tag == "WhiteStone").indx);
                stored.RemoveAt(stored.FindLastIndex(element => element.st1.tag == "WhiteStone"));
            }
        }

        //drop the purple stone if we have it
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (exists("PurpleStone"))
            {
                rem(stored.FindLast(element => element.st1.tag == "PurpleStone").indx);
                stored.RemoveAt(stored.FindLastIndex(element => element.st1.tag == "PurpleStone"));

            }
        }

    }

    //check if we have a particular stone in the inventory
    bool exists(string name)
    {
        bool exists = false;
        foreach (StoneIndex item in stored)
        {
            if (item.st1.tag == name)
            {
                exists = true;
            }
        }
        return exists;

    }
  
    //remove the stone at index d
      void rem( int d)
    {
        i--;
        stones[d].sprite = empty;
        stonesPicked--;
    }


    //make the message "Inventory is full" disappear
    void ShowMessage()
    {          
            full.text = "";
        
    }


    //set the stone we are etouching to our current stone
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Contains("Stone"))
        {

            touching = true;
            currentObj = other.gameObject;
     
        }
    }

    //set the current to null if we are no longer colliding with any stone
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag.Contains("Stone"))
        {

            touching = false;
            currentObj = null;

        }
    }

}
