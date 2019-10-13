using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    // liste des éléments à display dans le menu radial
    // pour le moment c'est le premier élément de cette liste qui est build quand le joueur presse sur A
    [SerializeField] private List<GameObject> elementsToDisplay;
    [SerializeField] private List<GridBrushBase> BuildBrush;
    [SerializeField] private Rigidbody2D rb;
    // valeur de l'offset pour la distance entre le joueur et la position de construction
    [SerializeField] private float offsetValue;
    [HideInInspector] public GameObject radialMenu;
    [HideInInspector] public RectTransform rectTransform;
    private Camera cam;

    private Vector3 positionToBuild;
    private Vector3 offset;
    public GridBrushBase selectedElement;
    void Start()
    {
        selectedElement = null;
        cam = Camera.main;
        offset = new Vector3(0, offsetValue, 0);
    }

    // fonction appelée quand le joueur presse sur A
    public void Build()
    {
        positionToBuild = transform.position;
        if (selectedElement != null)
            MapManager.Instance.Build(selectedElement, (int)positionToBuild.x, (int)positionToBuild.y);
        else
            Debug.Log("selected element = null");
    }

    public void DoSmth()
    {
        Debug.Log("do smth");
    }
    public void SelectElement(int idx_)
    {
        switch (idx_)
        {
            case 0:
                selectedElement = BuildBrush[idx_];
                break;
            case 1:
                selectedElement = BuildBrush[idx_];
                break;
            case 2:
                selectedElement = BuildBrush[idx_];
                break;
            case 3:
                Debug.Log("Select fourth element");
                break;
            default:
                break;
        }
    }

    // future fonction d'affichage du menu
    public void DisplayRadialMenu()
    {
        rectTransform.position = cam.WorldToScreenPoint(transform.position);
        radialMenu.SetActive(true);
    }

    public void HideRadialMenu()
    {
        radialMenu.SetActive(false);
    }
}
