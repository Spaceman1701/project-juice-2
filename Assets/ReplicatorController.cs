using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicatorController : MonoBehaviour
{

    public enum ButtonKind
    {
        Bread,
        Gear,
        Lettuce,
        Tomato,
        Plate,
        Go
    }


    VRButton[] buttons;

    List<Spawnable> spawnList = new List<Spawnable>();

    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<VRButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
