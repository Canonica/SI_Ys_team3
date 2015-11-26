using UnityEngine;
using System.Collections;

public class LDManager : MonoBehaviour {

	public static LDManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}


	public GameObject level1;
	public GameObject level2;
	public int nbTurnsSinceLastChange;

	bool isLevel1;

	// Use this for initialization
	void Start () 
	{
		level1 = GameObject.Find ("Grid");
		level2 = GameObject.Find ("Grid2");
		isLevel1 = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (nbTurnsSinceLastChange == 3)
		{
			isLevel1 = !isLevel1;
			nbTurnsSinceLastChange = 0;
		}

		if (MenuManager.instance.startGame)
		{
			if (isLevel1) {
                level2.SetActive(false);
                level1.SetActive (true);
                MapManager.instance.Play();
            } else {
				level1.SetActive (false);
				level2.SetActive (true);
                MapManager.instance.Play();
            }
		}
	}
}
