using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        //Sets a new array to have the length of the amount of waypoints
        for (int i = 0; i < points.Length; i++)
        //goes through the number of waypoints
        {
            points[i] = transform.GetChild(i);
            //gets children from first to last so that the waypoints are in order
        }
    }
}
