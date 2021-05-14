using System;
using System.Text.RegularExpressions;

namespace ConsoleApp7
{
    public class Rational : IComparable<Rational>
    {
        protected int numerator;
        protected int denumerator;

        public Rational(int numerator, int denumerator)
        {
            Numerator = numerator;
            Denumerator = denumerator;
        }

        public Rational(int numerator)
        {
            Numerator = numerator;
            Denumerator = 1;
        }

        public Rational()
        {
            Numerator = 0;
            Denumerator = 1;
        }

        private static int CommonDivisor(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            int temp;
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
                num2 = num2 - num1;
            }
            return num1;
        }

        private static int LeastCommonMultiple(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            int leastCommonMultiple = num1 * num2 / CommonDivisor(num1, num2);
            return leastCommonMultiple;
        }

        public int Numerator
        {
            get => numerator;
            set
            {
                numerator = value;
                if (denumerator != 0 && numerator != 0)
                {
                    int gcd = CommonDivisor(numerator, denumerator);
                    numerator /= gcd;
                    denumerator /= gcd;
                }
            }
        }

        public int Denumerator
        {
            get => denumerator;
            set
            {
                denumerator = value;
                if (denumerator == 0)
                {
                    throw new EnteringExceptions("Denumerator cannot be zero");
                }
                if (denumerator != 0 && numerator != 0)
                {
                    int generalCommonDivisor = Rational.CommonDivisor(numerator, denumerator);
                    numerator /= generalCommonDivisor;
                    denumerator /= generalCommonDivisor;
                }
            }
        }



        public double GetDouble()
        {
            return (double)Numerator / Denumerator;
        }


        public static Rational operator +(Rational num1, Rational num2)
        {
            Rational obj = new Rational();
            if (num1.Denumerator < 0)
            {
                num1.Denumerator = -num1.Denumerator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denumerator < 0)
            {
                num2.Denumerator = -num2.Denumerator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Denumerator + num1.Denumerator * num2.Numerator;
            obj.Denumerator = num1.Denumerator * num2.Denumerator;
            if (obj.Numerator != 0)
            {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denumerator));
                obj.Numerator /= div;
                obj.Denumerator /= div;
            }
            return obj;
        }

        public static Rational operator -(Rational num1, Rational num2)
        {
            Rational obj = new Rational();
            if (num1.Denumerator < 0)
            {
                num1.Denumerator = -num1.Denumerator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denumerator < 0)
            {
                num2.Denumerator = -num2.Denumerator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Denumerator - num1.Denumerator * num2.Numerator;
            obj.Denumerator = num1.Denumerator * num2.Denumerator;
            if (obj.Numerator != 0)
            {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denumerator));
                obj.Numerator /= div;
                obj.Denumerator /= div;
            }
            return obj;
        }
        public static Rational operator *(Rational num1, Rational num2)
        {
            Rational obj = new Rational();
            if (num1.Denumerator < 0)
            {
                num1.Denumerator = -num1.Denumerator;
                num1.Numerator = -num1.Numerator;
            }
            if (num2.Denumerator < 0)
            {
                num2.Denumerator = -num2.Denumerator;
                num2.Numerator = -num2.Numerator;
            }
            obj.Numerator = num1.Numerator * num2.Numerator;
            obj.Denumerator = num1.Denumerator * num2.Denumerator;
            if (obj.Numerator != 0)
            {
                int div = CommonDivisor(Math.Abs(obj.Numerator), Math.Abs(obj.Denumerator));
                obj.Numerator /= div;
                obj.Denumerator /= div;
            }
            return obj;
        }

        public static Rational operator *(Rational a, int b)
        {
            Rational rational = new Rational(a.numerator * b, a.denumerator);
            return rational;
        }

        public static Rational operator /(Rational num1, Rational num2)
        {
            Rational temp = new Rational(num2.Denumerator, num2.Numerator);
            return (num1 * temp);
        }

        public static Rational operator /(Rational a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            Rational fract = new Rational(a.numerator, a.denumerator * b);
            return fract;
        }

        public int CompareTo(Rational other)
        {
            int firstNewNumerator = Numerator * LeastCommonMultiple(Denumerator, other.Denumerator) / Denumerator;
            int secondNewNumerator = other.Numerator * LeastCommonMultiple(Denumerator, other.Denumerator) / other.Denumerator;
            if (firstNewNumerator > secondNewNumerator)
            {
                return 1;
            }
            else
            {
                if (firstNewNumerator < secondNewNumerator)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static bool operator ==(Rational first, Rational second)
        {
            return first.CompareTo(second) == 0;
        }

        public static bool operator !=(Rational first, Rational second)
        {
            return first.CompareTo(second) != 0;
        }

        public static bool operator >=(Rational first, Rational second)
        {
            return first.CompareTo(second) >= 0;
        }

        public static bool operator <=(Rational first, Rational second)
        {
            return first.CompareTo(second) <= 0;
        }

        public static bool operator >(Rational first, Rational second)
        {
            return first.CompareTo(second) == 1;
        }

        public static bool operator <(Rational first, Rational second)
        {
            return first.CompareTo(second) == -1;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return GetDouble();
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDouble());
        }

        public static explicit operator int(Rational number)
        {
            return number.ToInt32(null);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDouble());
        }

        public static explicit operator UInt32(Rational number)
        {
            return number.ToUInt32(null);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDouble());
        }

        public static explicit operator short(Rational number)
        {
            return number.ToInt16(null);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDouble());
        }

        public static explicit operator UInt16(Rational number)
        {
            return number.ToUInt16(null);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDouble());
        }

        public static explicit operator long(Rational number)
        {
            return number.ToInt64(null);
        }


        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDouble());
        }

        public static explicit operator UInt64(Rational number)
        {
            return number.ToUInt64(null);
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(GetDouble());
        }

        public static explicit operator bool(Rational number)
        {
            return number.ToBoolean(null);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(GetDouble());
        }

        public static explicit operator char(Rational number)
        {
            return number.ToChar(null);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDouble());
        }

        public static explicit operator SByte(Rational number)
        {
            return number.ToSByte(null);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(GetDouble());
        }

        public static explicit operator Byte(Rational number)
        {
            return number.ToByte(null);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDouble());
        }

        public static explicit operator Single(Rational number)
        {
            return number.ToSingle(null);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(GetDouble());
        }

        public static explicit operator decimal(Rational number)
        {
            return number.ToDecimal(null);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(GetDouble());
        }

        public static explicit operator DateTime(Rational number)
        {
            return number.ToDateTime(null);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational newObj)
            {
                return (this.CompareTo(newObj) == 0);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Rational Parse(string str)
        {
            if (TryParse(str, out Rational obj))
            {
                return obj;
            }
            else
            {
                throw new Exception("String in incorrect format!");
            }
        }
        public static bool TryParse(string str, out Rational obj)
        {
            obj = null;
            Regex standart = new Regex(@"^(-?\d+)/(-?\d+)$");
            Regex integerPart = new Regex(@"^(-?\d+)$");
            Regex decimalFormat = new Regex(@"^(-?\d+)[,|\.](\d+)$");
            if (standart.IsMatch(str))
            {
                Match match = standart.Match(str);
                obj = new Rational(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                return true;
            }
            else if (integerPart.IsMatch(str))
            {
                Match match = integerPart.Match(str);
                obj = new Rational(int.Parse(match.Groups[1].Value));
                return true;
            }
            else if (decimalFormat.IsMatch(str))
            {
                Match match = decimalFormat.Match(str);
                int num = int.Parse(match.Groups[2].Value);
                int counter = 1;
                while (num > 9)
                {
                    num /= 10;
                    counter++;
                }
                if (match.Groups[1].Value[0] == '-')
                {
                    obj = new Rational(-(int.Parse(match.Groups[2].Value) + int.Parse(match.Groups[1].Value) * (int)Math.Pow(10, counter)), (int)Math.Pow(10, counter));
                }
                else
                {
                    obj = new Rational(int.Parse(match.Groups[2].Value) + int.Parse(match.Groups[1].Value) * (int)Math.Pow(10, counter), (int)Math.Pow(10, counter));
                }

                return true;
            }
            return false;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }


        public override string ToString()
        {
            return ToString("Standart");
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "Standart":
                    return string.Concat(Numerator, "/", Denumerator);
                case "IntegerPart":
                    string res = string.Concat(Math.Abs(Numerator / Denumerator), " ", Math.Abs(Numerator % Denumerator), "/", Denumerator);
                    if (Numerator < 0) res = "-" + res;
                    return res;
                case "DecimalFormat":
                    return ((decimal)Numerator / Denumerator).ToString();
                default:
                    throw new EnteringExceptions("Wrong format");
            }
        }
    }
}