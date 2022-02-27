using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject characterToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(characterToFollow.transform.position.x + 70, 25, characterToFollow.transform.position.z);
        gameObject.transform.position = newPosition;
    }
}
