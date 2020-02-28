using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Transform healthBar;
    public Slider healthFill;

    public float currentHealth = 100;

    public float maxHealth;

    public float healthBarYOffset = 2;



    #region MonoBehavior API 




    void Update()
    {
        PositionHealthBar();
        if (currentHealth == 0f)
        {
            EnemyAI.isPlayerAlive = false;
            Destroy(gameObject);
        }
    }

    public void ChangeHealth(int amount)
    {
        Debug.Log(currentHealth += amount);
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

