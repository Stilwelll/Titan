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

    public GameObject enemy;
    public GameObject projectile;
    public GameObject gunMuzzle;
    public GameObject unitFront;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootProjectile", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDetection();
    }

    void EnemyDetection()
    {
        // if the unit is within a certain distance then they will move towards the enemy until a set distance
        if (enemy ?? null)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1)
            {
                GameObject enemyTarget = GameObject.FindWithTag("Enemy");

                if (Vector3.Distance(transform.position, enemyTarget.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemyTarget.transform.position) > 2)
                {
                    transform.LookAt(enemyTarget.transform);
                    transform.position = Vector3.MoveTowards(transform.position, enemyTarget.transform.position, unitSpeed * Time.deltaTime);
                }
                else if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemy.transform.position) > 2)
                {
                    transform.LookAt(enemy.transform);
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, unitSpeed * Time.deltaTime);
                }
            }
        }
    }

    void ShootProjectile()
    {
        if (enemy ?? null)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1)
            {
                GameObject enemyTarget = GameObject.FindWithTag("Enemy");

                if (Vector3.Distance(transform.position, enemyTarget.transform.position) <= detectionRange)
                {
                    Instantiate(projectile, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
                    projectile.transform.LookAt(enemyTarget.transform);
                }
                else if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
                {
                    Instantiate(projectile, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
                    projectile.transform.LookAt(enemy.transform);
                }
            }
        }
    }
}
