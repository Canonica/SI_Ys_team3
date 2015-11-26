using UnityEngine;
using System.Collections;
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

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        GameManager.instance.gamestate = GameManager.GameState.menu;
        canvasPlay.SetActive(false);
        map.SetActive(false);
        canvasPause.SetActive(false);
        canvasCredits.SetActive(false);
        canvasMain.SetActive(true);
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
        Toggle_QuickMenu(Vector3.zero);
    }

    public void Toggle_QuickMenu(Vector3 posPlayer)
    {
        canvasQuickMenu.transform.position = posPlayer;
        canvasQuickMenu.SetActive(!canvasQuickMenu.activeInHierarchy);
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

}
