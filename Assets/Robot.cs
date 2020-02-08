using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public enum RobotState{
        Queue,
        Follow,
        Sit,
        Eat,
        Leave
    }

    public float speed; // try 1
    public int robotIndex;
    private RobotState state;
    private Transform waypoint;
    private Vector3 goalPos;
    public float offset = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    public void updateState(RobotState updatedState){
        state = updatedState;
    }

    public void setRobotIndex(int index){
        robotIndex = index;
    }

    public void setWaypoint(Transform newWaypoint){
        Debug.LogError("setting waypoint to "+newWaypoint);
        waypoint = newWaypoint;
    }

    void move(){
        setRobotGoalPos();
        // Debug.Log("current pos "+transform.position+" goal pos: "+goalPos);
        if (Vector3.Distance(transform.position, goalPos) > 0.001f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goalPos, step);
        }
    }

    void setRobotGoalPos(){ // set based on waypoint
        if(waypoint != null){
            // goalPos = waypoint.position;

            if (robotIndex == 0){
                goalPos = new Vector3(waypoint.position.x - offset, waypoint.position.y, waypoint.position.z);
            }
            if (robotIndex == 1){
                goalPos = new Vector3(waypoint.position.x, waypoint.position.y, waypoint.position.z - offset);
            }
            if (robotIndex == 2){
                goalPos = new Vector3(waypoint.position.x - offset, waypoint.position.y, waypoint.position.z - offset*2);
            }
            if (robotIndex == 3){
                goalPos = new Vector3(waypoint.position.x - offset, waypoint.position.y, waypoint.position.z - offset*3);
            }
            // Debug.Log(goalPos);
        }
        else{
            Debug.Log("bad waypoint");
        }
    }
}
