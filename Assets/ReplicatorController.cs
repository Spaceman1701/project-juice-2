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

    public GameObject breadPrefab;
    public GameObject gearPrefab;
    public GameObject lettucePrefab;
    public GameObject tomatoPrefab;
    public GameObject platePrefab;

    public Transform spawnPoint;


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
        Vector3 spawnLoc = spawnPoint.position;
        GameObject createdObject = null;

        foreach (ButtonKind buttonPress in spawnList)
        {
            if (buttonPress == ButtonKind.Bread)
            {
                createdObject = Instantiate(breadPrefab);
            }
            if (buttonPress == ButtonKind.Gear)
            {
                createdObject = Instantiate(gearPrefab);
            }
            if (buttonPress == ButtonKind.Lettuce)
            {
                createdObject = Instantiate(lettucePrefab);
            }
            if (buttonPress == ButtonKind.Tomato)
            {
                createdObject = Instantiate(tomatoPrefab);
            }
            if (buttonPress == ButtonKind.Plate)
            {
                createdObject = Instantiate(platePrefab);
            }
            else
            {
                Debug.LogError("Spawned something bad, the hell: " + buttonPress);
            }

            if (createdObject != null)
            {
                createdObject.transform.position = spawnLoc;
                spawnLoc = createdObject.GetComponent<StackableObject>().top.position;
            }
        }
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
            if (spawnList.Count < 10)
            {
                spawnList.Add(kind);
            }
        }
    }
}
