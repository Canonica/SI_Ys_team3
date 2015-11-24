using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {

    public GameObject button_play;

    private int startCount = 0;
	// Use this for initialization
	void Start () {
	
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
            button_play = Instantiate(button_play, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            button_play.transform.parent = GameObject.Find("Canvas").transform;
            button_play.transform.localScale =  new Vector3(1, 1, 1);            
        }
        Destroy(gameobject);
    }

    public void startGame()
    {
        
    }
}
