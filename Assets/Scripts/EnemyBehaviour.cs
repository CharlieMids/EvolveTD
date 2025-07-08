using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 10f;
    private Transform target;
    private int waypointNext;

    //Setting the variables needed in this script

    void Start()
    {
        target = WaypointScript.points[0];
        //Sets the target to be the first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = target.position - transform.position;
        //Sets the movedirection to be directly towards the next waypoint
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        //moves in the movedirection at a specified speed
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotateSpeed * Time.deltaTime);
        //Sets the rotation to be a fraction of the rotation to the next waypoint each frame
        transform.rotation = rot;
        //sets the rotation of the enemy

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        //checks if the enemy is within 0.2 m of the waypoint
        {
            GetNextWaypoint();
            //calls the method to get the next waypoint
        }
    }

    void GetNextWaypoint()
    //Declares a method
    {
        if (waypointNext >= WaypointScript.points.Length - 1)
        //checks if there is not a next waypoint
        {
            Destroy(gameObject);
            //Destroys the enemy
            return;
            //exits the method
        }
        waypointNext++;
        //sets the next waypoint number
        target = WaypointScript.points[waypointNext];
        //selects the next waypoint from the array
    }
}
