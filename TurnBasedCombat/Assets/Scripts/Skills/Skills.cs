using System.Collections;
using System.Collections.Generic;
using Creatures;
namespace Skills
{
    public class Skill
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Creature Target { get; set; }
        public Creature Owner { get; set; }

        public Skill() { }
        public Skill(string n, int c, Creature t, Creature o)
        {
            Name = n;
            Cost = c;
            Target = t;
            Owner = o;
        }

        public virtual void Effect()
        {
            //To be filled by inheritors
        }

        public virtual bool IsAttack()
        {
            return false;
        }

        public virtual bool IsAbility()
        {
            return false;
        }
    }

    public class Attack : Skill
    {
        public Attack() : base() { }
        public Attack(string n, int c, Creature t, Creature o) : base(n, c, t, o) { }
        public override bool IsAttack()
        {
            return true;
        }
    }

    public class Ability : Skill
    {
        public Ability() : base() { }
        public Ability(string n, int c, Creature t, Creature o) : base(n, c, t, o) { }
        public override bool IsAbility()
        {
            return true;
        }
    }
}
