using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlaceVolume : MonoBehaviour
{

    public enum PlaceType{
        Table,
        HostStand
    }

    public Transform place;
    public PlaceType placeType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlaceType getPlaceType(){
        return placeType;
    }

    public int getTableIndex(){
        Table table = place.gameObject.GetComponent<Table>();
        if(table != null){
            Debug.Log("table index: "+ table.getTableIndex());
            return table.getTableIndex();
        }
        return -1;
    }
}
