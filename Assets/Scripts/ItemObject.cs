using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData; // Referência ao item com os dados
    public ItemUI itemUIPanel; // Referência ao painel UI do item

    void Start() {
        if(itemData != null) {
            itemUIPanel.UpdateItemUI(itemData);
        }
    }
    void OnMouseEnter()
    {
        // Exibe o ItemUI e atualiza com os dados do item
        itemUIPanel.gameObject.SetActive(true);
            
        // Posiciona o ItemUI próximo ao item na tela, se desejar
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        itemUIPanel.transform.position = screenPosition + new Vector3(85, 70, 0); // Ajuste conforme necessário
    }

    void OnMouseExit()
    {
        // Esconde o ItemUI quando o mouse sai do objeto
        itemUIPanel.gameObject.SetActive(false);
    }
}
