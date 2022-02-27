using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject character;
    public float xAxisSpeed = 300;
    public float zAxisSpeed = 300;
    bool moving;
    public bool characterInRange=false;
    float distance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("invokeRepeatingWorkAround",1,4);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (characterInRange)
        {
            moveTowardscharacter3();
        }
    }

    Vector3 generateAngleToMove()
    {
        float xValue = Random.Range(-distance, distance);
        float zValue = Random.Range(-distance, distance);
        Vector3 direction = new Vector3(xValue, 0, zValue);
        return direction;
    }

    void moveEnemy(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction;
    }
    public void invokeRepeatingWorkAround()
    {
        Vector3 direction = generateAngleToMove();
        moveEnemy(direction);
        InvokeRepeating("stopEnemy", 1, 3);
    }

    public void stopEnemy()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void checkIfCharacterInRange()
    {

    }


    public void moveTowardscharacter3()
    {
        GetComponent<Rigidbody>().velocity = new Vector3((character.transform.position.x- gameObject.transform.position.x) *xAxisSpeed* Time.deltaTime, 0, (character.transform.position.z - gameObject.transform.position.z) * zAxisSpeed * Time.deltaTime);
    }


        public void moveTowardscharacter2()
    {
        float partner_X_position = gameObject.transform.position.x;
        float partner_Z_position = gameObject.transform.position.z;

        float character_X_position = character.transform.position.x;
        float character_Z_position = character.transform.position.z;

        Rigidbody rb = GetComponent<Rigidbody>();



        if (partner_X_position < character.transform.position.x)
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            GetComponent<Rigidbody>().velocity = (new Vector3(xAxisSpeed * Time.deltaTime, 0, 0));
            anim.SetFloat("speed", xAxisSpeed);

            moving = true;
        }
        if (partner_X_position > character.transform.position.x)
        {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            GetComponent<Rigidbody>().velocity = (new Vector3(-xAxisSpeed * Time.deltaTime, 0, 0));
            anim.SetFloat("speed", xAxisSpeed);

            moving = true;
        }



        if (partner_Z_position < character.transform.position.z  )
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_Z_position > character.transform.position.z  )
        {
            //transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);
            moving = true;
        }

        if (partner_Z_position < character.transform.position.z  && partner_X_position < character.transform.position.x )
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(xAxisSpeed * Time.deltaTime, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position > character.transform.position.x  && partner_Z_position > character.transform.position.z )
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(-xAxisSpeed * Time.deltaTime, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position < character.transform.position.x && partner_Z_position > character.transform.position.z )
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(xAxisSpeed * Time.deltaTime, 0, -zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }
        if (partner_X_position > character.transform.position.x  && partner_Z_position < character.transform.position.z )
        {
            //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(-xAxisSpeed * Time.deltaTime, 0, zAxisSpeed * Time.deltaTime);
            anim.SetFloat("speed", zAxisSpeed);

            moving = true;
        }


    }


}
