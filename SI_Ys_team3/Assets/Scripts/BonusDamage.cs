using UnityEngine;
using System.Collections;

public class BonusDamage : MonoBehaviour {

	bool isTouched;
	GameObject player;
	public GameObject playerCanvas0;
	public GameObject playerCanvas1;



	void OnTriggerEnter(Collider col)
	{
		if(col.name.Contains("Player"))
		{
			player = col.gameObject;
			if(player.name == "Player0")
			{
				playerCanvas0.SetActive(true);
			}
			else
			{
				playerCanvas1.SetActive(true);
			}
		}
		
	}


	void OnTriggerExit(Collider col)
	{
		if(col.name.Contains("Player"))
		{
			player = col.gameObject;
			if(player.name == "Player0")
			{
				playerCanvas0.SetActive(false);
			}
			else
			{
				playerCanvas1.SetActive(false);
			}
		}
	}


	public void IsTaken()
	{
		player.GetComponent<Creature>().damage += 2;
		PlayerManager.instance.playerList[TurnManager.instance.currentPlayer - 1].creature.currentMovementPoint = 0;
		Destroy (gameObject);
	}

}
