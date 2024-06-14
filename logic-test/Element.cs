namespace logic_test
{
    public class Element
    {
        public int Id { get; private set; }
        public IList<Element> Connections { get; private set; } = new List<Element>();

        public Element(int id)
        {
            Id = id;
        }

        public void Connect(Element element)
        {
            Connections.Add(element);
        }
    }
}
