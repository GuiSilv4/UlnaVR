using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public ItemRarity itemRarity;
    public int itemPower;
    public int requiredLevel;
    public Sprite itemImage;
    public int sellValue;
    public int durability;
    public bool isTradable;
    public int itemValue; // Valor ofensivo ou defensivo do item
    public int upgrades;
    
    // Lista de afixos do item (caso necessário)
    //public List<ItemAffix> itemAffixes = new List<ItemAffix>();
}
