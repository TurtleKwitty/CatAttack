using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button howToPlayButton;
    [SerializeField] Button backButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button onePlayer;
    [SerializeField] Button twoPlayers;
    private Button selectedButton;
    [SerializeField] private List<Button> buttons;
    private int index = 0;
    public bool canChange = true;
    private bool chosingPlayers = true;
    public int numberPlayers = 0;

    private void Start()
    {
        index = 4;
        selectedButton = onePlayer;
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
    }

    private void Update()
    {
        if (chosingPlayers)
        {
            if (canChange == false && Input.GetAxisRaw("HorizontalPlayer1") == 0)
            {
                canChange = true;
            }

            if (Input.GetAxisRaw("HorizontalPlayer1") < -.8f && canChange == true)
            {
                canChange = false;
                if (index == buttons.Count - 2)
                {
                    index++;
                }
                else
                {
                    index--;
                }
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
            else if (Input.GetAxisRaw("HorizontalPlayer1") > .8f && canChange == true)
            {
                canChange = false;
                if (index == buttons.Count - 2)
                {
                    index++;
                }
                else
                {
                    index--;
                }
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
        }

        else
        {
            if (canChange == false && Input.GetAxisRaw("VerticalPlayer1") == 0)
            {
                canChange = true;
            }
            if (Input.GetAxisRaw("VerticalPlayer1") < -.8f && canChange == true)
            {
                canChange = false;
                if (index == buttons.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
            else if (Input.GetAxisRaw("VerticalPlayer1") > .8f && canChange == true)
            {
                canChange = false;
                if (index == 0)
                {
                    index = buttons.Count - 1;
                }
                else
                {
                    index--;
                }
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
        }
    }

    public void Oneplayer()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            if(i < 4)
            {
                buttons[i].gameObject.SetActive(true);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
        index = 0;
        selectedButton = buttons[index];
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
        PlayersNumber.NumberOfPlayers = 0;
    }

    public void Twoplayers()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < 4)
            {
                buttons[i].gameObject.SetActive(true);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
        index = 0;
        selectedButton = buttons[index];
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
        PlayersNumber.NumberOfPlayers = 1;
    }

    public void Play()
    {
        Debug.Log(PlayersNumber.NumberOfPlayers);
        SceneManager.LoadScene("AymericDev", LoadSceneMode.Single);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
