using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

    public int maxHealth = 15;
    public int currentHealth;

    public int maxMovementPoint = 3;
    public int currentMovementPoint;
    
    public int damage = 3;
    public int defense = 1;

    public int autoRange = 1;

    public bool hasAttacked = false;

    public PlayerScript player;
    public CreatureAttack creatureAtt;
    public TextMesh textMove;

    public Vector3 orientation;

    public bool readyOrientation = false;

    public GameObject healthbar;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerScript>();
        creatureAtt = GetComponent<CreatureAttack>();
        textMove = GetComponentInChildren<TextMesh>();
        currentHealth = maxHealth;
        currentMovementPoint = maxMovementPoint;
	}
	
	void Update () {

        if(currentMovementPoint <= 0)
        {
            GetComponent<DragDrop>().canMove = false;
        }
        textMove.text = currentMovementPoint.ToString();
    }

    public void Hit(int damage, bool ranged)
    {
        if (ranged)
        {
            player.creaturePassif.ApplyAbility();
        }
        if (damage != 0)
        {
            currentHealth -= damage * 1 / defense;
            Debug.Log(currentHealth / maxHealth);
            Debug.Log(healthbar.GetComponent<Renderer>().material.GetFloat("_Health"));
            healthbar.GetComponent<Renderer>().material.SetFloat("_Health", (float)currentHealth / (float)maxHealth);
        }
        if (currentHealth <= 0)
        {
            MenuManager.instance.Menu_End(gameObject.name);
        }
        if (ranged)
        {
            player.creaturePassif.UnApplyAbility();
        }
    }

    public void ReadyOrientation()
    {
        readyOrientation = true;
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.forward, out hit, 1000.0f);
        MapManager.instance.ColorAdjCell(hit.transform.GetComponent<Cell>());
    }

    public void SetOrientation(Vector3 direction)
    {
        orientation = direction;
        transform.localScale = new Vector3(transform.localScale.x*Mathf.Sign(orientation.x), transform.localScale.y, transform.localScale.z);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, orientation);
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.forward, out hit, 1000.0f);
        MapManager.instance.UnColorAdjCell(hit.transform.GetComponent<Cell>());
        readyOrientation = false;
    }
}
