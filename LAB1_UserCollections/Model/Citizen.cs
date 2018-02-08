namespace LAB1_UserCollections.Model
{
    public abstract class Citizen
    {
        public int Id { get; set; }

        public Citizen(int id)
        {
            Id = id;
        }

        #region Override methods

        public override bool Equals(object obj)
        {
            return obj is Citizen && this == (obj as Citizen);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Citizen citizen1, Citizen citizen2)
        {
            if (ReferenceEquals(citizen1, citizen2))
                return true;

            return !(citizen1 is null) && !(citizen2 is null) && (citizen1.Id == citizen2.Id);
        }

        public static bool operator !=(Citizen citizen1, Citizen citizen2)
        {
            return !(citizen1 == citizen2);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        #endregion
    }
}
