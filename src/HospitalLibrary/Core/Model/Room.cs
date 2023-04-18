namespace HospitalLibrary.Core.Model
{
    public class Room : BaseEntityModel
    {
        public string Name { get; set; }

        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
