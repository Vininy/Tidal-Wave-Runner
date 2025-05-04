using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform background;
    public Transform platforms;

    void Start()
    {
        // Certifique-se de que o fundo está atrás das plataformas
        background.position = new Vector3(background.position.x, background.position.y, -10f);
        platforms.position = new Vector3(platforms.position.x, platforms.position.y, 0f);

        // Ajusta manualmente as Sorting Layers
        SetSortingLayer(background.gameObject, "Background", 0);
        SetSortingLayer(platforms.gameObject, "Platforms", 5);
    }

    void SetSortingLayer(GameObject obj, string layerName, int order)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.sortingLayerName = layerName;
            renderer.sortingOrder = order;
        }
    }
}
