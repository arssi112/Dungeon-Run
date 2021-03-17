using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public GameObject DeadPanel;

    private void Start()
    {
        DeadPanel.SetActive(false);
    }
    public void LoseLife()
    {
        if (livesRemaining == 0)
        {
            return;
        }
        //Decrese the value of livesRemaining
        livesRemaining--;
        //Hide one of the lives images
        lives[livesRemaining].enabled = false;
        //if we run out of lives, we lose the game
        if (livesRemaining == 0)
        {
            FindObjectOfType<Player>().Die();
            DeadPanel.SetActive(true);
        }
    }

    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Q))
        {
            LoseLife();
        }*/
    }
}
