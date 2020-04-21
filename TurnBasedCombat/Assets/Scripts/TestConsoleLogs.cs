using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Creatures;
using Attacks;

public class TestConsoleLogs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Making test guys
        Creature testGuy = new Creature("Test", 5, 5, 5, 5, 5, 5);
        Creature testGuy2 = new Creature("Test2", 5, 5, 5, 5, 5, 5);
        Creature testGuy3 = new Creature("Test3", 5, 5, 5, 5, 5, 5);
        //Making test swords
        Longsword l = new Longsword(testGuy);
        Longsword l2 = new Longsword(testGuy2, "Dan's sword", false, 8, 0);
        Longsword l3 = new Longsword(testGuy3, n: "Longsword +2", b: 2);
        //Making test wands
        Wand w = new Wand(testGuy);
        Wand w2 = new Wand(testGuy2, n: "Hardened Wand", b: 3);
        //See if the swords work
        Debug.Log(l.Name + " " + l.Buff + " " + l.Owner.Name + " " + l.Equipped);
        Debug.Log(l2.Name + " " + l2.Buff + " " + l2.Owner.Name + " " + l2.Equipped);
        Debug.Log(l3.Name + " " + l3.Buff + " " + l3.Owner.Name + " " + l3.Equipped);
        //See if the wands work
        Debug.Log(w.Name + " " + w.Buff + " " + w.Owner.Name);
        Debug.Log(w2.Name + " " + w2.Buff + " " + w2.Owner.Name);
        //Checking if the wand's effect works
        w.Effect();
        Debug.Log(w.Owner.Mag);
        Debug.Log(w2.Owner.Mag);
        //Trying to make an attack
        testGuy.Skills.Add(new WeaponAttack(testGuy, t: testGuy2, w: l));
        //See if it's added
        Debug.Log(testGuy.Skills[0]);
        //Check target's health before
        Debug.Log("Target health: " + testGuy.Skills[0].Target.Hp);
        //Perform an attack
        testGuy.Skills[0].Effect();
        //Check target's health after
        Debug.Log("Target health: " + testGuy.Skills[0].Target.Hp);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
