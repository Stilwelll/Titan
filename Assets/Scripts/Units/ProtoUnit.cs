using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoUnit : MonoBehaviour
{
    public float unitHealth = 10.0f;
    public float detectionRange = 10.0f;
    public float unitSpeed = 1.0f;

    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDetection();
    }

    void EnemyDetection()
    {
        if (Vector2.Distance(transform.position, enemy.transform.position) <= detectionRange & Vector2.Distance(transform.position, enemy.transform.position) > 0.25f)
        {
            transform.Translate(enemy.transform.position.x, 0, enemy.transform.position.z);
        }
    }
}
