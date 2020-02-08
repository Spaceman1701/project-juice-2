using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Table : MonoBehaviour
{
    [System.Serializable]
    public class Place {
        public Table parent;
        public Transform sitWaypoint;
        public FoodPlaceVolume volume;
    }


    public int tableIndex;

    public Place[] places;

    // Start is called before the first frame update
    void Start()
    {
        if(tableIndex == null){
            Debug.LogError("Table doesn't have an index");
        }

        foreach (Place place in places) {
            place.parent = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getTableIndex(){
        return tableIndex;
    }
}
