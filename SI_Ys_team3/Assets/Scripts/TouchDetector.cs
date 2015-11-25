using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {

    public GameObject button_play;

    public GameObject button_player2;
    public GameObject button_pause_main;
    public GameObject button_pause_resume;
    public GameObject button_pause_restart;
    public GameObject button_pause_quit;


    private int startCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	

    void Update()
    {
       
    }

    public void DestroyButton(GameObject gameobject)
    {
        if (gameobject.name == "Button_Player1")
        {
            startCount += 1;
        }
        else if(gameobject.name == "Button_Player2")
        {
            startCount += 1;
        }

        if(startCount == 2)
        {
            button_play.SetActive(true);
        }
        Destroy(gameobject);
    }

    public void startGame()
    {
        GameManager.instance.gamestate = GameManager.GameState.playing;
    }

    public void ActivateButton2()
    {
        button_player2.SetActive(true);
    }

    
}
