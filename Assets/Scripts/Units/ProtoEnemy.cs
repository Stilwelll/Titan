using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class ProtoEnemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public float enemyDetectionRange = 25;

    // Handles friendly units and their projectiles
    public GameObject unit;
    public GameObject projectile;

    // Handles Unit Graphics
    public Image healthBarImage;
    public GameObject healthBarImageBackground;

    // Uses the Enemy Unit Table to keep track of number of enemy units
    private UnitManager eventSystemDict;

    // Start is called before the first frame update
    void Awake()
    {
        // adding the enemy unit to the dictonary count
        eventSystemDict = GameObject.Find("Event System").GetComponent<UnitManager>();

        eventSystemDict.enemyUnitTable.Add(gameObject.GetInstanceID(), gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (unit ?? null)
        {
            WhenHealthDepleted();
            FriendlyUnitDetected();
        }
    }

    void FriendlyUnitDetected()
    {
        // if a friendly unit is detected, its healthbar is displayed
        if (Vector3.Distance(transform.position, unit.transform.position) <= enemyDetectionRange)
        {
            healthBarImageBackground.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // when hit by a projectile, this units health is decreased
        if (other.gameObject.CompareTag("Projectile"))
        {
            enemyHealth -= 1;
            healthBarImage.rectTransform.sizeDelta = new Vector2(enemyHealth * 0.23f, healthBarImage.rectTransform.sizeDelta.y);
            Destroy(other.gameObject);
        }
    }

    void WhenHealthDepleted()
    {
        // when the units health reaches zero, the unit is destroyed
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        // removes this enemy from the dictionary when destroyed
       eventSystemDict.enemyUnitTable.Remove(gameObject.GetInstanceID());
    }
}
