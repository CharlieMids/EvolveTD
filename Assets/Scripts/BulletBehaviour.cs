using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform target;
    public float speed = 1000f;
    public void enemyTarget(Transform _target)
    {
        target = _target;
        //gets the target reference from the turret's fire method
    }

    //Setting the variables needed in this script

    void Update()
    {
        if (target == null)
        //If there is not a target
        {
            Destroy(gameObject);
            //delete the bullet
            return;
            //leave void update so that it doesnt try to continue after destruction
        }

        Vector3 dir = target.position - transform.position;
        //Sets the direction of movement
        float distanceForFrame = speed * Time.deltaTime;
        //finds how far it should move compared to time so that framerate does not affect
        //movement
        if (dir.magnitude <= distanceForFrame)
        //if the bullet should move to or past the target
        {
            HitTarget();
            //call the hit target method
            return;
            //Leave void update
        }
        transform.Translate(dir.normalized * distanceForFrame, Space.World);
        //Move distance towards the target in world space
    }

    void HitTarget()
    //Declares the method
    {
        Destroy(gameObject);
        //destroy the bullet
        Destroy(target.gameObject);
        //destroy the enemy
    }
}
