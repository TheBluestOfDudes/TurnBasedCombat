using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Creatures;
using Skills;
using Weapons;
using Attacks;

/**
 * Represents the logic of the battle. Keeping track of turns and whatnot
 * */
public class Battle : MonoBehaviour {

    private enum GameStates { PlayerTurn, EnemyTurn, End };
    private enum PlayerState { SelectAction, SelectingItem, SelectingSkill, SelectingAttack, Attacking, UsingSkill, UsingItem, SelectingTarget, Done};
    private const int PARTY_SIZE = 3;
    private const int ENEMY_SIZE = 5;
    private const int MAX_SKILLS = 5;
    private int characterTurn = 0;
    private GameStates current = GameStates.PlayerTurn;
    private PlayerState playerAction = PlayerState.SelectAction;
    private bool advanceTurn = false;
    private Creature[] party = new Creature[PARTY_SIZE];
    private Creature[] enemies = new Creature[ENEMY_SIZE];
    public GameObject[] partyObjects = new GameObject[PARTY_SIZE];
    public GameObject[] enemyObjects = new GameObject[ENEMY_SIZE];
    public GameObject pointer;
    public Text[] partyNames = new Text[PARTY_SIZE];
    public Text[] enemyNames = new Text[ENEMY_SIZE];
    public Text[] enemyHealth = new Text[ENEMY_SIZE];
    public Button[] skills = new Button[MAX_SKILLS];
    public Text hp;
    public Text sp;
    public Button attackButton;
    public Button skillsButton;
    public Button itemsButton;

	// Use this for initialization
	void Start () {

        party[0] = new Creature("Robert", Random.Range(20, 31), Random.Range(5, 11), 2, 2, 5, 5);
        party[0].Inventory.Add(new Longsword(party[0], n: "Sharpie", e: true));
        party[0].Skills.Add(new WeaponAttack(party[0], n: "Mighty slash", w: party[0].GetEquippedWeapon()));
        party[1] = new Creature("Brobert", Random.Range(20, 31), Random.Range(5, 11), 2, 2, 5, 5);
        party[1].Inventory.Add(new Wand(party[1], n: "Magic Stick", e: true));
        party[1].Skills.Add(new WeaponAttack(party[1], n: "Stick thwack", w: party[1].GetEquippedWeapon()));
        party[2] = new Creature("Shobert", Random.Range(20, 31), Random.Range(5, 11), 2, 2, 5, 5);
        party[2].Inventory.Add(new Unarmed(party[2], n: "Tough hands", e: true));
        party[2].Skills.Add(new WeaponAttack(party[2], n: "Punch", w: party[2].GetEquippedWeapon()));
        for(int i = 0; i < party.Length; i++)
        {
            partyNames[i].text = party[i].Name;
        }
        for (int i = 0; i < Random.Range(1, ENEMY_SIZE+1); i++)
        {
            enemies[i] = new Creature(("BadGuy" + i), 10, 0, 2, 2, 2, 2);
            enemyObjects[i].SetActive(true);
            enemyNames[i].text = enemies[i].Name;
            enemyNames[i].gameObject.SetActive(true);
            enemyHealth[i].gameObject.SetActive(true);
        }

        attackButton.onClick.AddListener(ShowAttacks);
        skillsButton.onClick.AddListener(ShowSkills);
        itemsButton.onClick.AddListener(ShowItems);

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
    //-----------Turn Handling------------------------
    private void PlayerTurn()
    {
        ShowEnemyHealth();
        switch (playerAction)
        {
            case PlayerState.SelectAction: break;
            case PlayerState.SelectingAttack: break;
            case PlayerState.SelectingItem: break;
            case PlayerState.SelectingSkill: break;
            case PlayerState.SelectingTarget: break;
            case PlayerState.Attacking: break;
        }

        if(characterTurn < party.Length)
        {
            GameObject c = partyObjects[characterTurn];
            bool pressed = Input.GetKeyDown(KeyCode.Return);
            pointer.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + 0.5f, c.transform.position.z);
            hp.text = "HP: " + party[characterTurn].Hp;
            sp.text = "SP: " + party[characterTurn].Sp;
            if (pressed)
            {
                characterTurn++;
                ShowAttacks();
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
    //--------------------PlayerTurn Handling----------------------
    private void SelectTarget(Attack a)
    {
        Creature target = null;
        playerAction = PlayerState.SelectingTarget;
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
            {
                skills[i].gameObject.SetActive(true);
                skills[i].GetComponentInChildren<Text>().text = enemies[i].Name;
                skills[i].onClick.RemoveAllListeners();
                target = enemies[i];
                skills[i].onClick.AddListener(() => { PerformAttack(target, a); });
            }
        }

    }
    private void PerformAttack(Creature target, Attack attack)
    {
        playerAction = PlayerState.Attacking;
        attack.Target = target;
        attack.Effect();
    }
    //--------------------UI Handling---------------------------
    private void ShowSkills()
    {
        playerAction = PlayerState.SelectingSkill;
        Debug.Log("You clicked skills");
    }

    private void ShowAttacks()
    {
        playerAction = PlayerState.SelectingAttack;
        List<Attack> attacks = party[characterTurn].GetAttacks();
        Attack a = null;
        HideControls();
        for(int i = 0; i < attacks.Count; i++)
        {

            skills[i].gameObject.SetActive(true);
            skills[i].GetComponentInChildren<Text>().text = attacks[i].Name;
            a = attacks[i];
            skills[i].onClick.AddListener(() => { SelectTarget(a); });
        }
        

    }

    private void ShowItems()
    {
        playerAction = PlayerState.SelectingItem;
        Debug.Log("You clicked items");
    }
    //-----------Hide/Show Methods---------------
    private void HideControls()
    {
        attackButton.gameObject.SetActive(false);
        itemsButton.gameObject.SetActive(false);
        skillsButton.gameObject.SetActive(false);
    }
    private void ShowEnemyHealth()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
            {
                enemyHealth[i].text = enemies[i].Hp.ToString();
            }
        }
    }
}
