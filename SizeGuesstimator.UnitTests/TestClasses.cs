namespace SizeGuesstimator.UnitTests
{
    // Using VS tools, this object comes out at 32 bytes. This is why we are only guestimating the size.
    public class ClassWithIntAndString
    {
        public int IntProperty { get; set; }

        public string? StringProperty { get; set; }
    }
}
