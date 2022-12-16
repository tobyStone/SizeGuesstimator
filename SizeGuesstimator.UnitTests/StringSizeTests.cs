namespace SizeGuesstimator.UnitTests
{
    public class StringSizeTests : IStandardSizeTests<string>
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("1", 2)]
        [InlineData("1234567890", 20)]
        public void Size_can_be_guesstimated_for_class_with_one_property(string value, int expectedSize)
        {
            var classWithOneString = new ClassWithOneString { StringProperty = value };

            var size = Guesstimator.EstimateSize(classWithOneString);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("1", 4)]
        [InlineData("1234567890", 40)]
        public void Size_can_be_guesstimated_for_class_with_two_properties(string value, int expectedSize)
        {
            var classWithTwoStrings = new ClassWithTwoStrings { StringPropertyA = value, StringPropertyB = value, };

            var size = Guesstimator.EstimateSize(classWithTwoStrings);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 20)]
        [InlineData(10, 200)]
        public void Size_can_be_guesstimated_for_class_with_one_variable_array_property(int arraySize, int expectedSize)
        {
            var classWithVariableStringArray = new ClassWithVariableStringArray
            {
                StringProperty = Enumerable.Range(1, arraySize).Select(r => r.ToString("0000000000")).ToList(),
            };

            var size = Guesstimator.EstimateSize(classWithVariableStringArray);

            Assert.Equal(expectedSize, size);
        }

        [Fact]
        public void Size_can_be_guesstimated_for_class_with_one_fixed_array_property()
        {
            var classWithFixedStringArray = new ClassWithFixedStringArray();

            var size = Guesstimator.EstimateSize(classWithFixedStringArray);

            Assert.Equal(20, size);
        }

        // VS says 24 bytes when string is null, "", "1" or even "123456789023424234234234234".
        private class ClassWithOneString
        {
            public string? StringProperty { get; set; }
        }

        private class ClassWithTwoStrings
        {
            public string? StringPropertyA { get; set; }

            public string? StringPropertyB { get; set; }
        }

        private class ClassWithVariableStringArray
        {
            public List<string>? StringProperty { get; set; }
        }

        private class ClassWithFixedStringArray
        {
            public string[] StringProperty { get; } = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", };
        }
    }
}
