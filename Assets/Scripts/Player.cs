using UnityEngine;

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
}
