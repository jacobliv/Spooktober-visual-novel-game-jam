using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAndRemoveHistory : MonoBehaviour {
    private Dictionary<string, GameObject> historyItems = new();
    public  GameObject                     historyItemPrefab;

    public void Add(string id, string nameValue, string text) {
        GameObject historyItem = Instantiate(historyItemPrefab, transform);
        historyItem.name = $"History: {id}";
        historyItem.GetComponent<InitializeHistoryItem>().Initialize(nameValue,text);
        historyItems[id] = historyItem;
    }

    public void Remove(string id) {
        if (!historyItems.ContainsKey(id)) {
            Debug.LogWarning($"Unable to find {id} in list of history items");
            return;
        }
        GameObject historyItem = historyItems[id];
        Destroy(historyItem);
    }
}

