namespace SizeGuesstimator
{
    using System;

    public static class Guesstimator
    {
        public static int EstimateSize<T>(T classInstance) where T : class, new()
        {
            var estimatedSize = 0;

            // Use reflection to get all string properties 
            // that have getters and setters
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var rawValue = property.GetValue(classInstance, null);

                switch (rawValue)
                {
                    case int:
                        estimatedSize += sizeof(int);
                        break;
                    case int[] intArray:
                        estimatedSize += intArray.Length * sizeof(int);
                        break;
                    case long:
                        estimatedSize += sizeof(long);
                        break;
                    case string stringValue:
                        // We are not concerned about any string overhead. Add overhead here if you want.
                        estimatedSize += sizeof(char) * stringValue.Length;
                        break;
                    case List<string> stringArray:
                        // We are not concerned about any string overhead. Add overhead here if you want.
                        estimatedSize += sizeof(char) * stringArray.Sum(sa => sa.Length);
                        break;
                    case string[] stringArray:
                        // We are not concerned about any string overhead. Add overhead here if you want.
                        estimatedSize += sizeof(char) * stringArray.Sum(sa => sa.Length);
                        break;
                    case null: // TODO: How much does a null property take up? The same as the non nullable + overhead?
                        break;
                    default:
                        // Log so we catch all properties.
                        Console.WriteLine(rawValue);
                        break;
                }
            }

            return estimatedSize;
        }
    }
}
