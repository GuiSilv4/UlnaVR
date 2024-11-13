using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // Referência para o prefab do item

    // Método para spawnar o item
    public void SpawnItem(Item item)
    {
        Vector3 itemSpawnPosition = new Vector3(0,0,3);

        ItemObject itemObject = itemPrefab.GetComponentInChildren<ItemObject>();

        itemObject.SetItem(item);

        Debug.Log("SPAWNADO: " + itemObject.item.ItemName);

        Instantiate(itemPrefab, itemSpawnPosition, Quaternion.identity);
    }
}