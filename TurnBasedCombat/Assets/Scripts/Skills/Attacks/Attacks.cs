using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;
using Creatures;
using Weapons;
using Items;
namespace Attacks
{
    public class WeaponAttack : Skill
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
            int damage = Random.Range(0, Weapon.Damage) + Weapon.Owner.Str + Weapon.Buff + 1;
            Target.Hp -= damage;
            Owner.Sp -= Cost;
            Debug.Log("Dealing (" + damage + ") damage to " + Target.Name);
        }
    }
}
