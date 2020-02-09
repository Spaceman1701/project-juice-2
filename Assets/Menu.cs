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

    public Transform originPoint;

    public Rigidbody rigidBody;

    public GameObject menuPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
            } else{
                tableIndex = place.getTableIndex();
                Table table = other.GetComponentInParent<Table>();
                Debug.Log("Got table!");
                if (table != null) {
                    Debug.Log("It wasn't null!");
                    robotManager.notifyMenuAtTable(table);
                    Debug.Log("fuck you unity you're the fucking worst how are you real");
                    GameObject newMenu = Instantiate(menuPrefab, originPoint.position, originPoint.rotation);
                    Menu m = newMenu.GetComponent<Menu>();
                    m.originPoint = originPoint;
                    m.robotManager = robotManager;
                    m.menuPrefab = menuPrefab;
                    robotManager.menuTransform = newMenu.transform;
                    Object.Destroy(this.gameObject);
                }
            }
        } else
        {
            Podium p = other.gameObject.GetComponent<Podium>();
            if (p != null)
            {
                isOnHost = true;
            }
        }
    }

    void OnTriggerExit(){
        if (isOnHost)
        {
            isOnHost = false;
            tableIndex = -1;
            justPickedUp = true;
        }
    }


}
