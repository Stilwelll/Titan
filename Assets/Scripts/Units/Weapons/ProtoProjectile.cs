using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoProjectile : MonoBehaviour
{
    public float projectileSpeed = 0.025f;
    public float projectileDestructionDelay = 1.0f;
    public float spawnTime = 1.0f;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterSetTime();
        ProjectileMovement();
    }

    public void ProjectileMovement()
    {
        transform.Translate(0, 0, projectileSpeed);
    }

    void DestroyAfterSetTime()
    {
        Destroy(gameObject, 3);
    }

    IEnumerator DestructionTimer(float projectileDestructionDelay)
    {
        yield return new WaitForSeconds(projectileDestructionDelay);
    }


}

