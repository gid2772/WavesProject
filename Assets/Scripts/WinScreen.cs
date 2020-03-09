using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
    
{
    public static WinScreen instance;
     public GameObject winScreen;



    public void Awake()
    {
      if (!instance)
        {
            instance = this;

        }
        winScreen.SetActive(false);
    }

}
