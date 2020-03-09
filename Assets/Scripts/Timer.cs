using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public float currentTime = 0f;
    float startingTime = 20f ;
    public static Timer instance;
    

   [SerializeField] Text timerText; 

     void Start()
    {
        currentTime = startingTime;
    }
    public void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        timerText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            DeathScreen.instance.deathScreen.SetActive(true);
            EnemyAI.isPlayerAlive = false;
            //GameObject.Find(PlayerControl).GetComponent<PlayerControl>.Enabled = false;
            PlayerControl.instance.speed = 0;
            
        }
        
    }
}
