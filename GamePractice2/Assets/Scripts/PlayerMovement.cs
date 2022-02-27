using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AnimationClip slashAnimation;
    bool m_FacingRight = true;
    public CharacterController controller;
    public Animator anim;
    float speed = 4;
    public float walkSpeed = 5f;
    float gravity = 8;
    float horizontalMove = 0;
    float verticalMove = 0;
    Vector3 moveDir = Vector3.zero;
    bool walkingRight = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("MainCharacterSlashFlipped")){  
           if (Input.GetKeyDown("space") || (Input.GetKeyDown("space") &&
               (Input.GetKey("right") ||
                   Input.GetKey("left") ||
                   Input.GetKey("up") ||
                   Input.GetKey("down"))))
           {
                Vector3 movement = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().velocity = movement * speed;
                anim.SetFloat("speed", 0);
               anim.SetTrigger("attacking");
           }  
           else if ((Input.GetKey("right") ||
                   Input.GetKey("left") ||
                   Input.GetKey("up") ||
                   Input.GetKey("down")))
           {
               anim.SetFloat("speed", walkSpeed);
               Rigidbody rb = GetComponent<Rigidbody>();
               Vector3 movement = new Vector3(-verticalMove, 0, horizontalMove);
               GetComponent<Rigidbody>().velocity = movement * speed;
               }
           else
               {
                   anim.SetFloat("speed", 0);
                   Vector3 movement = new Vector3(0, 0, 0);
                   GetComponent<Rigidbody>().velocity = movement * speed;
            }
            if (Input.GetKey("right") && !m_FacingRight)
            {
                Flip();
            }
            if (Input.GetKey("left") && m_FacingRight)
            {
                Flip();
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("MainCharacterSlashFlipped"))
        {
            Vector3 movement = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        
      
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        if (m_FacingRight)
        {
            Vector3 newRotation = new Vector3(0, 90, 0);
            transform.eulerAngles = newRotation;

        }
        else
        {
            Vector3 newRotation = new Vector3(0, -90, 0);
            transform.eulerAngles = newRotation;

        }

    }

}
