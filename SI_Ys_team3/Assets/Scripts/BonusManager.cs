using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {


	public static BonusManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}



	public GameObject player;
	public GameObject currentBonus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeBonus()
	{
		player.GetComponent<Creature>().currentMovementPoint = 0;
		BonusBehavior myBonusBehavior = currentBonus.GetComponent<BonusBehavior>();
		switch (currentBonus.name)
		{
			case "BonusDamages":
				IncreaseDamages();
			break;

			case "BonusHealth":
				IncreaseHealth();
			break;
		}
		myBonusBehavior.HidePickUp(player.name);
		myBonusBehavior.HideBonus ();
		myBonusBehavior.isTaken = true;

	}

	void IncreaseDamages()
	{
		player.GetComponent<Creature>().damage += 2;
	}

	void IncreaseHealth()
	{
		player.GetComponent<Creature> ().currentHealth += 2;

	}
}
