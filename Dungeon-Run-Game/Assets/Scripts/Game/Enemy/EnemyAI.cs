using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    //References to waypoints
    public List<Transform> points;
    //int value for the next point index
    public int nextID;
    //value that applies to the id for changing
    int IdChangeValue = 1;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Box Collider for Trigger
        GetComponent<BoxCollider2D>().isTrigger = true;
        //Create root object
        GameObject root = new GameObject(name + "_root");
        //Reset root object position to enemy
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //create waypoints objects
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to root

        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        //Create two points (gameobjects) and reset their position to waypoints objects
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform);


        //Init points list, then ass the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
}
