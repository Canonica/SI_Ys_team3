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
            //Debug.Log("Clic gauche");
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
