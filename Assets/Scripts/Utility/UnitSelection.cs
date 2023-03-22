using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.SetActive(false);
    }
}
