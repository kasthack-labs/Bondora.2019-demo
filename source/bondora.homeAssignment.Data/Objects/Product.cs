namespace bondora.homeAssignment.Data
{

    public class Product : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public long EquipmentTypeId { get; set; }
        public ProductCategory EquipmentType { get; set; }
    }
}
