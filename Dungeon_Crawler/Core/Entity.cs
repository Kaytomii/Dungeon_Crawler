namespace Dungeon_Crawler.Core
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }

        public bool IsAlive => Health > 0;

        protected Entity(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public abstract void Attack(Entity target);
    }
}
