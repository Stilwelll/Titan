using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoEnemy : MonoBehaviour
{
    public float enemyHealth = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WhenHealthDepleted();
    }

    void WhenHealthDepleted()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
