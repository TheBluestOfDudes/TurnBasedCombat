using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Creatures;
namespace Weapons
{
    public class Longsword : Weapon
    {
        public Longsword(Creature o, string n =  "Longsword", bool e = false, int d = 8, int b = 0) : base(n, e, o, d, b) { }
    }

    public class Wand : Weapon
    {
        public Wand(Creature o, string n = "Magic Wand", bool e = false, int d = 4, int b = 0) : base(n, e, o, d, b) { }

        public override void Effect()
        {
            Owner.Mag += 5;
        }
    }

    public class Unarmed : Weapon
    {
        public Unarmed(Creature o, string n = "Punch", bool e = false, int d = 4, int b = 0) : base(n, e, o, d, b) { }
    }
}
