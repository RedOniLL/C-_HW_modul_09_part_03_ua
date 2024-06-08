namespace C__HW_modul_09_part_03_ua
{

    public static class FibonacciExtension
    {
        public static bool IsFibonacci(this int number)
        {
            if (number < 0)
                return false;

            int a = 0;
            int b = 1;

            while (b < number)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }

            return b == number;
        }
    }

    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            string[] words = str.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static int LengthOfLastWord(this string str)
        {
 
            int length = 0;
            int i = str.Length - 1;

            while (i >= 0 && char.IsWhiteSpace(str[i]))
            {
                i--;
            }
            while (i >= 0 && !char.IsWhiteSpace(str[i]))
            {
                length++;
                i--;
            }

            return length;
        }

        public static bool IsValidBrackets(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

    }

    public static class ArrayExtensions
    {
        public static int[] Filter(this int[] array, Predicate<int> predicate)
        {
            List<int> result = new List<int>();
            foreach (int item in array)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter choice");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    int[] testNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

                    foreach (int number in testNumbers)
                    {
                        Console.WriteLine($"{number} is Fibonacci: {number.IsFibonacci()}");
                    }
                    break;
                case 2:
                    string[] testStrings = {
                            "This is a test string.",
                            "   Another   test    string   ",
                            "OneWord",
                            "   ",
                            ""
                        };

                    foreach (string testString in testStrings)
                    {
                        int count = testString.WordCount();
                        Console.WriteLine($"Word count in '{testString}': {count}");
                    }
                    break;
                case 3:
                    string[] testStrings1 = {
                        "This is a test string.",
                        "   Another   test    string   ",
                        "OneWord",
                        "   ",
                        ""
                    };

                    foreach (string testString1 in testStrings1)
                    {
                        int length = testString1?.LengthOfLastWord() ?? 0;
                        Console.WriteLine($"Length of the last word in '{testString1}': {length}");
                    }
                    break;

                case 4:
                    string[] testStrings2 = {
                            "{}[]",
                            "(())",
                            "[{}]",
                            "[}",
                            "[[{]}]"
                        };

                    foreach (string testString2 in testStrings2)
                    {
                        bool isValid = testString2.IsValidBrackets();
                        Console.WriteLine($"Is the string '{testString2}' valid? {isValid}");
                    }
                break;

                case 5:
                    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                    
                    Predicate<int> isEven = x => x % 2 == 0;
                    int[] evenNumbers = numbers.Filter(isEven);
                    Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

                    
                    Predicate<int> isOdd = x => x % 2 != 0;
                    int[] oddNumbers = numbers.Filter(isOdd);
                    Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));

                    
                    Predicate<int> greaterThanFive = x => x > 5;
                    int[] greaterNumbers = numbers.Filter(greaterThanFive);
                    Console.WriteLine("Numbers greater than 5: " + string.Join(", ", greaterNumbers));
                break;

                case 6:
                    DailyTemperature[] weekTemperatures = new DailyTemperature[]
                        {
                            new DailyTemperature(1, 25.0, 15.0),
                            new DailyTemperature(2, 30.0, 10.0),
                            new DailyTemperature(3, 20.0, 18.0),
                            new DailyTemperature(4, 35.0, 20.0),
                            new DailyTemperature(5, 40.0, 25.0),
                            new DailyTemperature(6, 22.0, 16.0),
                            new DailyTemperature(7, 28.0, 14.0),
                        };

                    var dayWithMaxDifference = 
                    weekTemperatures.OrderByDescending(temp => temp.TemperatureDifference()).First();
                        
                        

                    Console.WriteLine($"Day with the maximum temperature difference: Day {dayWithMaxDifference.Day}");
                    Console.WriteLine($"Highest Temperature: {dayWithMaxDifference.HighestTemperature}");
                    Console.WriteLine($"Lowest Temperature: {dayWithMaxDifference.LowestTemperature}");
                    Console.WriteLine($"Temperature Difference: {dayWithMaxDifference.TemperatureDifference()}");
                    break;
                case 7:

                    StudentGrades[] studentGradesArray = new StudentGrades[]
                                   {
                                    new StudentGrades("Alice", 85, 90, 78),
                                    new StudentGrades("Bob", 92, 88, 95),
                                    new StudentGrades("Charlie", 75, 80, 70),
                                    new StudentGrades("David", 88, 90, 85)
                                   };

                    var studentWithMaxAverage =
                    studentGradesArray.OrderByDescending(student => student.AverageGrade()).First();
                        
                        

                    Console.WriteLine($"Student with the highest average grade: {studentWithMaxAverage.StudentName}");
                    Console.WriteLine("Grades:");
                    Console.WriteLine($"Math: {studentWithMaxAverage.Math}");
                    Console.WriteLine($"English: {studentWithMaxAverage.English}");
                    Console.WriteLine($"Science: {studentWithMaxAverage.Science}");
                    Console.WriteLine($"Average Grade: {studentWithMaxAverage.AverageGrade():F2}");
                    break ;
            }

        }
        }
 }
