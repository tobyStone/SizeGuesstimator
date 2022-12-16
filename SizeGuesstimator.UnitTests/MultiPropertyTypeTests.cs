namespace SizeGuesstimator.UnitTests
{
    public class MultiPropertyTypeTests
    {
        [Fact]
        public void Class_is_sized_x()
        {
            var classA = new ClassWithIntAndString { StringProperty = "1" };

            var size = Guesstimator.EstimateSize(classA);

            Assert.Equal(6, size);
        }
    }
}
