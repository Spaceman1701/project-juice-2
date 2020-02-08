using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{

    // Dictionary<int,GameObject> robotTransformGroup = new Dictionary<int, GameObject>();

    private List<RobotGroup> allRobotGroups = new List<RobotGroup>();
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
        if (menu.justPickedUp){
            RobotGroup moving = allRobotGroups[0];
            moving.setAllWaypoints(menuTransform);
            moving.setAllStates(Robot.RobotState.Follow);
            menu.justPickedUp = false;
            ScootGroup();
        }
    }

    void ScootGroup(){
        for (int i = 0; i < queueWaypoints.Count; i++){
            Debug.Log("robot length "+allRobotGroups.Count);
            allRobotGroups[allRobotGroups.Count-firstEmptyIndex+1].setAllWaypoints(queueWaypoints[i]);
            Debug.Log("i: "+i+", robot index: "+(allRobotGroups.Count-firstEmptyIndex+1));
            firstEmptyIndex -= 1;
        }
    }

    void SpawnRobotGroup(){
        Debug.Log("spawning");
        if (firstEmptyIndex != queueWaypoints.Count){
            Debug.Log("firstEmptyIndex "+firstEmptyIndex);
            RobotGroup robotGroupTemp = new RobotGroup();

            for(int i = 0; i<4; i++){    
                GameObject robotGO = Instantiate(robotPrefab);
                Robot robot = robotGO.GetComponent<Robot>();
                robotGroupTemp.addRobot(robot);

                Debug.Log("setting waypoint "+ queueWaypoints[firstEmptyIndex]);                
            }
            robotGroupTemp.setAllWaypoints(queueWaypoints[firstEmptyIndex]);
            Debug.Log("robotGroupTemp "+robotGroupTemp);
            allRobotGroups.Add(robotGroupTemp);

            Debug.Log(allRobotGroups);

            firstEmptyIndex ++;
        }
        Invoke("SpawnRobotGroup", 2f);
        
    }

}

class RobotGroup{
    List<Robot> robots = new List<Robot>();
    private int ind = 0;
    public void addRobot(Robot robot){
        robot.setState(Robot.RobotState.Queue);
        robot.setRobotIndex(ind);
        robots.Add(robot);
        ind ++;   
    }
    public void setAllWaypoints(Transform newWaypoint){
        foreach(Robot robot in robots){
            robot.setWaypoint(newWaypoint);
        }
    }

    public void setAllStates(Robot.RobotState state){
        foreach(Robot robot in robots){
            robot.setState(state);
        }
    }



}
