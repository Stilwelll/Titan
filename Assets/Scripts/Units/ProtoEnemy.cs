using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class ProtoEnemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public float enemyDetectionRange = 25;

    public GameObject unit;
    public GameObject projectile;
    public Image healthBarImage;
    public GameObject healthBarImageBackground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WhenHealthDepleted();
        FriendlyUnitDetected();
    }

    void FriendlyUnitDetected()
    {
        if (unit ?? null)
        {
            if (Vector3.Distance(transform.position, unit.transform.position) <= enemyDetectionRange)
            {
                healthBarImageBackground.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            enemyHealth -= 1;
            healthBarImage.rectTransform.sizeDelta = new Vector2(enemyHealth * 0.23f, healthBarImage.rectTransform.sizeDelta.y);
            Destroy(other.gameObject);
        }
    }
    void WhenHealthDepleted()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
