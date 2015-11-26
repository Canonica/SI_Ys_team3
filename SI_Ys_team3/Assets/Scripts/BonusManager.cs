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
		switch (currentBonus.name)
		{
			case "BonusDamages":
				IncreaseDamages();
			break;

			case "BonusHealth":
				IncreaseHealth();
			break;
		}
        currentBonus.GetComponent<BonusBehavior>().HidePickUp(player.name);
        Destroy(currentBonus);

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
