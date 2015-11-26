using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusBehavior : MonoBehaviour {
	
	public GameObject buttonPlayer1;
	public GameObject buttonPlayer2;
    public GameObject buttonEnd1;
    public GameObject buttonEnd2;

	public bool isTaken;
	public int nbTurnsSinceTaken;

    void Start()
    {
		nbTurnsSinceTaken = 0;
		if (gameObject.name == "BonusDamages")
		{
			TurnManager.instance.bonus1 = this;
		} else
		{
			TurnManager.instance.bonus2 = this;
		}
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
            buttonPlayer2.SetActive(false);
            buttonEnd2.SetActive(true);
        }
    }

	public void HideBonus()
	{
		transform.GetComponent<Renderer> ().enabled = false;
		transform.GetComponent<Collider> ().enabled = false;
	}

	public void IncreaseTurn()
	{
		if (isTaken)
		{
			nbTurnsSinceTaken++;
		}
		if (nbTurnsSinceTaken == 5)
		{
			DisplayBonus();
			nbTurnsSinceTaken = 0;
		}
	}


	public void DisplayBonus()
	{
		RaycastHit hit;
		Ray ray;

		switch (gameObject.name) {
		
		case "BonusDamages" :
			transform.position = transform.parent.transform.parent.position;
			Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
			if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
			{
				Debug.Log(hit.transform.GetComponent<Cell>().isOccupied);
				gameObject.name = "BonusMovement";
				break;
			}
			else
			{
				transform.position = transform.parent.transform.parent.transform.parent.position;
				Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
				if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
				{
					Debug.Log("Deuxième position");
					gameObject.name = "BonusMovement";
					break;
				}
				else
				{
					Debug.Log("Troisième position");
					transform.position = transform.parent.position;
					gameObject.name = "BonusMovement";
					break;
				}
			}
		

		case "BonusMovement":
			transform.position = transform.parent.position;
			Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
			if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
			{
				Debug.Log(hit.transform.GetComponent<Cell>().isOccupied);
				gameObject.name = "BonusDamages";
				break;
			}
			else
			{
				transform.position = transform.parent.transform.parent.transform.parent.position;
				Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
				if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
				{
					Debug.Log("Deuxième position");
					gameObject.name = "BonusDamages";
					break;
				}
				else
				{
					Debug.Log("Troisième position");
					transform.position = transform.parent.transform.parent.position;
					gameObject.name = "BonusDamages";
					break;
				}
			}



		case "BonusHealth":
			transform.position = transform.parent.transform.parent.position;
			Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
			if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
			{
				Debug.Log(hit.transform.GetComponent<Cell>().isOccupied);
				gameObject.name = "BonusDistance";
				break;
			}
			else
			{
				transform.position = transform.parent.transform.parent.transform.parent.position;
				Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
				if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
				{
					Debug.Log("Deuxième position");
					gameObject.name = "BonusDistance";
					break;
				}
				else
				{
					Debug.Log("Troisième position");
					transform.position = transform.parent.position;
					gameObject.name = "BonusDistance";
					break;
				}
			}


		case "BonusDistance":
			transform.position = transform.parent.position;
			Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
			if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
			{
				Debug.Log(hit.transform.GetComponent<Cell>().isOccupied);
				gameObject.name = "BonusHealth";
				break;
			}
			else
			{
				transform.position = transform.parent.transform.parent.transform.parent.position;
				Physics.Raycast (transform.position, Vector3.forward, out hit, 1000f);
				if(hit.transform.name.Contains("Cell") && hit.transform.GetComponent<Cell>().isOccupied == false)
				{
					Debug.Log("Deuxième position");
					gameObject.name = "BonusHealth";
					break;
				}
				else
				{
					Debug.Log("Troisième position");
					transform.position = transform.parent.transform.parent.position;
					gameObject.name = "BonusHealth";
					break;
				}
			}
		
		
		}




		transform.GetComponent<Renderer> ().enabled = true;
		transform.GetComponent<Collider> ().enabled = true;

		isTaken = false;
	}
























}
