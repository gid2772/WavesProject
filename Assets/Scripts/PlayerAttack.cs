using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public static PlayerAttack instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 10)
        {
            if (Input.GetKey(KeyCode.J))
            {
               // Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                Collider[] enemiesToDamage = Physics.OverlapSphere(transform.position/*attackPos.position*/, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                  
                    if (enemiesToDamage[i].GetComponent<EnemyStats>())
                    {
                        Debug.Log(enemiesToDamage[i].gameObject);
                        enemiesToDamage[i].GetComponent<EnemyStats>().TakeDamage(damage);
                        enemiesToDamage[i].GetComponent<EnemyStats>().ChangeHealth(-damage);
                    }
                }


            }

            timeBtwAttack = startTimeBtwAttack;
        }
           
        
        else
        {
            timeBtwAttack = Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
