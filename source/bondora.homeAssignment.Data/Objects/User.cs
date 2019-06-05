namespace bondora.homeAssignment.Data
{

    //would be a .net identity user but it's a home assignment
    public class User : IId, INamed, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
    }
}
