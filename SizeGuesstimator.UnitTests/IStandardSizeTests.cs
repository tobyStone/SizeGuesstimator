namespace SizeGuesstimator.UnitTests
{
    internal interface IStandardSizeTests<T>
    {
        void Size_can_be_guesstimated_for_class_with_one_property(T value, int expectedSize);
        void Size_can_be_guesstimated_for_class_with_two_properties(T value, int expectedSize);
        void Size_can_be_guesstimated_for_class_with_one_variable_array_property(int arraySize, int expectedSize);
        void Size_can_be_guesstimated_for_class_with_one_fixed_array_property();
    }
}
