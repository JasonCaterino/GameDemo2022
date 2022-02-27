using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    bool curtainsOverCamera = false;
    public GameObject curtainL;
    public GameObject curtainR;
    public GameObject[] playerCharactersArray;
    public GameObject[] playerCharactersSpots;
    public GameObject[] enemiesArray;
    public GameObject[] enemiesSpots;
    public GameObject[] possibleEnemiesInRoom;
    public GenericRoomScript room;
    int numOfCharacters = 2;
    // Start is called before the first frame update
    void Start()
    {
        //yield return StartCoroutine(moveCurtainsOverCamera());
        //yield return new WaitForSeconds(5);
        //yield return StartCoroutine(moveCurtainsOffCamera());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {


            StartCoroutine(moveCurtain());
        }
    

    }

    //void moveCurtainsOverCamera()
    //{
    //    transform.Translate(Vector3.right * Time.deltaTime);
    //}

    public IEnumerator moveCurtain()
    {
        yield return StartCoroutine(moveCurtainsOverCamera());
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(moveCurtainsOffCamera());


    }

    public IEnumerator moveCurtainsOverCamera()
    {
        Vector3 startPosL = curtainL.transform.position;
        Vector3 startPosR = curtainR.transform.position;
        float t = 0f;
        while (t < 1f)
        {
            curtainL.transform.position = new Vector3(curtainL.transform.position.x, curtainL.transform.position.y, curtainL.transform.position.z + .1f);
            curtainR.transform.position = new Vector3(curtainR.transform.position.x, curtainR.transform.position.y, curtainR.transform.position.z - .1f);
            t += Time.deltaTime;
            yield return null;
            curtainsOverCamera = true;
        }


    }
    public IEnumerator moveCurtainsOffCamera()
    {
        Vector3 startPosL = curtainL.transform.position;
        Vector3 startPosR = curtainR.transform.position;
        float t = 0f;
        while (t < 1f)
        {
            curtainL.transform.position = new Vector3(curtainL.transform.position.x, curtainL.transform.position.y, curtainL.transform.position.z - .1f);
            curtainR.transform.position = new Vector3(curtainR.transform.position.x, curtainR.transform.position.y, curtainR.transform.position.z + .1f);
            t += Time.deltaTime;
            yield return null;
            curtainsOverCamera = false;
        }


    }

    public void generateEnemiesForBattle(GameObject encounteredEnemy)
    {
        int numberOfPossibleEnemies = possibleEnemiesInRoom.Length;
        enemiesArray[0] = encounteredEnemy;
        for (int i = 1; i < enemiesArray.Length; i++)
        {
            int enemyNumber = Random.Range(1, numberOfPossibleEnemies);
            enemiesArray[i] = possibleEnemiesInRoom[i];
        }
    }

    public void moveCharactersInPlaceForBattle()
    {
        for(int i = 0; i < playerCharactersArray.Length; i++)
        {
            playerCharactersArray[i].transform.position = playerCharactersSpots[i].transform.position;
        }

        for(int i = 0; i < enemiesArray.Length; i++)
        {
            Instantiate(enemiesArray[i],  enemiesSpots[i].transform.position, Quaternion.identity, enemiesSpots[i].transform);
        }
    }

}
//Lunacian #23377389