using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Atributos básicos
    public string Name { get; set; }
    public int Level { get; set; }
    public float HitPoints { get; set; }
    public float Resource { get; set; }
    public float Capacity { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public CharacterClass PlayerClass { get; set; } // Novo atributo

    // Atributos calculados (Hidden Attributes)
    public float WeaponDamage { get; set; }
    public float SkillFighting { get; set; } 
    public float OtherBonus { get; set; }
    public Inventory Inventory { get; private set; }
    public float MaxCarryWeight { get; set; } = 100f;  // Capacidade máxima de carga em peso
    public float CurrentCarryWeight { get; private set; } = 0f;  // Peso atual carregado
    public Dictionary<EquipmentSlot, Item> EquippedItems { get; private set; } = new Dictionary<EquipmentSlot, Item>();

    public float HitDamage
    {
        get
        {
            return Level + Strength + WeaponDamage + SkillFighting + OtherBonus;
        }
    }

    public float CriticalHitDamage { get; set; }

    // Resistências
    public float FireResistance { get; set; }
    public float LightningResistance { get; set; }
    public float ColdResistance { get; set; }
    public float PoisonResistance { get; set; }
    public float ShadowResistance { get; set; }
    public float PhysicalResistance { get; set; }

    // Atributos de combate
    public float WeaponSpeed { get; set; }
    public float AttackSpeedBonus { get; set; }
    public float CriticalStrikeChance { get; set; }
    public float CriticalStrikeDamage { get; set; }
    public float MovementSpeed { get; set; }
    public float DamageReduction { get; set; }

    // Habilidades de combate
    public int ClubFighting { get; set; }
    public int SwordFighting { get; set; }
    public int AxeFighting { get; set; }
    public int MagicLevel { get; set; }
    public int DistanceFighting { get; set; }
    public int Shielding { get; set; }
    public int DualWielding { get; set; }

    // Construtor para inicializar o Player com uma classe
    public Player(string name, CharacterClass playerClass)
    {
        Name = name;
        PlayerClass = playerClass;
        Inventory = new Inventory();

        Level = 1;
        HitPoints = 100;
        Resource = 100;
        Capacity = 10;
        Strength = 10;
        Dexterity = 10;
        Constitution = 10;
        Intelligence = 10;
    }

    // Métodos e outras funcionalidades podem ser adicionados aqui
    public bool AddItem(Item item)
    {
        if (CurrentCarryWeight + item.Weight > MaxCarryWeight)
        {
            Debug.Log("Você está carregando muito peso!");
            return false;
        }

        Inventory.AddItem(item);
        CurrentCarryWeight += item.Weight;
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (Inventory.RemoveItem(item))
        {
            CurrentCarryWeight -= item.Weight;
        }
    }

    // Método para equipar um item
    public bool EquipItem(Item item)
    {
        // Validação do tipo de item e slot
        EquipmentSlot slot = item.GetEquipmentSlot(); // Presumindo que Item tem um método para definir o slot adequado.
        if (EquippedItems.ContainsKey(slot))
        {
            Debug.Log("Slot já ocupado.");
            return false;
        }

        EquippedItems[slot] = item;
        ApplyItemAttributes(item);
        return true;
    }
    
     // Método para aplicar os atributos do item ao jogador
    private void ApplyItemAttributes(Item item)
    {
        //Strength += item.StrengthBonus; // Exemplo
        //Dexterity += item.DexterityBonus; // Outros atributos podem ser adicionados
    }

    // Método para desequipar um item
    public void UnequipItem(EquipmentSlot slot)
    {
        if (EquippedItems.TryGetValue(slot, out Item item))
        {
            RemoveItemAttributes(item);
            EquippedItems.Remove(slot);
        }
    }

    private void RemoveItemAttributes(Item item)
    {
        //Strength -= item.StrengthBonus;
        //Dexterity -= item.DexterityBonus;
    }

}


