using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{

    //Uses X axis 


    public Transform startPos;
    public Transform endPos;

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
        Press();
    }

    private void OnTriggerExit(Collider other)
    {
        Unpress();
    }


    void Press()
    {

        Vector3 current = transform.position;
        current.x = endPos.position.x;

        transform.position = current;
    }

    void Unpress()
    {
        Vector3 current = transform.position;
        current.x = startPos.position.x;

        transform.position = current;
    }
}
