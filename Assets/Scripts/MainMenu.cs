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

    private bool SceneIsReady = false;
    private bool ChangeScene = false;
    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("HowToPlay", LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;
        //Wait until the last operation fully loads to return anything
        while (asyncLoad.progress < 0.9f)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
        SceneIsReady = true;
        Debug.Log("Scene is ready!");
    }

    private void Start()
    {
        //StartCoroutine(LoadScene());
        SceneIsReady = true;

        index = 4;
        selectedButton = onePlayer;
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
    }

    private void Update()
    {
        if (ChangeScene && SceneIsReady) SceneManager.LoadScene("HowToPlay");
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
            if(i < 2)
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
            if (i < 2)
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

    public void Back()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < 2)
            {
                buttons[i].gameObject.SetActive(false);
            }
            else
            {
                buttons[i].gameObject.SetActive(true);
            }
        }
        PlayersNumber.NumberOfPlayers = 0;

        index = 3;
        selectedButton = buttons[index];
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
    }

    public void Play()
    {
        Debug.Log(PlayersNumber.NumberOfPlayers);
        ChangeScene = true;
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
