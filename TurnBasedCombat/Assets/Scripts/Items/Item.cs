
using UnityEngine;
using System.Collections;
using Creatures;
namespace Items
{
    /**
 * Class is meant to represent a generic item in the game.
 * Examples of items would be stuff like consumables and weapons.
 * */
    public class Item
    {

        public string Name { get; set; }
        public bool Equipped { get; set; }
        public Creature Owner { get; set; }

        public Item() { }
        public Item(string n, bool e, Creature o)
        {
            Name = n;
            Equipped = e;
            Owner = o;
        }

        /**
         * Method represents whatever effect an individual item has
         * */
        public virtual void Effect()
        {
            //Filled in by inheritors
        }
        public virtual bool IsWeapon()
        {
            return false;
        }
        public virtual bool IsConsumable()
        {
            return false;
        }

    }

    //Represents a generic weapon in the game
    public class Weapon : Item
    {
        public int Damage { get; set; }     //An int value that'll either be 4, 6, 8 or 12
        public int Buff { get; set; }       //An int value representing any plusses to damage the weapon might have

        /*
         * Constructor initializes a weapon's values
         * */
        public Weapon(string n, bool e, Creature o, int d, int b) : base(n, e, o)
        {
            Damage = d;
            Buff = b;
        }

        public Weapon() : base() { }
        public override bool IsWeapon()
        {
            return true;
        }
    }

    public class Consumable : Item
    {
        public int Uses { get; set; }
        public Consumable(string n, Creature o, int u, bool e = false) : base(n, e, o)
        {
            Uses = u;
        }
        public override bool IsConsumable()
        {
            return true;
        }
    }
}
