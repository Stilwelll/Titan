using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ProtoUnit : MonoBehaviour
{
    public float unitHealth = 10.0f;
    public float detectionRange = 25.0f;
    public float unitSpeed = 1.0f;
    public float rotationSpeed = 5.0f;
    public float projectileDelayTime = 1.0f;
    bool enemyTargeted = false;

    // references to other objects in the scene
    public GameObject enemy;
    public GameObject projectile;
    public GameObject gunMuzzle;

    // accessing the enemy tracker table
    private UnitManager enemiesTableDict;
    private int enemyTableIndex;

    // Start is called before the first frame update
    void Start()
    {
        // if their is an enemy present invoke the shooting method
        if (enemy ?? null)
        {
            InvokeRepeating("ShootProjectile", 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if their is an present, execute the associated method
        if (enemy ?? null)
        {
            EnemyDetection();
        }
    }

    void EnemyDetection()
    {
        // if their is more than 1 enemy, find the closest enemy and target him
        GameObject closetEnemy;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1 & Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
        {
            closetEnemy = GetClosestObject();

            while (closetEnemy ?? null)
            {
                // if the unit is within a certain distance then they will move towards the enemy until a set distance
                if (Vector3.Distance(transform.position, closetEnemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, closetEnemy.transform.position) > 2)
                {
                    enemyTargeted = true;
                    transform.LookAt(closetEnemy.transform);
                    transform.position = Vector3.MoveTowards(transform.position, closetEnemy.transform.position, unitSpeed * Time.deltaTime);
                }
                break;
            }
        }

        closetEnemy = GetClosestObject();

        // if there is only one enemy, target that enemy
        if (closetEnemy ?? null)
        {
            // if the unit is within a certain distance then they will move towards the enemy until a set distance
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 & Vector3.Distance(transform.position, closetEnemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, closetEnemy.transform.position) > 2)
            {
                transform.LookAt(closetEnemy.transform);
                transform.position = Vector3.MoveTowards(transform.position, closetEnemy.transform.position, unitSpeed * Time.deltaTime);
            }
        }
        // if there is no enemy, this unit is not targeting anything, this variable is used by the projectile function
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            enemyTargeted = false;
        }
    }

    void ShootProjectile()
    {
        // if an enemy is a target, start shooting
        if (enemyTargeted)
        {
            Instantiate(projectile, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
            projectile.transform.LookAt(enemy.transform);
        }
    }

    public GameObject GetClosestObject()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] MyListOfObjects = enemies;

        float closest = 25;
        GameObject closestObject = null;
        for (int i = 0; i < MyListOfObjects.Length; i++)  //list of gameObjects to search through
        {
            float dist = Vector3.Distance(MyListOfObjects[i].transform.position, transform.position);
            if (dist <= closest) // if the object is closer than the detection range
            {
                closest = dist; 
                closestObject = MyListOfObjects[i];
            }
        }
        return closestObject;
    }
}
