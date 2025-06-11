using Xunit;

namespace ViaTab.Backend.Tests
{
    public class DummyTests
    {
        [Fact]
        public void Test_Always_Passes()
        {
            // Dummy test that always passes
            Assert.True(true);
        }

        [Fact]
        public void Test_Story_Model_Properties()
        {
            // Test our Story model
            var story = new ViaTab.Backend.Models.Story
            {
                Title = "Test",
                Content = "Test Content",
                Department = "A"
            };

            Assert.Equal("Test", story.Title);
            Assert.Equal("A", story.Department);
        }
    }
}