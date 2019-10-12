using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    // liste des éléments à display dans le menu radial
    // pour le moment c'est le premier élément de cette liste qui est build quand le joueur presse sur A
    [SerializeField] private List<GameObject> elementsToDisplay;
    [SerializeField] private Rigidbody2D rb;
    // valeur de l'offset pour la distance entre le joueur et la position de construction
    [SerializeField] private float offsetValue;
    [SerializeField] GameObject radialMenu;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Camera cam;

    private Vector3 positionToBuild;
    private Vector3 offset;
    private GameObject selectedElement;
    void Start()
    {
        offset = new Vector3(0, offsetValue, 0);
    }

    // fonction appelée quand le joueur presse sur A
    public void Build()
    {
        positionToBuild = transform.position + transform.TransformDirection(offset);

        if(selectedElement != null)
        Instantiate(selectedElement, positionToBuild, Quaternion.Euler(0, 0, rb.rotation));
    }

    public void SelectElement(int index)
    {
        switch (index)
        {
            case 0:
                selectedElement = elementsToDisplay[0];
                break;
            case 1:
                selectedElement = elementsToDisplay[1];
                break;
            case 2:
                Debug.Log("Select third element");
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
