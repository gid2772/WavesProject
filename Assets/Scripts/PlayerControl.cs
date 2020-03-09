
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {
    public Animator animator;
    public float speed = 7;
    private Rigidbody rig;
    public static PlayerControl instance;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        rig.MovePosition(transform.position + movement);

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }
    public void Awake()
    {
    if (!instance)
        {
            instance = this;
        }    
    }

}

