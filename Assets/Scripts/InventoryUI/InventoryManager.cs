using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Color enableColor;
    [SerializeField] private Color disableColor;

    private Dictionary<string, int> dictCores;
    private Dictionary<DataLoot, int> listLoot;

    private DataLoot dataLoot; // Now selected DataLoot

    private void Start()
    {
        listLoot = new Dictionary<DataLoot, int>();
        dictCores = new Dictionary<string, int>();
    }

    private void OnEnable()
    {
        UpdateLoot();
        UpdateCores();

        dataLoot = null;
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "";
        transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
    }

    private void UpdateLoot()
    {
        int index = 0;
        foreach (var loot in listLoot)
        {
            Transform trans = transform.GetChild(0).GetChild(index);
            trans.GetChild(0).GetComponent<Image>().sprite = loot.Key.sprite;
            trans.GetChild(1).GetComponent<Text>().text = loot.Key.Name;

            trans.GetChild(0).gameObject.SetActive(true);
            trans.GetChild(1).gameObject.SetActive(true);

            trans.GetComponent<InventoryItem>().SetDataLoot(loot.Key);

            index++;
            if (index == transform.GetChild(0).childCount)
                break;
        }

        while (index < transform.GetChild(0).childCount)
        {
            Transform trans = transform.GetChild(0).GetChild(index);

            trans.GetChild(0).gameObject.SetActive(false);
            trans.GetChild(1).gameObject.SetActive(false);

            index++;
        }
    }

    private void UpdateCores()
    {
        int index = 0;
        foreach (var core in dictCores)
        {
            Transform trans = transform.GetChild(1).GetChild(index);
            trans.GetComponent<Image>().color = enableColor;
            index++;
            if (index == transform.GetChild(1).childCount)
                break;
        }

        while (index < transform.GetChild(1).childCount)
        {
            Transform trans = transform.GetChild(1).GetChild(index);
            trans.GetComponent<Image>().color = disableColor;
            index++;
        }
    }

    public void UseItem()
    {
        dataLoot.interfaceItem.UseItem();
    }

    // Method used when we click on item
    public void SetInfo(Transform loot)
    {
        dataLoot = loot.GetComponent<InventoryItem>().GetDataLoot(); 

        Transform infoPanel = transform.GetChild(2);
        infoPanel.GetChild(1).GetComponent<Text>().text = dataLoot.Info;

        if (dataLoot.interfaceItem != null) // If dataLoot - it's not default resource, then we can use method UseItem
        {
            infoPanel.GetChild(2).gameObject.SetActive(true);
        } else
        {
            infoPanel.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void SetCores(Dictionary<string, int> dict)
    {
        dictCores = dict;
    }

    public void SetListLoot(Dictionary<DataLoot, int> list)
    {
        listLoot = list;
        UpdateLoot();
    }
}
