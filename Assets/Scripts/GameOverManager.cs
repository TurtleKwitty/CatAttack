using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] Buttons;

    int index = 0;

    bool canChange = false;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(Buttons[index].gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange == false && Input.GetAxisRaw("HorizontalPlayer1") == 0)
        {
            canChange = true;
        }

        if (Input.GetAxisRaw("HorizontalPlayer1") < -.8f && canChange == true)
        {
            canChange = false;
            index++;
            index %= Buttons.Length;
            EventSystem.current.SetSelectedGameObject(Buttons[index].gameObject);
        }
        else if (Input.GetAxisRaw("HorizontalPlayer1") > .8f && canChange == true)
        {
            canChange = false;
            index--;
            if (index < 0) index = Buttons.Length - 1;
            EventSystem.current.SetSelectedGameObject(Buttons[index].gameObject);
        }
    }

    public void Menu()
    {
        GameManager.Instance.Kill();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
