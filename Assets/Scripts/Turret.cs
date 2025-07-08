using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TowerStats towerStats;
    public Transform target;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firepoint;

    //Setting the variables needed in this script

    void Start()
    {
        towerStats = gameObject.GetComponent<TowerStats>();
        //gets the stats for the gameobject from the script
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //Calls UpdateTarget() every 0.5 seconds
    }

    void UpdateTarget()
    //Declares a method
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //creates an array of all enemies in scene
        float shortestDistance = Mathf.Infinity;
        //sets a new float to hold the shortest recorded distance with no limit
        GameObject nearestEnemy = null;
        //sets the current nearest enemy to null
        foreach (GameObject enemy in enemies)
        //checks each enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //sets a new float to the distance to the enemy
            if (distanceToEnemy < shortestDistance)
            //if this enemy is closer than the shortest recorded distance
            {
                shortestDistance = distanceToEnemy;
                //set the shortest distance to this distance
                nearestEnemy = enemy;
                //sets the nearest enemy to this enemy
            }
        }
        if (nearestEnemy != null && shortestDistance <= towerStats.rangeFinal)
        //if the enemy exists and is within range
        {
            target = nearestEnemy.transform;
            //sets the enemy to be the target
        }
        else
        {
            target = null;
            //clears the target
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        //checks if there is a target
        {
            return;
        }
        if (fireCountdown <= 0f)
        //if the turret is not on cooldown
        {
            Shoot();
            //calls the shoot function
            fireCountdown = 1f / fireRate;
            //sets the cooldown to a fraction of a second depending on fire rate (per second)
        }
        fireCountdown -= Time.deltaTime;
        //removes time since last check from the fire cooldown
    }

    private void OnDrawGizmosSelected()
    //Declares a method
    {
        Gizmos.DrawWireSphere(transform.position, towerStats.rangeFinal);
        //Draws a sphere with a radius matching the range of the tower
    }

    void Shoot()
    //Declares a method
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        //Creates new bullet with a reference
        BulletBehaviour bullet = bulletGameObject.GetComponent<BulletBehaviour>();
        //Gets the Bulletbehaviour script from the new bullet
        if (bullet != null)
        //if there is a bullet
        {
            bullet.enemyTarget(target);
            //Sets the bullet target to the enemy within range
        }
    }
}
