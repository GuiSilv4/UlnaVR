using UnityEngine;
using System.Collections.Generic;

public class ItemGenerator : MonoBehaviour
{
    // Método principal para gerar um item aleatório com base no nível do monstro
    public Item GenerateRandomItem(int monsterLevel)
    {
        // Determina o tipo do item aleatoriamente
        ItemType itemType = GetRandomItemType();
        
        // Gera um nome fictício para o item
        string itemName = GenerateRandomItemName(itemType);

        // Determina o poder do item, influenciado pelo nível do monstro
        int itemPower = CalculateItemPower(monsterLevel);

        // Determina a raridade do item com base em probabilidade e afixos
        ItemRarity itemRarity = DetermineItemRarity();

        // Instancia o novo item usando o construtor
        Item newItem = new Item(itemType, itemPower, itemName, null, 0, true, 0, 0); // Imagem nula como placeholder

        // Adiciona afixos aleatórios com base na raridade do item
        AddRandomAffixes(newItem, itemRarity);

        return newItem;
    }

    // Método para definir o tipo do item aleatoriamente
    private ItemType GetRandomItemType()
    {
        ItemType[] itemTypes = (ItemType[])System.Enum.GetValues(typeof(ItemType));
        return itemTypes[Random.Range(0, itemTypes.Length)];
    }

    // Método para gerar um nome fictício para o item (pode ser personalizado)
    private string GenerateRandomItemName(ItemType itemType)
    {
        // Lógica básica para o nome - pode ser substituída por algo mais detalhado
        return itemType.ToString() + " of Power";
    }

    // Método para calcular o poder do item com base no nível do monstro
    private int CalculateItemPower(int monsterLevel)
    {
        // Exemplo de cálculo: escalona o poder baseado no nível do monstro
        return monsterLevel * Random.Range(10, 20); // Ajuste o multiplicador conforme necessário
    }

    // Método para determinar a raridade do item com base na quantidade de afixos
    private ItemRarity DetermineItemRarity()
    {
        int chance = Random.Range(1, 101); // Chance de 1 a 100%
        
        if (chance <= 50) return ItemRarity.Common;
        if (chance <= 75) return ItemRarity.Magic;
        if (chance <= 90) return ItemRarity.Rare;
        if (chance <= 98) return ItemRarity.Legendary;
        
        return ItemRarity.Mythic; // Casos mais raros
    }

    // Método para adicionar afixos aleatórios ao item
    private void AddRandomAffixes(Item item, ItemRarity rarity)
    {
        int affixCount = GetAffixCountByRarity(rarity);
        
        for (int i = 0; i < affixCount; i++)
        {
            string affixName = "Affix" + (i + 1);
            string affixDescription = "Boosts something by " + Random.Range(5, 15);
            float affixValue = Random.Range(1f, 5f);

            item.AddAffix(affixName, affixDescription, affixValue);
        }
    }

    // Determina o número de afixos com base na raridade
    private int GetAffixCountByRarity(ItemRarity rarity)
    {
        switch (rarity)
        {
            case ItemRarity.Common: return 1;
            case ItemRarity.Magic: return 2;
            case ItemRarity.Rare: return 3;
            case ItemRarity.Legendary: return 4;
            case ItemRarity.Mythic: return 5;
            default: return 1;
        }
    }
}
