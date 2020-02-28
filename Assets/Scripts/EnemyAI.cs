using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float playerDistance;
    public static bool isPlayerAlive = true;
    public int damage;
    RaycastHit hit;
    bool drawPlayerHitGizmo;
    // public int health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (isPlayerAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            playerDistance = Vector3.Distance(player.position, transform.position);
            if (playerDistance < 3f)
            {
                attack();
            }
        }

       
        
        
    }

    void attack()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
          
           // Debug.DrawRay(transform.position,transform.forward, Color.red, 5f);
          
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("player should be hit V1");
                hit.collider.gameObject.GetComponent<PlayerStats>().ChangeHealth(-damage);
            }
        }
        else
            drawPlayerHitGizmo = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
      /*  if (drawPLayerHitGizmo)
        {
            Gizmos.color = Color.red;
            Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
            Debug.DrawRay(transform.position, direction,Color.red,5f);
           // Gizmos.DrawRay(transform.position, direction,10);
        }*/
    }

    //Ienumerator for repeating a peace of code 
    //InvokeRepeating also works, look up the difference. 

    // every 5 seconds check if the player is within distance and lower the player health. 

    /* public void TakeDamage(int damage)
     {
         health -= damage;
         Debug.Log("damage Taken");
     }*/
}
