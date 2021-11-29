namespace Infrastructure.Exceptions
{
    public class ElementNotFoundException : System.Exception
    {
        public ElementNotFoundException() : base("Entity not found")
        {

        }
    }
}
