using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.childCount);
        if (gameObject.transform.childCount > 2)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (gameObject.transform.childCount > 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (gameObject.transform.childCount > 2)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (gameObject.transform.childCount > 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

    }
}
