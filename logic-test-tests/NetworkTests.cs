using logic_test;

namespace logic_test_tests
{
    public class NetworkTests
    {
        [Fact]
        public void Constructor_should_set_elements()
        {
            var numberOfElements = 3;
            var network = new Network(numberOfElements);

            Assert.Equal(numberOfElements, network.Elements.Count);
            Assert.Contains(1, network.Elements.Select(x => x.Id));
            Assert.Contains(2, network.Elements.Select(x => x.Id));
            Assert.Contains(3, network.Elements.Select(x => x.Id));
        }

        [Fact]
        public void Constructor_should_throw_exception_when_receive_invalid_argument_value()
        {
            try
            {
                var numberOfElements = -1;
                var network = new Network(numberOfElements);
            } catch (Exception ex)
            {
                Assert.Equal(typeof(Exception), ex.GetType());
                Assert.Equal("Negatives number are not allowed.", ex.Message);
            }
        }

        [Fact]
        public void Should_connect_elements()
        {
            var network = new Network(2);
            
            network.Connect(1, 2);

            Assert.Contains(network.Elements[1], network.Elements[0].Connections);
            Assert.Contains(network.Elements[0], network.Elements[1].Connections);
        }

        [Fact]
        public void Should_throw_excpetion_when_first_element_to_connect_does_not_exist()
        {
            try
            {
                var network = new Network(2);
                network.Connect(3, 2);

            } catch (Exception ex)
            {
                Assert.Equal(typeof(Exception), ex.GetType());
                Assert.Equal("Element with Id 3 not found", ex.Message);
            }
        }

        [Fact]
        public void Should_throw_excpetion_when_second_element_to_connect_does_not_exist()
        {
            try
            {
                var network = new Network(2);
                network.Connect(1, 3);

            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(Exception), ex.GetType());
                Assert.Equal("Element with Id 3 not found", ex.Message);
            }
        }

        [Fact]
        public void Query_should_return_true_to_two_elements_connected_directly()
        {
            var network = new Network(2);

            network.Connect(1, 2);

            var result = network.Query(1, 2);

            Assert.True(result);
        }

        [Fact]
        public void Query_should_return_true_to_two_elements_connected_indirectly()
        {
            var network = new Network(3);

            network.Connect(1, 2);
            network.Connect(2, 3);

            var result = network.Query(1, 3);

            Assert.True(result);
        }

        [Fact]
        public void Query_should_return_false_when_elements_are_not_connected()
        {
            var network = new Network(3);

            var result = network.Query(1, 3);

            Assert.False(result);
        }

        [Fact]
        public void Query_should_throw_excpetion_when_first_id_does_not_exist()
        {
            try
            {
                var network = new Network(2);
                var result = network.Query(3, 2);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(Exception), ex.GetType());
                Assert.Equal("Element with Id 3 not found", ex.Message);
            }
        }

        [Fact]
        public void Query_should_throw_excpetion_when_second_id_does_not_exist()
        {
            var exception = new Exception();
            try
            {
                var network = new Network(2);
                var result = network.Query(1, 3);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.Equal(typeof(Exception), exception.GetType());
            Assert.Equal("Element with Id 3 not found", exception.Message);
        }
    }
}