using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
    //int value for the next point index
    public int nextID = 0;
    //value of that applies to ID for changing
    int IdChangeValue = 1;
    public float speed = 4;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;
        //Create root object
        GameObject root = new GameObject(name + "_root");
        //Reset pos of root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints pos to root

        //make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //create two points(gameobject) and reset their pos to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //flip enemy axis
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //check the distance between enemy and goal point for trigger to next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line(make the change -1)
            if (nextID ==points.Count -1)
            {
                IdChangeValue = -1;
            }
            //Check if we are at the start of the line(make the change +1) 
            if (nextID == 0)
            {
                IdChangeValue = 1;
            }
            //apply the changes on the nextID
            nextID += IdChangeValue;
        }
    }
}
