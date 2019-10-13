using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    private CircleCollider2D cc;
    private bool player1CanGather = false;
    private bool player2CanGather = false;
    private bool isEmpty = false;
    private GameObject player1;
    private GameObject player2;
    private IEnumerator coroutine;
    private SpriteRenderer spriteRend;
    private BoxCollider2D bc;
    private PlayerResources player1ResourcesScript;
    private PlayerResources player2ResourcesScript;
    [SerializeField] private float offset;
    [SerializeField] private float timeForGather;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private string id;
    [SerializeField] private int resourceAmount;
    [SerializeField] private int MaxResourceAmount;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    IEnumerator GatheringTime(int index)
    {
        if(index == 0)
        {
            player1CanGather = false;
            yield return new WaitForSeconds(timeForGather);
            player1CanGather = true;
        }
        else if(index == 1)
        {
            player2CanGather = false;
            yield return new WaitForSeconds(timeForGather);
            player2CanGather = true;
        }
    }

    private void ChangeSprite()
    {
        if(resourceAmount == MaxResourceAmount / 2 - MaxResourceAmount % 2)
        {
            spriteRend.sprite = sprites[1];
        }
        else if(resourceAmount == 0 && !isEmpty)
        {
            isEmpty = true;
            spriteRend.sprite = sprites[2];
            bc.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
            if(id == "tree")
            {
                spriteRend.color = new Color(.6f, .6f, .6f, 1f);
            }
        }
    }
    private void Update()
    {
        if(player1 != null && player1CanGather == true && Input.GetButtonDown("GatherPlayer1"))
        {
            if (resourceAmount == 0)
            {
                player1CanGather = false;
                return;
            }

            resourceAmount--;
            player1ResourcesScript.AddResource(1, id);

            StartCoroutine(GatheringTime(0));
        }
        else if (player2 != null && player2CanGather == true && Input.GetButtonDown("GatherPlayer2"))
        {
            if (resourceAmount == 0)
            {
                player2CanGather = false;
                return;
            }

            resourceAmount--;
            player2ResourcesScript.AddResource(1, id);

            StartCoroutine(GatheringTime(1));
        }

        if (resourceAmount == MaxResourceAmount / 2 - MaxResourceAmount % 2 || resourceAmount == 0)
        {
            ChangeSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.name == "Player1(Clone)" && resourceAmount > 0)
            {
                player1CanGather = true;

                if (player1 == null)
                {
                    player1 = collision.gameObject;
                    player1ResourcesScript = player1.GetComponent<PlayerResources>();
                }
            }
            else if(collision.gameObject.name == "Player2(Clone)" && resourceAmount > 0)
            {
                player2CanGather = true;

                if (player2 == null)
                {
                    player2 = collision.gameObject;
                    player2ResourcesScript = player2.GetComponent<PlayerResources>();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.name == "Player1(Clone)")
            {
                player1CanGather = false;
            }
            else
            {
                player2CanGather = false;
            }
        }
    }
}
