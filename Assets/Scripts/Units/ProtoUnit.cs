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
    public GameObject unitFront;

    // accessing the enemy tracker table
    private UnitManager enemiesTableDict;
    private int enemyTableIndex;

    // Start is called before the first frame update
    void Start()
    {
        enemiesTableDict = GameObject.Find("Event System").GetComponent<UnitManager>();
        enemyTableIndex = enemiesTableDict.enemyUnitTable.Count - 1;

        if (enemy ?? null)
        {
            InvokeRepeating("ShootProjectile", 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy ?? null)
        {
            EnemyDetection();
        }
    }

    void EnemyDetection()
    {

        // broken v0.0.8
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1 & Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
        {
            GameObject closetEnemy = GetClosestObject();

            while (closetEnemy ?? null)
            {
                if (Vector3.Distance(transform.position, closetEnemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, closetEnemy.transform.position) > 2)
                {
                    enemyTargeted = true;
                    transform.LookAt(closetEnemy.transform);
                    transform.position = Vector3.MoveTowards(transform.position, closetEnemy.transform.position, unitSpeed * Time.deltaTime);
                }
                break;
            }

            // if (Vector3.Distance(transform.position, closetEnemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, closetEnemy.transform.position) > 2)
            // {
            //     enemyTargeted = true;
            //     transform.LookAt(closetEnemy.transform);
            //     transform.position = Vector3.MoveTowards(transform.position, closetEnemy.transform.position, unitSpeed * Time.deltaTime);
            // }

            // if (closetEnemy ?? null)
            // {
            //     closetEnemy = GetClosestObject();
            // }

        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 & Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemy.transform.position) > 2)
        {
            transform.LookAt(enemy.transform);
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, unitSpeed * Time.deltaTime);
        }
        // if the unit is within a certain distance then they will move towards the enemy until a set distance
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            enemyTargeted = false;
        }
    }

    void ShootProjectile()
    {
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
            if (dist <= closest)
            {
                closest = dist;
                closestObject = MyListOfObjects[i];
            }
        }
        return closestObject;
    }
}
