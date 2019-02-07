using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartOrQuit : MonoBehaviour
{    
    //listeners were set in the inspector
    public Button restartB;
    public Button quitB;
    public Text winning;


   public void Update()
    {
      
        if (PlayerControl.won) {
            winning.text = "Awww you made it :)";

        }
        else
        {
            winning.text = "Well, this is awkward...";
        }
     

    }

  

    public void restart()
    {
        SceneManager.LoadScene(0);
        PlayerControl.health = 3;
    }

    public void quit()
    {
        Application.Quit();
  
    }


}

