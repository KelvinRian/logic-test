using logic_test;

namespace logic_test_tests
{
    public class ElementTests
    {
        [Fact]
        public void Constructor_should_set_Id()
        {
            var id = 9;
            var element = new Element(id);

            Assert.Equal(id, element.Id);
        }

        [Fact]
        public void Should_connect()
        {
            var element = new Element(1);
            var elementToConnect = new Element(2);

            element.Connect(elementToConnect);

            Assert.Contains(elementToConnect, element.Connections);
        }
    }
}
