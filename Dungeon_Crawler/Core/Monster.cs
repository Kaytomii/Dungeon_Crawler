using Dungeon_Crawler.Items.Interfaces;
namespace Dungeon_Crawler.Core
{
    public abstract class Monster : Entity
    {
        public IItem Loot { get; protected set; }

        protected Monster(string name, int health, int attackPower, IItem loot)
            : base(name, health, attackPower)
        {
            Loot = loot;
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}
