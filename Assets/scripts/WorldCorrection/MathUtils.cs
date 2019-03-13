public class MathUtils
{
    /// <summary>
    /// Re-maps a number from one range to another.
    /// </summary>
    /// <param name="s">input number</param>
    /// <param name="a1">input min number</param>
    /// <param name="a2">input max number</param>
    /// <param name="b1">output min number</param>
    /// <param name="b2">output min number</param>
    /// <returns>New number with the same percent valau as the input number</returns>
    public static float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}