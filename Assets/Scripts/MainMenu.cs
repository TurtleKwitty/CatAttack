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
    [SerializeField] Button quitButton;
    private Button selectedButton;
    [SerializeField] private List<Button> buttons;
    private int index = 0;
    public bool canChange = true;

    private void Start()
    {
        selectedButton = playButton;
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
    }

    private void Update()
    {
        if(canChange == false && Input.GetAxisRaw("VerticalPlayer1") == 0)
        {
            canChange = true;
        }
        if (Input.GetAxisRaw("VerticalPlayer1") < -.8f && canChange == true)
        {
            if (index == buttons.Count - 1)
            {
                canChange = false;
                index = 0;
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
            else
            {
                canChange = false;
                index++;
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
        }
        else if (Input.GetAxisRaw("VerticalPlayer1") > .8f && canChange == true)
        {
            if (index == 0)
            {
                canChange = false;
                index = buttons.Count - 1;
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
            else
            {
                canChange = false;
                index--;
                selectedButton = buttons[index];
                EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
            }
        }
    }

    public void Play()
    {
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
