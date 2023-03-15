using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoProjectile : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    public float projectileDestructionDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileMovement();
        DestroyAfterSetTime();
    }

    void ProjectileMovement()
    {
        transform.Translate(0, 0, projectileSpeed);
    }

    void DestroyAfterSetTime()
    {
        Destroy(gameObject, projectileDestructionDelay);
    }


}

