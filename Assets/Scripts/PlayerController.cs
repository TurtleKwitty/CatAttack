using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RMF_RadialMenu mainRadialScript;
    private bool isBuilding = false;
    private RadialMenu radialMenuScript;
    private Vector2 movement;
    private Vector2 JoystickAim;
    private GameObject player;

    private void OnEnable()
    {
        GameManager.Instance.RegisterPlayer(gameObject);
    }

    private void Start()
    {
        player = gameObject;
        radialMenuScript = GetComponent<RadialMenu>();
    }

    public bool GetIsBuilding()
    {
        return isBuilding;
    }
    // Update is called once per frame
    void Update()
    {
        if (player.name == "Player1(Clone)")
        {
            movement.x = Input.GetAxisRaw("HorizontalPlayer1");
            movement.y = Input.GetAxisRaw("VerticalPlayer1");

            if (Input.GetButtonDown("MenuRadialPlayer1"))
            {
                radialMenuScript.DisplayRadialMenu();
                isBuilding = true;
            }
            else if (Input.GetButtonUp("MenuRadialPlayer1"))
            {
                radialMenuScript.HideRadialMenu();
                isBuilding = false;
            }
            else if (Input.GetButtonDown("BuildPlayer1") && isBuilding == false)
            {
                radialMenuScript.Build(0);
            }
            else if (!Input.GetButton("LookBackPlayer1") && (movement.x != 0f || movement.y != 0f))
            {
                JoystickAim = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
            }
            else if (Input.GetButton("LookBackPlayer1") && (movement.x != 0f || movement.y != 0f))
            {
                JoystickAim = new Vector2(transform.position.x - movement.x, transform.position.y - movement.y);
            }
            else
            {
                JoystickAim = Vector2.zero;
            }
        }

        if(player.name == "Player2(Clone)")
        {
            movement.x = Input.GetAxisRaw("HorizontalPlayer2");
            movement.y = Input.GetAxisRaw("VerticalPlayer2");

            if (Input.GetButtonDown("MenuRadialPlayer2"))
            {
                radialMenuScript.DisplayRadialMenu();
                isBuilding = true;
            }
            else if (Input.GetButtonUp("MenuRadialPlayer2"))
            {
                radialMenuScript.HideRadialMenu();
                isBuilding = false;
            }
            else if (Input.GetButtonDown("BuildPlayer2") && isBuilding == false)
            {
                radialMenuScript.Build(1);
            }
            else if (!Input.GetButton("LookBackPlayer2") && (movement.x != 0f || movement.y != 0f))
            {
                JoystickAim = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
            }
            else if (Input.GetButton("LookBackPlayer2") && (movement.x != 0f || movement.y != 0f))
            {
                JoystickAim = new Vector2(transform.position.x - movement.x, transform.position.y - movement.y);
            }
            else
            {
                JoystickAim = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isBuilding == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (JoystickAim != Vector2.zero && isBuilding == false)
        {
            rb.freezeRotation = false;
            Vector2 lookDir = JoystickAim - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, angle, 30f * Time.fixedDeltaTime));
        }
        else
        {
            rb.freezeRotation = true;
        }
    }
}
