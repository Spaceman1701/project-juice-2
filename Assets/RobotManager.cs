using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{

    // Dictionary<int,GameObject> robotTransformGroup = new Dictionary<int, GameObject>();
    Dictionary<int,Robot> robotGroup = new Dictionary<int,Robot>();

    public Transform menuTransform;
    public List<Transform> queueWaypoints;
    public List<Transform> tableList;
    public int firstEmptyIndex;
    private Menu menu; 

    public GameObject robotPrefab;
 
    // Start is called before the first frame update
    void Start()
    {
        firstEmptyIndex = 0;
        menu = menuTransform.gameObject.GetComponent<Menu>();
        // robot = robotTransform.gameObject.GetComponent<Robot>();
        // robot.setWaypoint(menuTransform);

        Invoke("SpawnRobotGroup", 2f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void setWaypoint(Transform waypoint){
        
    }

    void SpawnRobotGroup(){
        Debug.Log("spawning");
        if (firstEmptyIndex != queueWaypoints.Count){
            Debug.Log("firstEmptyIndex "+firstEmptyIndex);

            for(int i = 0; i<4; i++){
                
                GameObject robotGO = Instantiate(robotPrefab);
                Robot robot = robotGO.GetComponent<Robot>();
                robot.updateState(Robot.RobotState.Queue);

                Debug.Log("setting waypoint "+ queueWaypoints[firstEmptyIndex]);
                robot.setWaypoint(queueWaypoints[firstEmptyIndex]);
                robot.setRobotIndex(i);
            }


            //robotGroup[firstEmptyIndex] = robot;

            //Debug.Log(robotGroup);
            Invoke("SpawnRobotGroup", 2f);
            firstEmptyIndex ++;
        }
        
    }

    

}
