using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{

    //Uses X axis 


    public Transform startPos;
    public Transform endPos;

    public float stickyTime;
    public float stuckTime;

    public ReplicatorController.ButtonKind function;
    public ReplicatorController controller;

    public bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<ReplicatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        stuckTime -= Time.deltaTime;

        if (pressed)
        {
            Press();
        }

        if (!pressed && stuckTime <= 0)
        {
            Unpress();
        }
    }

    public void Reset()
    {
        pressed = false;
        stuckTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        pressed = true;
        stuckTime = stickyTime;
        controller.AddFood(function);
    }

    private void OnTriggerExit(Collider other)
    {
        pressed = false;
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
