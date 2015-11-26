using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusBehavior : MonoBehaviour {
	
	public GameObject buttonPlayer1;
	public GameObject buttonPlayer2;
    public GameObject buttonEnd1;
    public GameObject buttonEnd2;

	public bool isTaken;

    void Start()
    {
        Debug.Log(buttonPlayer1.name);
        Debug.Log(buttonPlayer2.name);
    }


	void OnTriggerEnter(Collider col)
	{
		if(col.name.Contains("Player"))
		{
            DisplayPickUp(col.name);
            BonusManager.instance.currentBonus = gameObject;
			BonusManager.instance.player = col.gameObject;
		}
		
	}


	void OnTriggerExit(Collider col)
	{
		if(col.name.Contains("Player"))
		{
            HidePickUp(col.name);
            BonusManager.instance.currentBonus = null;
			BonusManager.instance.player = null;
		}
	}


    void DisplayPickUp(string pPlayer)
    {
        if (pPlayer == "Player0")
        {
            buttonPlayer1.SetActive(true);
            buttonEnd1.SetActive(false);
        }
        else
        {
            buttonPlayer2.SetActive(true);
            buttonEnd2.SetActive(false);
        }
    }


    public void HidePickUp(string pPlayer)
    {
        if (pPlayer == "Player0")
        {
            buttonPlayer1.SetActive(false);
            buttonEnd1.SetActive(true);
        }
        else
        {
            buttonPlayer1.SetActive(false);
            buttonEnd2.SetActive(true);
        }
    }
























}
