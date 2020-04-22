using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;
using Creatures;
using Weapons;
using Items;
namespace Attacks
{
    public class WeaponAttack : Attack
    {
        public Weapon Weapon { get; set; }
        public WeaponAttack(Creature o, int c = 0, string n = "Basic attack", Creature t = null, Weapon w = null) : base(n, c, t, o)
        {
            if(w == null)
            {
                Weapon = new Unarmed(o);
            }
            else
            {
                Weapon = w;
            }
        }
        public override void Effect()
        {
            base.Effect();
            if(Owner.Sp >= Cost)
            {
                int damage = Random.Range(0, Weapon.Damage) + Weapon.Owner.Str + Weapon.Buff + 1;
                Target.Hp -= damage;
                Owner.Sp -= Cost;
            }
            else
            {
                //
            }
        }
    }
    public class SimpleSpell : Attack
    {
        public SimpleSpell(Creature o, int c = 2, string n = "Magic bolt", Creature t = null) : base(n, c, t, o) { }
        public override void Effect()
        {
            int damage = -1;
            base.Effect();
            if(Owner.Sp >= Cost)
            {
                damage = Random.Range(1, 13) + Random.Range(1, 13) + Owner.Mag;
                Target.Hp -= damage;
                Owner.Sp -= Cost;
            }
            else
            {
                Debug.Log("Not enough");
            }
        }
    }
}
