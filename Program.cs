namespace _8._22
{
    internal class Program
    {
        public interface Idef
        {
             string Subtract(Binary2 binary);
             string Divide(Binary2 binary);
        }
        public abstract class Bin
        {
            protected string integerPart;
            protected string fractionalPart;
        }
        public class Binary2: Bin, Idef
        {
            
            public Binary2(string integerPart1, string fractionalPart1)
            {
                 integerPart = integerPart1;
                 fractionalPart = fractionalPart1;
            }

          
            public string Subtract(Binary2 binary)
            {
                if (this.fractionalPart.Length < binary.fractionalPart.Length)
                {
                    this.fractionalPart = this.fractionalPart.PadRight(binary.fractionalPart.Length, '0');
                }
                else if (binary.fractionalPart.Length < this.fractionalPart.Length)
                {
                    binary.fractionalPart = binary.fractionalPart.PadRight(this.fractionalPart.Length, '0');
                }

                string result = Convert.ToString(Convert.ToInt32(this.integerPart + this.fractionalPart, 2) - Convert.ToInt32(binary.integerPart + binary.fractionalPart, 2), 2);

                int fractionalPartLength = this.fractionalPart.Length;
                if (result.Length > fractionalPartLength)
                {
                    result = result.Insert(result.Length - fractionalPartLength, ".");
                }

                return result;
            }

            public string Divide(Binary2 binary)
            {
                string dividend = this.integerPart + this.fractionalPart;
                string divisor = binary.integerPart + binary.fractionalPart;

                string result = "";
                char[] dividendArray = dividend.ToCharArray();
                bool remainderExists = false;

                for (int i = 0; i < dividendArray.Length; i++)
                {
                    if (dividendArray[i] == '1')
                    {
                        if (!remainderExists)
                        {
                            result += "0";
                            remainderExists = true;
                        }
                        else
                        {
                            result += "1";
                        }
                    }
                    else
                    {
                        result += "0";
                    }
                }

                return result;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ведите челую часть числа в 2 системе для 1 числа");
                string a = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ведите дробную часть числа в 2 системе для 1 числа");
                string b = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ведите челую часть числа в 2 системе для 2 числа");
                string a1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ведите дробную часть числа в 2 системе для 2 числа");
                string b1 = Convert.ToString(Console.ReadLine());

                Binary2 binary1 = new Binary2(a, b);// первое число 

                Binary2 binary2 = new Binary2(a1, b1);// второе число

                string difference = binary1.Subtract(binary2);// минус
                Console.WriteLine("разность: " + difference);

                string divisionResult = binary1.Divide(binary2);// делить 
                Console.WriteLine("деление: " + divisionResult);
            }
            catch {
                Console.WriteLine("ошибка");
            }
        }
    }
}