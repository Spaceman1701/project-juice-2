using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int test;
    private PlaceVolume.PlaceType placeType;
    private bool isOnHost = false;
    private int tableIndex = -1;
    public bool justPickedUp = false;
    public RobotManager robotManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCollision(){
        return 0;
    }

    public void OnTriggerEnter(Collider other){
        PlaceVolume place = other.gameObject.GetComponent<PlaceVolume>();
        Debug.Log(place);
        if (place != null){
            Debug.Log(place.getPlaceType());
            placeType = place.getPlaceType();
            if (placeType == PlaceVolume.PlaceType.HostStand){
                isOnHost = true;
                Debug.Log("Setting host collision to true");
            }
            else{
                tableIndex = place.getTableIndex();
                Table table = other.GetComponentInParent<Table>();
                Debug.Log("Got table!");
                if (table != null) {
                    Debug.Log("It wasn't null!");
                    robotManager.notifyMenuAtTable(table);
                }
            }
        }
    }

    void onTriggerExit(){
        isOnHost = false;
        tableIndex = -1;
        justPickedUp = true;
    }


}
