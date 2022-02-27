using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExpressions : MonoBehaviour
{
    public Animator expresionAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            expresionAnim.SetTrigger("Alerted");
            gameObject.transform.parent.GetComponent<EnemyMovement>().characterInRange = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent.GetComponent<EnemyMovement>().characterInRange = false;
            gameObject.transform.parent.GetComponent<EnemyMovement>().stopEnemy();
            gameObject.transform.parent.GetComponent<EnemyMovement>().invokeRepeatingWorkAround();
        }
    }
}
