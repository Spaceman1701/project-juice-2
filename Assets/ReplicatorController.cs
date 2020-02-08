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

    List<ButtonKind> spawnList = new List<ButtonKind>();

    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<VRButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFoodList()
    {
        //TODO: SPAWN FOOD PREFABS
    }

    public void AddFood(ButtonKind kind)
    {
        if (kind == ButtonKind.Go)
        {
            SpawnFoodList();
            spawnList.Clear();

            foreach (VRButton button in buttons)
            {
                button.Reset();
            }

        } else
        {
            spawnList.Add(kind);
        }
    }
}
