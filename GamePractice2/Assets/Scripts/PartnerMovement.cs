using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerMovement : MonoBehaviour
{
    float horizontalMove = 0;
    float verticalMove = 0;
    Vector3 prevPosition;
    public Animator anim;
    public GameObject leader;
    public float xAxisSpeed = 90;
    public float zAxisSpeed = 90;
    float distance_from_player=20;
    public bool moving = false;
    public int valueToSwapBetweenXandZaxis=1;
    bool m_FacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            moveTowardsLeader2();
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
        
        //if (!checkIfCharacterIsMoving())
        //{
            
        //    anim.SetFloat("speed", 0);
        //}
        makePartnerFaceLeader();
    }

    private void makePartnerFaceLeader() 
    {
        float partner_Z_position = gameObject.transform.position.z;
        if (partner_Z_position < leader.transform.position.z-10 && !m_FacingRight)
        {
            flip();
        }
        if (partner_Z_position > leader.transform.position.z+10 && m_FacingRight)
        {
            flip();
        }
    }
    private void flip()
    {
        // Switch the way the player is labelled as facing.
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
        // Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }
    bool checkIfCharacterIsMoving()
    {
        Vector3 currentPosition = new Vector3((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z);
        if (currentPosition != prevPosition)
        {
            prevPosition = currentPosition;
            return true;
        }
        return false;

        //if (gameObject.GetComponent<Rigidbody>().velocity.magnitude >0)
        //{
        //    return true;
        //}
        //return false;
    }

    public void moveTowardscharacter3()
    {
        GetComponent<Rigidbody>().velocity = new Vector3((leader.transform.position.x - gameObject.transform.position.x) * xAxisSpeed * Time.deltaTime, 0, (leader.transform.position.z - gameObject.transform.position.z) * zAxisSpeed * Time.deltaTime);
    }

    void moveTowardsLeader()
    {
        float partner_X_position = gameObject.transform.position.x;
        float partner_Z_position = gameObject.transform.position.z;



        Rigidbody rb = GetComponent<Rigidbody>();

        if(valueToSwapBetweenXandZaxis==1)
        {
            
            print(valueToSwapBetweenXandZaxis);
            if (partner_X_position < leader.transform.position.x - 10)
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            GetComponent<Rigidbody>().velocity = (new Vector3(xAxisSpeed * Time.deltaTime, 0, 0));
            anim.SetFloat("speed", xAxisSpeed);

            moving = true;
        }
        if (partner_X_position > leader.transform.position.x + 10)
        {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            GetComponent<Rigidbody>().velocity = (new Vector3(-xAxisSpeed * Time.deltaTime, 0, 0));
            anim.SetFloat("speed", xAxisSpeed);

            moving = true;
        }
            
        }
        if (valueToSwapBetweenXandZaxis == 2)
        {
           
            print(valueToSwapBetweenXandZaxis);
            if (partner_Z_position < leader.transform.position.z - 10)
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_Z_position > leader.transform.position.z + 10)
        {
            //transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);
            moving = true;
        }
            
        }

        if (valueToSwapBetweenXandZaxis == 1)
        {
            valueToSwapBetweenXandZaxis = 2;
        }
        else
        {
            valueToSwapBetweenXandZaxis = 1;
        }

    }

    void moveTowardsLeader2()
    {
        float partner_X_position = gameObject.transform.position.x;
        float partner_Z_position = gameObject.transform.position.z;

        float leader_X_position = leader.transform.position.x;
        float leader_Z_position = leader.transform.position.z;

        Rigidbody rb = GetComponent<Rigidbody>();

     
       
            if (partner_X_position < leader.transform.position.x - 10)
            {
                //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                GetComponent<Rigidbody>().velocity = (new Vector3(xAxisSpeed * Time.deltaTime, 0, 0));
                anim.SetFloat("speed", xAxisSpeed);
            
                moving = true;
            }
            if (partner_X_position > leader.transform.position.x + 10)
            {
                //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                GetComponent<Rigidbody>().velocity = (new Vector3(-xAxisSpeed * Time.deltaTime, 0, 0));
                anim.SetFloat("speed", xAxisSpeed);
       
                moving = true;
            }

        

            if (partner_Z_position < leader.transform.position.z - 10)
            {
                //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, zAxisSpeed * Time.deltaTime);
                anim.SetFloat("speed", zAxisSpeed);

                moving = true;
            }
            if (partner_Z_position > leader.transform.position.z + 10)
            {
                //transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -zAxisSpeed * Time.deltaTime);
                anim.SetFloat("speed", zAxisSpeed);
                moving = true;
            }

        if (partner_Z_position < leader.transform.position.z - 10 && partner_X_position < leader.transform.position.x - 10)
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(xAxisSpeed * Time.deltaTime, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position > leader.transform.position.x + 10 && partner_Z_position > leader.transform.position.z + 10)
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(-xAxisSpeed * Time.deltaTime, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position < leader.transform.position.x - 10 && partner_Z_position > leader.transform.position.z + 10)
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(xAxisSpeed * Time.deltaTime, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position > leader.transform.position.x + 10 && partner_Z_position < leader.transform.position.z - 10)
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(-xAxisSpeed * Time.deltaTime, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("entering");
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            moving = false;
            anim.SetFloat("speed", 0);


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("exiting");
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            moving = true ;
            anim.SetFloat("speed", zAxisSpeed);
        }
    }
}
