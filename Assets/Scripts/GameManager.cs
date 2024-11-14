using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player testPlayer = new Player("Rynborg", CharacterClass.Knight);
        Item testItem = new Item(ItemType.Sword, 350, "Demogorgon Sword", null, 800, true, 55, 5);

        ItemSpawner itemSpawner = this.GetComponent<ItemSpawner>();
        itemSpawner.SpawnItem(testItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
