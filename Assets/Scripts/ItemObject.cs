using Mono.Cecil.Cil;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item; // Referência ao item com os dados
    public ItemUI itemUIPanel; // Referência ao painel UI do item

    private Material itemMaterial; // Material do item

    private Outline outline;

    void Start() {
        if(item != null) {
            itemUIPanel.UpdateItemUI(item);
        }
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineHidden;
        itemMaterial = GetComponent<Renderer>().material;
        SetUIBackgroundColorByRarity(item.Rarity);
    }

    public void SetItem(Item itemData) {
        this.item = itemData;
    }

    public Color createFloatColorByInt(int red, int green, int blue, int alpha) {
                // Convertendo os valores inteiros para float
        float r = red / 255.0f;
        float g = green / 255.0f;
        float b = blue / 255.0f;
        float a = alpha / 255.0f;

        return new Color(r, g, b, a);
    }
    public void SetUIBackgroundColorByRarity (ItemRarity itemRarity) {
        Color backgroundColor;
        switch (itemRarity)
        {
            case(ItemRarity.Common) :
                backgroundColor = createFloatColorByInt(114, 114, 114, 186);
                break;
            case(ItemRarity.Magic) : 
                backgroundColor = createFloatColorByInt(51, 63, 173, 186);
                break;
            case(ItemRarity.Rare) : 
                backgroundColor = createFloatColorByInt(152, 148, 0, 186);
                break;
            case(ItemRarity.Legendary) : 
                backgroundColor = createFloatColorByInt(191, 105, 0, 186);
                break;
            case(ItemRarity.Mythic) : 
                backgroundColor = createFloatColorByInt(162, 0, 190, 186);
                break;
            default:
                backgroundColor = createFloatColorByInt(162, 0, 192, 186);
                break;
        }

        itemUIPanel.UpdateBackgroundColor(backgroundColor);
    }

    void OnMouseEnter()
    {
        // Exibe o ItemUI e atualiza com os dados do item
        itemUIPanel.gameObject.SetActive(true);

        // Ativa a emissão do material
        itemMaterial.EnableKeyword("_EMISSION");
        outline.OutlineMode = Outline.Mode.OutlineAll;

            
        // Posiciona o ItemUI próximo ao item na tela, se desejar
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        itemUIPanel.transform.position = screenPosition + new Vector3(125, 100, 0); // Ajuste conforme necessário
    }

    void OnMouseExit()
    {
        // Esconde o ItemUI quando o mouse sai do objeto
        itemUIPanel.gameObject.SetActive(false);
        outline.OutlineMode = Outline.Mode.OutlineHidden;

        itemMaterial.DisableKeyword("_EMISSION");
    }
}
