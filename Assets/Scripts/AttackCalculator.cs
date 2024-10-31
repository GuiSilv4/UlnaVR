using UnityEngine;

public class AttackCalculator : MonoBehaviour
{
    // Função para gerar um número aleatório entre min e max (inclusivo)
    public static float RandomInt(float min, float max)
    {
        float randomNum = Random.Range(min, max + 1); // +1 para incluir max
        Debug.Log("randomNum: " + randomNum);
        return randomNum;
    }

    // Função para calcular o dano de ataque
    public static int HitDamage(int level, float mainAttribute, float weaponDamage, float fightingSkill, float other = 0)
    {
        // Pesos dos atributos
        const float levelWeight = 0.5f;
        const float weaponDamageWeight = 3f;
        const float fightingSkillWeight = 0.66f;
        const float mainAttributeWeight = 0.25f;

        // Cálculo base do dano
        float baseDamage = 
            (level * levelWeight) +
            (weaponDamage * weaponDamageWeight) +
            (fightingSkill * fightingSkillWeight) +
            (mainAttribute * mainAttributeWeight);

        // Cálculo do bônus de dano baseado no atributo principal
        float attributeBonus = (mainAttribute * 0.015f) + ((mainAttribute / (mainAttribute + 20)) * 4);
        float fightingSkillBonus = Mathf.Pow(1.1f, fightingSkill) * 0.0066f;
        float levelBonus = Mathf.Log(level + 1) * 0.020f;

        // Fator aleatório entre 0.9 e 1.1
        float randomFactor = Random.Range(0.9f, 1.1f);

        // Dano final com aleatoriedade e bônus de atributo
        float finalDamage = Mathf.Ceil(
            (baseDamage 
            + (baseDamage * attributeBonus) 
            + (baseDamage * fightingSkillBonus) 
            + (baseDamage * levelBonus)) * randomFactor / weaponDamageWeight
        );

        return (int)finalDamage;
    }
}
