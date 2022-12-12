using System.Text;

namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            Real = re;
            Imaginary = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real { get; }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary { get; }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(Imaginary, Real);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            double absImaginary = Math.Abs(Imaginary);

            if (Equals(new Complex(0, 0)))
            {
                return "0";
            }

            if (!Real.Equals(0))
            {
                stringBuilder.Append($"{Real}");
            }

            if (!Imaginary.Equals(0))
            {
                stringBuilder.Append($" {GetComplexOperationSign} {absImaginary}");

                // Removing excessive white-spaces or redundant operators.
                if (Real.Equals(0))
                {
                    stringBuilder.Replace(" - ", "-");
                    stringBuilder.Replace(" + ", "");
                }
            }

            return stringBuilder.ToString();
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            if (other is null) return false;

            return Real.CompareTo(Math.Round(other.Real, 1)) == 0 &&
                   Imaginary.CompareTo(Math.Round(other.Imaginary, 1)) == 0;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj is IComplex complex) return Equals(complex);

            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        private string GetComplexOperationSign => Imaginary > 0 ? "+" : "-";
    }
}
