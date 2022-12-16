namespace SizeGuesstimator.UnitTests
{
    public class NoPropertySizeTests
    {
        [Fact]
        public void Class_without_any_properties_is_guesstimated_as_zero()
        {
            var classWithoutAnyProperties = new ClassWithNoProperties();

            var size = Guesstimator.EstimateSize(classWithoutAnyProperties);

            Assert.Equal(0, size);
        }

        // VS says 24 bytes.
        private class ClassWithNoProperties
        {
        }
    }
}
