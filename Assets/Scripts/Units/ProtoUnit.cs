using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoUnit : MonoBehaviour
{
    public float unitHealth = 10.0f;
    public float detectionRange = 10.0f;
    public float unitSpeed = 1.0f;
    public float rotationSpeed = 5.0f;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyDetection();
    }

    void EnemyDetection()
    {
        // if the unit is within a certain distance then they will move towards the enemy until a set distance
        if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemy.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, unitSpeed * Time.deltaTime);
        }

        // the unit will rotate towards the enemy when detected
        if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, enemy.transform.rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
