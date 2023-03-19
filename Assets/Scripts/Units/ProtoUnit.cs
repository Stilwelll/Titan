using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject enemyFront;
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
        if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemy.transform.position) > 2)
        {
            transform.LookAt(enemy.transform);
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, unitSpeed * Time.deltaTime);
        }
    }

    void ShootProjectile()
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
        {
            Instantiate(projectile, gunMuzzle.transform.position, gunMuzzle.transform.rotation);
            projectile.transform.LookAt(enemy.transform);
        }
    }
}
