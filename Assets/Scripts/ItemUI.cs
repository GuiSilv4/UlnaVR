using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public TextMeshProUGUI ItemNameText;
    public TextMeshProUGUI ItemRarityAndTypeText;
    public TextMeshProUGUI ItemPowerText;
    public TextMeshProUGUI ItemSellValueText;
    public TextMeshProUGUI ItemDurabilityText;
    public TextMeshProUGUI ItemReqLevelText;
    public TextMeshProUGUI ItemValueText;
    public Transform affixesContainer;
    public GameObject affixPrefab;

    public void UpdateItemUI(ItemData item)
    {
        ItemNameText.text = item.itemName;
        ItemRarityAndTypeText.text = item.itemRarity.ToString() + " " + item.itemType.ToString();
        ItemPowerText.text = item.itemPower.ToString() + " Item Power";
        
        string damageOrArmorSuffix = true ? "Damage" : "Armor";
        ItemValueText.text = item.itemValue.ToString() + " " + damageOrArmorSuffix;
        ItemSellValueText.text = "Sell Value " + item.sellValue.ToString();
        ItemDurabilityText.text = "Durability "  + item.durability.ToString() + "/100";
        ItemReqLevelText.text = "Req. Level " + item.requiredLevel.ToString();


        //itemTypeText.text = item.ItemType.ToString();
        //damagePerSecondText.text = $"{item.CalculateDPS()} DPS";
        //damagePerHitText.text = $"{item.MinDamage} - {item.MaxDamage} Damage per Hit";
        //attackSpeedText.text = $"{item.AttackSpeed} Attacks per Second";
        //rarityText.text = item.Rarity.ToString();

        // Limpar e adicionar afixos
        //foreach (Transform child in affixesContainer)
        //{
        //    Destroy(child.gameObject);
        //}
        //foreach (var affix in item.ItemAffixes)
        //{
        //    var affixUI = Instantiate(affixPrefab, affixesContainer);
        //    affixUI.GetComponent<TextMeshProUGUI>().text = $"{affix.Name}: {affix.Description}";
       // }
    }
}
