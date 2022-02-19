using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouninngennController : MonoBehaviour
{

    Animator animator;

    Rigidbody2D rigid2D;

    private float groundLevel = -3.0f;

    private float dump = 0.8f;
    
    float jumpVelocity = 20;

    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {

        this.animator = GetComponent<Animator>();

        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
  

   

    void Update()
    { 


        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        animator.SetBool("isGround", isGround);

        GetComponent<AudioSource>().volume = (float)((isGround) ? 0.3: 0);
        if (Input.GetMouseButtonDown (0) && isGround)
        {

            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        }

        if (Input.GetMouseButton (0) == false)
        {


            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }



        }

        if (transform.position.x < this.deadLine)
        {

            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();


            Destroy(gameObject);

        }
    }
    
}
