using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStats : MonoBehaviour
{
    public Transform healthBar;
    public Slider healthFill;

    public float currentHealth = 100;

    public float maxHealth;

    public float healthBarYOffset = 2;

   GameObject winScreen;





    #region MonoBehavior API 




    void Update()
    {
        PositionHealthBar();
        if (currentHealth == 0f)
        {
            EnemyGenerator.instance.enemyCount -= 1;
            Destroy(gameObject);

        }
        if (EnemyGenerator.instance.enemyCount < 0)
        {

            //  winScreen = GameObject.Find("WinScreenCanvas").GetComponent<WinScreen>();

            //winScreen.SetActive(true);
                WinScreen.instance.winScreen.SetActive(true);
            
            
        }
    }

    public void ChangeHealth( int amount)
    {
        Debug.Log("this should change");
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth / maxHealth;
    }

    private void PositionHealthBar()
    {
        Vector3 currentPos = transform.position;
        healthBar.position = new Vector3(currentPos.x, currentPos.y + healthBarYOffset, currentPos.z);

        healthBar.LookAt(Camera.main.transform);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("damage Taken");
        Debug.Log(healthFill.value);
    }
    #endregion
    
}
