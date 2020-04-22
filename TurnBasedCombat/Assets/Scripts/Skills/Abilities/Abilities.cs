using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skills;
using Creatures;
namespace Abilities
{
    public class BulkUp : Ability
    {
        public BulkUp(Creature o, string n = "Bulk up", int c = 2, Creature t = null) : base(n, c, t, o) { Target = Owner; }
        public override void Effect()
        {
            base.Effect();
            if (Owner.Sp >= Cost)
            {
                Owner.Str += 2;
                Owner.Sp -= Cost;
            }
            else
            {
                Debug.Log("Not enough SP");
            }
        }
    }

    public class Heal : Ability
    {
        public Heal(Creature o, string n = "Healing", int c = 3, Creature t = null) : base(n, c, t, o) { }
        public override void Effect()
        {
            int heal = 0;
            base.Effect();
            if(Owner.Sp >= Cost)
            {
                heal = 10 + Owner.Mag;
                if((Target.Hp + heal) >= Target.MaxHP)
                {
                    Target.Hp = Target.MaxHP;
                }
                else
                {
                    Target.Hp += heal;
                }
                Owner.Sp -= Cost;
            }
        }
    }
}
