using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    public GameObject canvasPlay;
    public GameObject canvasMain;
    public GameObject canvasCredits;

    public GameObject canvasPause;
    public GameObject canvasPause2;
    
    public GameObject canvasQuickMenu;

    public GameObject map;
    public GameObject map2;

    public GameObject canvasQuickMenuP1;
    public GameObject canvasQuickMenuP2;

    public GameObject canvasEndGame;

    public GameObject winnerText;

    public bool startGame;
    public GameObject bonus1;
    public GameObject bonus2;

    void Awake()
    {
        instance = this;
    }



    // Use this for initialization
    void Start () {
        GameManager.instance.gamestate = GameManager.GameState.menu;
        canvasPlay.SetActive(false);
        map.SetActive(false);
        map2.SetActive(false);
        canvasPause.SetActive(false);
        canvasCredits.SetActive(false);
        //canvasMain.GetComponent<CanvasGroup>().alpha = 0.5f;
        Time.timeScale = 0;

        

    }

	// Update is called once per frame
	void Update () {
	
	}

    public void Menu_Play()
    {
        canvasPlay.SetActive(true);
        map.SetActive(true);
        canvasMain.SetActive(false);
        canvasPause.SetActive(false);
        bonus1.SetActive(true);
        bonus2.SetActive(true);
        startGame = true;

        Time.timeScale = 1;
    }

    public void Menu_Credits()
    {
        canvasCredits.SetActive(true);
        canvasMain.SetActive(false);
    }

    public void Menu_Quit()
    {
        Application.Quit();
    }

    public void Menu_Back()
    {
        Application.LoadLevel("map");
    }

    public void Toggle_QuickMenu()
    {
       
    }


    public void Menu_Back_Credits()
    {
        canvasCredits.SetActive(false);
        canvasMain.SetActive(true);
    }

    public void Menu_Pause()
    {
        canvasPause2.SetActive(true);
        Time.timeScale = 0;
    }

    public void Menu_Resume()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu_End(string player)
    {
        Time.timeScale = 0;

        canvasEndGame.SetActive(true);
        if (player == "Player0")
        {
            winnerText.GetComponent<Text>().text = "The Rhinoceros \n won !";
        }else if(player == "Player1")
        {
            winnerText.GetComponent<Text>().text = "The Snake \n won !";
        }
    }

}
