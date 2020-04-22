using System.Collections.Generic;
using UnityEngine;
using Items;
using Skills;
namespace Creatures
{
    /**
 * Class is meant to represent a basic creature in the game.
 * Both a player, and an enemy will be creatures.
 * */
    public class Creature
    {

        public string Name { get; set; }            //The name of a creature
        public int Hp { get; set; }                 //A creature's health
        public int MaxHP { get; set; }
        public int Sp { get; set; }                 //A creature's "special points". For using skills
        public int MaxSP { get; set; }
        public int Str { get; set; }                //A creature's strength (used for physical attacks)
        public int Mag { get; set; }                //A creature's magic strength (used for magical attacks)
        public int Dodge { get; set; }              //A stat for dodging special attacks
        public int Will { get; set; }               //A stat for resisting magical effects
        public List<Item> Inventory { get; set; }   //A list of the character's inventory
        public List<Skill> Skills { get; set; }     //A list of the active abilities a character has

        public Creature(string n, int h, int s, int st, int m, int d, int w)
        {
            Name = n;
            Hp = h;
            MaxHP = h;
            Sp = s;
            MaxSP = s;
            Str = st;
            Mag = m;
            Dodge = d;
            Will = w;
            Inventory = new List<Item>();
            Skills = new List<Skill>();
        }

        public Weapon GetEquippedWeapon()
        {
            Weapon result =  null;
            foreach(Item w in Inventory)
            {
                if (w.IsWeapon() && w.Equipped)
                {
                    result = (Weapon)w;
                }
            }
            return result;
        }

        public List<Attack> GetAttacks()
        {
            List<Attack> result = new List<Attack>();
            foreach(Skill o in Skills)
            {
                if (o.IsAttack())
                {
                    result.Add((Attack)o);
                }
            }
            return result;
        }
        public List<Ability> GetAbilities()
        {
            List<Ability> result = new List<Ability>();
            foreach(Skill o in Skills)
            {
                if (o.IsAbility())
                {
                    result.Add((Ability)o);
                }
            }
            return result;
        }
        public List<Consumable> GetConsumables()
        {
            List<Consumable> result = new List<Consumable>();
            foreach(Item o in Inventory)
            {
                if (o.IsConsumable())
                {
                    result.Add((Consumable)o);
                }
            }
            return result;
        }
    }
}
