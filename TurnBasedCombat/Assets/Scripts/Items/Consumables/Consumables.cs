using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Creatures;
namespace Consumables
{
    public class HealthPotion : Consumable
    {
        private int heal = 10;

        public HealthPotion(Creature o, string n = "Health Potion" , int u = 1) : base(n, o, u) { }
        public override void Effect()
        {
            if((Owner.Hp + heal) >= Owner.MaxHP)
            {
                Owner.Hp = Owner.MaxHP;
            }
            else
            {
                Owner.Hp += heal;
            }
            Uses--;
        }
    }

    public class SpecialPotion : Consumable
    {
        private int boost = 5;
        public SpecialPotion(Creature o, string n = "Special Potion", int u = 2) : base(n, o, u) { }
        public override void Effect()
        {
            if((Owner.Sp + boost) >= Owner.MaxSP)
            {
                Owner.Sp = Owner.MaxSP;
            }
            else
            {
                Owner.Sp += boost;
            }
            Uses--;
        }
    }
}
