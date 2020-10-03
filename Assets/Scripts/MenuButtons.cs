//Main Menu
//Author: James Hopkins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button btnPlay;
    public Button btnExit;

    // Start is called before the first frame update
    void Start()
    {
        btnPlay = btnPlay.GetComponent<Button>();
        btnExit = btnExit.GetComponent<Button>();

        btnPlay.onClick.AddListener(PlayGame);
        btnExit.onClick.AddListener(Application.Quit);
    }

    void PlayGame()
    {
        Debug.Log("Played");
    }
}
