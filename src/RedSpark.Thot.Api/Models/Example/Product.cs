namespace RedSpark.Thot.Api.Models.Example
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            var compareTo = obj is Product ? (Product)obj : default;

            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode() + 3573;
        }
    }
}
