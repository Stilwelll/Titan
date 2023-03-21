using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndex : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!(selectedTable.ContainsKey(id)) & !(LayerMask.NameToLayer("Ground") == go.layer))
        {
            selectedTable.Add(id, go);
            go.AddComponent<UnitSelection>();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    public void deselect(int id)
    {
        Destroy(selectedTable[id].GetComponent<UnitSelection>());
        selectedTable.Remove(id);
    }

    public void deselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<UnitSelection>());
            }
        }
        selectedTable.Clear();
    }
}
