using System;
using System.Runtime.InteropServices;

class Program
{
    static void Task_1(int N)
    {
        int[] nums = new int[N];
        for (int i = 0; i < N; i++)
            nums[i] = i;
        for (int i = N - 1; i >= 0; i--)
            Console.Write(nums[i] + " ");
        Console.WriteLine();
    }

    static void Task_2(int N)
    {
        int[,] nums = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                nums[i, j] = 0;
                if (j >= i) nums[i, j] = 1;
                if (j == (i - 1)) nums[i, j] = 1;
                Console.Write(nums[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Task_3_and_4(int M, int N)
    {
        int[,] nums = new int[M, N];
        int k = 1;
        int lenght = N;
        int high = M;
        int condition;

        if (M == 1 && N == 1)
        {
            nums[0, 0] = 1;
            Console.WriteLine(nums[0, 0]);
            return;
        }

        if (N == 1)
        {
            for (int i = 0; i < M; i++)
            {
                nums[i, 0] = i;
                Console.WriteLine(nums[i, 0]);
            }
            return;
        }

        if (M == 1)
        {
            for (int j = 0; j < N; j++)
            {
                nums[0, j] = j;
                Console.Write(nums[0, j] + "\t");
            }
            Console.WriteLine();
            return;
        }

        if (high > lenght)
            condition = lenght % 2 == 0 ? lenght / 2 : (lenght + 1) / 2;
        else
            condition = high % 2 == 0 ? high / 2 : (high + 1) / 2;

        for (int start = 0; start < condition; start++, lenght--, high--)
        {
            for (int j = start; j < lenght; j++)
            {
                nums[start, j] = k;
                k++;
            }
            if (nums[start + 1, lenght - 1] != 0) break;

            for (int i = start + 1; i < high; i++)
            {
                nums[i, lenght - 1] = k;
                k++;
            }
            if (nums[high - 1, lenght - 2] != 0) break;

            for (int j = lenght - 2; j > start; j--)
            {
                nums[high - 1, j] = k;
                k++;
            }
            if (nums[high - 1, start] != 0) break;

            for (int i = high - 1; i > start; i--)
            {
                nums[i, start] = k;
                k++;
            }
        }

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(nums[i, j] + "\t");
            Console.WriteLine();
        }
    }

    enum Operation
    {
        None = 0,
        Plus = 1,
        Minus = 2,
        Multiplication = 3,
        Division = 4,
        Sqr = 5,
        Sqrt = 6,
    }

    static int DoOperation(int op, int a, int b)
    {
        switch (op)
        {
            case 1:
                return a + b;
            case 2:
                return a - b;
            case 3:
                return a * b;
            case 4:
                return a / b;
            case 5:
                return Convert.ToInt32(Math.Pow(a, b));
            case 6:
                return Convert.ToInt32(Math.Sqrt(a));
            default:
                Console.WriteLine("There is no such operation");
                return 0;
        }
    }

    static void Main()
    {
        int N, M;

        Console.Write("Task number 1\nEnter size: ");
        N = Convert.ToInt32(Console.ReadLine());
        if (N < 1)
            throw new ArgumentException("The size cannot be less than one");
        Task_1(N);

        Console.WriteLine();
        Console.Write("Task number 2\nEnter size: ");
        N = Convert.ToInt32(Console.ReadLine());
        if (N < 1)
            throw new ArgumentException("The size cannot be less than one");
        Task_2(N);

        Console.WriteLine();
        Console.Write("Task number 3\nEnter size: ");
        N = Convert.ToInt32(Console.ReadLine());
        if (N < 1)
            throw new ArgumentException("The size cannot be less than one");
        Task_3_and_4(N, N);

        Console.WriteLine();
        Console.Write("Task number 4\nEnter number of columns: ");
        N = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number of rows: ");
        M = Convert.ToInt32(Console.ReadLine());
        if (N < 1 || M < 1)
            throw new ArgumentException("The size cannot be less than one");
        Task_3_and_4(M, N);

        Console.WriteLine();
        Console.Write("Task number 5\nEnter operation: ");
        int op, a, b;

        Console.WriteLine("To display available operations, press 1");
        string cho = Console.ReadLine() ?? "0";
        if (cho == "") cho = "0";
        int choice = Convert.ToInt32(cho);
        if (choice == 1)
            Console.WriteLine("Available operations: plus, minus, multiplications, division, sqr, sqrt");

        Console.Write("Enter operation: ");
        string? operation = Console.ReadLine();
        op = 0;
        if (operation == "Plus" || operation == "plus" || operation == "PLUS" || operation == "1")
            op = Convert.ToInt32(Operation.Plus);
        if (operation == "Minus" || operation == "minus" || operation == "MINUS" || operation == "2")
            op = Convert.ToInt32(Operation.Minus);
        if (operation == "Multiplication" || operation == "multiplications" || operation == "MULTIPLICATIONS" || operation == "3")
            op = Convert.ToInt32(Operation.Multiplication);
        if (operation == "Division" || operation == "division" || operation == "DIVISION" || operation == "4")
            op = Convert.ToInt32(Operation.Division);
        if (operation == "Sqr" || operation == "sqr" || operation == "SQR" || operation == "5")
            op = Convert.ToInt32(Operation.Sqr);
        if (operation == "Sqrt" || operation == "sqrt" || operation == "SQRT" || operation == "6")
            op = Convert.ToInt32(Operation.Sqrt);

        if (op == 6)
        {
            Console.Write("Enter number: ");
            string? sa = Console.ReadLine();
            if (sa == "" || sa == null)
                throw new ArgumentException("Error: expected number");
            a = Convert.ToInt32(sa);
            b = 0;
        }
        else
        {
            Console.Write("Enter number 1: ");
            string? sa = Console.ReadLine();
            if (sa == "" || sa == null)
                throw new ArgumentException("Error: expected number");
            a = Convert.ToInt32(sa);
            Console.Write("Enter number 2: ");
            string? sb = Console.ReadLine();
            if (sb == "" || sb == null)
                throw new ArgumentException("Error: expected number");
            b = Convert.ToInt32(sb);
        }
        Console.Write("Result: " + DoOperation(op, a, b));
    }
}