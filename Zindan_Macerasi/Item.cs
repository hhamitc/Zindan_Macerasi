namespace Zindan_Macerasi
{
    public abstract class Item
    {
        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Character character);

        public override bool Equals(object? obj)
        {
            if (obj is Item otherItem)
                return Name == otherItem.Name;
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }
}
