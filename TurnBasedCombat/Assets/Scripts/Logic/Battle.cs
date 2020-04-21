using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Creatures;

/**
 * Represents the logic of the battle. Keeping track of turns and whatnot
 * */
public class Battle : MonoBehaviour {

    private enum GameStates { PlayerTurn, EnemyTurn, End };
    private const int PARTY_SIZE = 3;
    private const int ENEMY_SIZE = 5;
    private const int MAX_SKILLS = 5;
    private int characterTurn = 0;
    private GameStates current = GameStates.PlayerTurn;
    public GameObject[] partyObjects = new GameObject[PARTY_SIZE];
    public GameObject pointer;
    public Text[] texts = new Text[PARTY_SIZE];
    public Button[] skills = new Button[MAX_SKILLS];

    
    private Creature[] party = new Creature[PARTY_SIZE];
    private Creature[] enemies = new Creature[ENEMY_SIZE];

	// Use this for initialization
	void Start () {
        int counter = 0;
        foreach(GameObject o in partyObjects)
        {
            party[counter] = new Creature(("Guy" + counter), 30, 10, 2, 2, 5, 5);
            texts[counter].text = party[counter].Name;
            counter++;
        }
        for(int i = 0; i < Random.Range(1, ENEMY_SIZE+1); i++)
        {
            enemies[i] = new Creature(("BadGuy" + i), 10, 0, 2, 2, 2, 2);
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (current)
        {
            case GameStates.PlayerTurn:PlayerTurn(); break;
            case GameStates.EnemyTurn: EnemyTurn(); break;
            case GameStates.End: EndFight(); break;
        }
	}

    private void PlayerTurn()
    {
        if(characterTurn < party.Length)
        {
            GameObject c = partyObjects[characterTurn];
            bool pressed = Input.GetKeyDown(KeyCode.Return);
            pointer.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + 0.5f, c.transform.position.z);
            ShowSkills();
            if (pressed)
            {
                c = partyObjects[characterTurn];
                pointer.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + 0.5f, c.transform.position.z);
                characterTurn++;
            }
        }
        else
        {
            characterTurn = 0;
        }
    }

    private void EnemyTurn()
    {

    }

    private void EndFight()
    {

    }

    private void ShowSkills()
    {
        for(int i = 0; i < party[characterTurn].Skills.Count; i++)
        {
            skills[i].enabled = true;
        }
    }
}
