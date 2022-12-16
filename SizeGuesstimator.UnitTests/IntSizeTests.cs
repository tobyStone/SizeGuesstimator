namespace SizeGuesstimator.UnitTests
{
    public class IntSizeTests : IStandardSizeTests<int>
    {
        [Theory]
        [InlineData(int.MinValue, 4)]
        [InlineData(-1, 4)]
        [InlineData(0, 4)]
        [InlineData(int.MaxValue, 4)]
        public void Size_can_be_guesstimated_for_class_with_one_property(int value, int expectedSize)
        {
            var classWithOneInt = new ClassWithOneInt { IntProperty = value };

            var size = Guesstimator.EstimateSize(classWithOneInt);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData(int.MinValue, 8)]
        [InlineData(-1, 8)]
        [InlineData(0, 8)]
        [InlineData(int.MaxValue, 8)]
        public void Size_can_be_guesstimated_for_class_with_two_properties(int value, int expectedSize)
        {
            var classWithTwoInts = new ClassWithTwoInts { IntPropertyA = value, IntPropertyB = value };

            var size = Guesstimator.EstimateSize(classWithTwoInts);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 4)]
        [InlineData(10, 40)]
        public void Size_can_be_guesstimated_for_class_with_one_variable_array_property(int arraySize, int expectedSize)
        {
            var classWithVariableIntArray = new ClassWithVariableIntArray { IntProperty = new int[arraySize] };

            var size = Guesstimator.EstimateSize(classWithVariableIntArray);

            Assert.Equal(expectedSize, size);
        }

        [Fact]
        public void Size_can_be_guesstimated_for_class_with_one_fixed_array_property()
        {
            var classWithFixedIntArray = new ClassWithFixedIntArray();

            var size = Guesstimator.EstimateSize(classWithFixedIntArray);

            Assert.Equal(40, size);
        }

        private class ClassWithOneInt
        {
            public int IntProperty { get; set; }
        }

        private class ClassWithTwoInts
        {
            public int IntPropertyA { get; set; }

            public int IntPropertyB { get; set; }
        }

        private class ClassWithVariableIntArray
        {
            public int[]? IntProperty { get; set; }
        }

        private class ClassWithFixedIntArray
        {
            public int[] IntProperty { get; } = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        }
    }
}
