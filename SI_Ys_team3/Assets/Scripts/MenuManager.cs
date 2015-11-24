using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        GameManager.instance.gamestate = GameManager.GameState.menu;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Menu_Play()
    {
        Application.LoadLevel("map");
    }

    public void Menu_Credits()
    {
        Application.LoadLevel("credits");
    }

    public void Menu_Quit()
    {
        Application.Quit();
    }

    public void Menu_Back()
    {
        Application.LoadLevel("main_menu");
    }

    public void Menu_Pause()
    {
        Debug.Log("Pause");
        GameManager.instance.gamestate = GameManager.GameState.pause;
    }
}
