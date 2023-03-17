using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoUnit : MonoBehaviour
{
    public float unitHealth = 10.0f;
    public float detectionRange = 10.0f;
    public float unitSpeed = 0.5f;

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
        if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector3.Distance(transform.position, enemy.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, unitSpeed * Time.deltaTime);
            transform.rotation = Quaternion.FromToRotation(transform.position, new Vector3(0, 0, enemy.transform.position.y));
        }
    }
}
