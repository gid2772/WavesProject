using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public string mainMenuLevel;
    public static DeathScreen instance;
    public PlayerControl playerControl;
    public GameObject deathScreen;

    public float gameOverScreen;
    //gameobj player
    //GameObject gameoverscreen 

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
       
        deathScreen.SetActive(false);
    }


    public void RestartGame()
    {
        //CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
        //cc.enabled = false;
        // disable player. 
        //Set Time.timescale to 0 
        //enable game over screen object

        SceneManager.LoadScene("Level 1-1");
        EnemyAI.isPlayerAlive = (true);
    }
}
