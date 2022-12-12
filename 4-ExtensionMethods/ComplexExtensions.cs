namespace ExtensionMethods
{
    /// <summary>
    /// The static class declares extension methods for complex numbers.
    /// </summary>
    public static class ComplexExtensions
    {
        /// <summary>
        /// Add two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the sum.</returns>
        public static IComplex Add(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        /// <summary>
        /// Subtract <paramref name="c2"/> from <paramref name="c1"/>.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the difference.</returns>
        public static IComplex Subtract(this IComplex c1, IComplex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        /// <summary>
        /// Multiply two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the product.</returns>
        public static IComplex Multiply(this IComplex c1, IComplex c2)
        {
            var first = c1.Real * c2.Real;
            var outer = c1.Real * c2.Imaginary;
            var inner = c1.Imaginary * c2.Real;
            var last = c1.Imaginary * c2.Imaginary;

            return new Complex(first - last, outer + inner);
        }

        private static IComplex Multiply(this IComplex c, double scalar)
        {
            return new Complex(c.Real * scalar, c.Imaginary * scalar);
        }

        /// <summary>
        /// Divide two complex numbers.
        /// </summary>
        /// <param name="c1">the first operand.</param>
        /// <param name="c2">the second operand.</param>
        /// <returns>the quotient.</returns>
        public static IComplex Divide(this IComplex c1, IComplex c2)
        {
            var realNumerator = c1.Real * c2.Real + c1.Imaginary * c2.Imaginary;
            var imaginaryNumerator = c1.Imaginary * c2.Real - c1.Real * c2.Imaginary;
            var denominator = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;

            return new Complex(realNumerator / denominator, imaginaryNumerator / denominator);
        }

        /// <summary>
        /// Get the complex conjugate of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The complex conjugate of a complex number is the number with an equal real part
        /// and an imaginary part equal in magnitude, but opposite in sign.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex conjugate.</returns>
        public static IComplex Conjugate(this IComplex c1) => new Complex(c1.Real, -c1.Imaginary);

        /// <summary>
        /// Get the reciprocal of a complex number.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The multiplicative inverse (or reciprocal) of a complex number is a number,
        /// that when multiplied with that complex number, gives an answer of 1.
        /// </para>
        /// </remarks>
        /// <param name="c1">the complex operand.</param>
        /// <returns>the complex reciprocal.</returns>
        public static IComplex Reciprocal(this IComplex c1)
        {
            return c1.Conjugate().Multiply(1 / (c1.Modulus * c1.Modulus));
        }
    }
}
