using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Item : ScriptableObject
{
    // Atributos principais
    public ItemType ItemType { get; set; }
    public List<CharacterClass> ClassRequirements { get; set; }
    public List<ItemAffix> ItemAffixes { get; set; } = new List<ItemAffix>();
    public ItemRarity Rarity { get; set; }
    public int RequiredLevel { get; set; }
    public int ItemPower { get; set; }
    public string ItemName { get; set; }
    public Sprite ItemImage { get; set; }

    public string Name;

    public bool IsWeapon {get; private set;}
    
    // Novos Atributos
    public int SellValue { get; set; }
    public int Durability { get; set; } = 100; // Durabilidade inicial padrão
    public bool Tradable { get; set; } = true;
    public int ItemValue { get; set; } // Pode representar dano de arma ou defesa de armadura
    public int Upgrades { get; set; } = 1; // Inicia com 1 upgrade
    
    // Construtor para criar um item
    public Item(ItemType itemType, int itemPower, string itemName, Sprite itemImage, int sellValue, bool tradable, int itemValue, int requiredLevel)
    {
        ItemType = itemType;
        ItemPower = itemPower;
        ItemName = itemName;
        Name = ItemName;
        ItemImage = itemImage;
        SellValue = sellValue;
        Tradable = tradable;
        ItemValue = itemValue;
        RequiredLevel = requiredLevel;
        ClassRequirements = new List<CharacterClass>();
        UpdateRarity(); // Atualiza a raridade com base na contagem de afixos

        Durability = 100; // Valor inicial padrão
        Upgrades = 1; // Valor inicial padrão
        UpdateIsWeapon();
    }

    public void UpdateIsWeapon() {
            if(this.ItemType == ItemType.Axe || this.ItemType == ItemType.Bow
            || this.ItemType == ItemType.Crossbow || this.ItemType == ItemType.Dagger
            || this.ItemType == ItemType.Focus || this.ItemType == ItemType.Glaive 
            || this.ItemType == ItemType.Mace || this.ItemType == ItemType.Polearm
            || this.ItemType == ItemType.Quarterstaff || this.ItemType == ItemType.Scythe
            || this.ItemType == ItemType.Staff || this.ItemType == ItemType.Sword
            || this.ItemType == ItemType.Totem || this.ItemType == ItemType.TwoHandedAxe
            ||this.ItemType == ItemType.TwoHandedMace || this.ItemType == ItemType.TwoHandedScythe
            || this.ItemType == ItemType.TwoHandedSword || this.ItemType == ItemType.Wand ) {
                IsWeapon = true;
            }
            else {
                IsWeapon = false;
            }
    }
    // Método para adicionar uma classe como requisito para o item
    public void AddClassRequirement(CharacterClass characterClass)
    {
        if (!ClassRequirements.Contains(characterClass))
            ClassRequirements.Add(characterClass);
    }

    // Método para adicionar afixos
    public void AddAffix(string name, string description, float value)
    {
        ItemAffix affix = new ItemAffix
        {
            Name = name,
            Description = description,
            Value = value
        };
        ItemAffixes.Add(affix);
        UpdateRarity(); // Atualiza a raridade com base na contagem de afixos

    }

    // Método para definir a raridade com base na contagem de afixos
    private void UpdateRarity()
    {
        Rarity = GetItemRarityByAffixes();
    }

    // Método para exibir informações do item
    public void DisplayItemInfo()
    {
        Debug.Log($"Name: {ItemName}, Type: {ItemType}, Rarity: {Rarity}, Power: {ItemPower}, Required Level: {RequiredLevel}, Sell Value: {SellValue}, Durability: {Durability}, Tradable: {Tradable}, Item Value: {ItemValue}, Upgrades: {Upgrades}");
        foreach (var affix in ItemAffixes)
        {
            Debug.Log($"Affix: {affix.Name}, Description: {affix.Description}, Value: {affix.Value}");
        }
    }

    public int GetAffixCount()
    {
        return ItemAffixes.Count;
    }

    public ItemRarity GetItemRarityByAffixes()
    {
        switch (GetAffixCount())
        {
            case 1:
                return ItemRarity.Common;
            case 2:
                return ItemRarity.Magic;
            case 3:
                return ItemRarity.Rare;
            case 4:
                return ItemRarity.Legendary;
            case 5:
                return ItemRarity.Mythic;
            default:
                return ItemRarity.Common;
        }
    }
}
