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

    public void UpdateItemUI(Item item)
    {
        ItemNameText.text = item.ItemName;
        ItemRarityAndTypeText.text = item.Rarity.ToString() + " " + item.ItemType.ToString();
        ItemPowerText.text = item.ItemPower.ToString() + " Item Power";
        
        string damageOrArmorSuffix = item.IsWeapon ? "Damage" : "Armor";
        ItemValueText.text = item.ItemValue.ToString() + " " + damageOrArmorSuffix;
        ItemSellValueText.text = "Sell Value " + item.SellValue.ToString();
        ItemDurabilityText.text = "Durability "  + item.Durability.ToString() + "/100";
        ItemReqLevelText.text = "Req. Level " + item.RequiredLevel.ToString();


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

    public void UpdateBackgroundColor(Color color) {
        this.GetComponent<Image>().color = color;
    }
}
