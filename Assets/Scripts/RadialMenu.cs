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
    private PlayerResources playerResourcesScript;
    private Vector3 positionToBuild;
    private Vector3 offset;
    public GridBrushBase selectedElement;
    void Start()
    {
        playerResourcesScript = GetComponent<PlayerResources>();
        selectedElement = null;
        cam = Camera.main;
    }

    // fonction appelée quand le joueur presse sur A
    public void Build(int PlayerID)
    {
        positionToBuild = GameManager.Instance.Players[PlayerID].transform.GetChild(0).position;

        var Diff = positionToBuild - transform.position;
        if (Diff.x > 0.5) Diff.x = 1;
        else if (Diff.x < -0.5) Diff.x = -1;
        else Diff.x = 0;
        if (Diff.y > 0.5) Diff.y = 1;
        else if (Diff.y < -0.5) Diff.y = -1;
        else Diff.y = 0;

        Vector3Int pos = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
        if (selectedElement != null)
        {
            if (selectedElement == BuildBrush[0] && playerResourcesScript.GetWood() >= 4)
            {
                MapManager.Instance.Build(selectedElement, (int)(pos.x + Diff.x), (int)(pos.y + Diff.y));
                playerResourcesScript.RemoveResource(4, "tree");
            }
            else if (selectedElement == BuildBrush[1] && playerResourcesScript.GetWood() >= 2 && playerResourcesScript.GetStone() >= 4)
            {
                MapManager.Instance.Build(selectedElement, (int)(pos.x + Diff.x), (int)(pos.y + Diff.y));
                playerResourcesScript.RemoveResource(2, "tree");
                playerResourcesScript.RemoveResource(4, "rock");
            }
            else if (selectedElement == BuildBrush[2] && playerResourcesScript.GetWood() >= 2 && playerResourcesScript.GetStone() >= 3 && playerResourcesScript.GetIron() >= 6)
            {
                MapManager.Instance.Build(selectedElement, (int)(pos.x + Diff.x), (int)(pos.y + Diff.y));
                playerResourcesScript.RemoveResource(2, "tree");
                playerResourcesScript.RemoveResource(3, "rock");
                playerResourcesScript.RemoveResource(6, "ore");
            }
            else
            {
                Debug.Log("not enough resources");
            }
        }
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
