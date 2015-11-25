using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static InputManager instance = null;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
	    
        


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                PlayerScript pl = PlayerManager.instance.playerList[TurnManager.instance.currentPlayer - 1];
                GameObject other = hit.transform.gameObject;

                if (other.CompareTag("Creature") && other.name != pl.gameObject.name)
                {
                    pl.creatureAtt.OnAttack(other.GetComponent<Creature>());
                }

            }
        }

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Z");
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Q");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("E");
        }
    }
}
