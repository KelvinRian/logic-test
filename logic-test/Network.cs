namespace logic_test
{
    public class Network
    {
        public List<Element> Elements { get; private set; } = new List<Element>();
        
        public Network(int numberOfElements)
        {
            if (numberOfElements < 0)
                throw new Exception("Negatives number are not allowed.");

            GenerateElements(numberOfElements);
        }

        private void GenerateElements(int numberOfElements)
        {
            Elements = new List<Element>();

            for (int i = 1; i <= numberOfElements; i++)
            {
                Elements.Add(new Element(i));
            }
        }

        public void Connect(int elementId, int elementIdToConnect)
        {
            var firstElement = GetElementById(elementId);
            var secondElement = GetElementById(elementIdToConnect);

            firstElement.Connect(secondElement);
            secondElement.Connect(firstElement);
        }

        private Element GetElementById(int id)
        {
            var element = Elements.Where(x => x.Id == id).FirstOrDefault();
            if (element == null)
                throw new Exception(string.Format("Element with Id {0} not found", id));
            return element;
        }

        public bool Query(int elementId, int elementId2)
        {
            var firstElement = GetElementById(elementId);
            var secondElement = GetElementById(elementId2);

            var directConnections = firstElement.Connections;
            var indirectConnections = GetIndirectConnections(elementId, directConnections);

            var hasDirectConnection = firstElement.Connections.Contains(secondElement);
            var hasIndirectConnection = indirectConnections.Contains(secondElement);

            return hasDirectConnection || hasIndirectConnection;
        }

        private static List<Element> GetIndirectConnections(int elementId, IList<Element> directConnections)
        {
            var indirectConnections = new List<Element>();
            foreach (var connection in directConnections)
            {
                indirectConnections.AddRange(connection.Connections.Where(x => x.Id != elementId));
            }

            return indirectConnections;
        }
    }
}
