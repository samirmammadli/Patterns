
namespace DecoratorPattern
{
    abstract class HumanProfessions : Humans
    {
        public Humans Human { get; protected set; }
        public override int Damage { get => Human.Damage + _damage; protected set => _damage = value; }
        public override int Defence { get => Human.Defence + _defence; protected set => _defence = value; }
        public override int Speed { get => Human.Speed + _speed; protected set => _speed = value; }
        public override int HP { get => Human.HP + _hp; protected set => _hp = value; }
    }

    abstract class ElfsProfessions : Elfs
    {
        public Elfs Elf { get; protected set; }
        public override int Damage { get => Elf.Damage + _damage; protected set => _damage = value; }
        public override int Defence { get => Elf.Defence + _defence; protected set => _defence = value; }
        public override int Speed { get => Elf.Speed + _speed; protected set => _speed = value; }
        public override int HP { get => Elf.HP + _hp; protected set => _hp = value; }
    }
}
