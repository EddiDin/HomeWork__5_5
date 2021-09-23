using System;

namespace HomeWork__5_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHeader("Умножение матриц на число");
            int[,] matrix = CreateMatrix();
            ShowMatrix(matrix, "Матрица до умножения:");
            int number = EnterNumber();
            int[,] resultMatrix = MatrixMultiplication(matrix, number);
            ShowMatrix(resultMatrix, "Матрица после умножения:");

            Console.WriteLine();

            ShowHeader("Сложение и вычитание матриц");
            Console.WriteLine("Создание матрицы 1:");
            int[,] matrix1 = CreateMatrix();

            Console.WriteLine();
            Console.WriteLine("Создание матрицы 2:");
            int[,] matrix2 = CreateMatrix();

            Console.WriteLine();
            ShowMatrix(matrix1, "Матрица 1:");
            ShowMatrix(matrix2, "Матрица 2:");

            Console.WriteLine();
            Console.WriteLine($"Результат сложения матриц:");
            try
            {
                resultMatrix = MatrixAddition(matrix1, matrix2);
                ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }


            Console.WriteLine();
            Console.WriteLine($"Результат вычитания матриц:");
            try
            {
                resultMatrix = MatrixSubtraction(matrix1, matrix2);
                ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }


            Console.WriteLine();
            ShowHeader("Умножение матрицы на матрицу:");

            Console.WriteLine("Создание матрицы 1:");
            matrix1 = CreateMatrix();

            Console.WriteLine();
            Console.WriteLine("Создание матрицы 2:");
            matrix2 = CreateMatrix();

            Console.WriteLine();
            ShowMatrix(matrix1, "Матрица 1:");
            ShowMatrix(matrix2, "Матрица 2:");

            Console.WriteLine();
            Console.WriteLine($"Матрица после умножения матриц 1 и 2:");
            try
            {
                resultMatrix = MatrixMultiplication(matrix1, matrix2);
                ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Ввод матрицы в консоль
        /// </summary>
        /// <returns>Матрица</returns>
        static int[,] CreateMatrix()
        {
            string userInput;
            bool successEnter = false;

            while (!successEnter)
            {
                Console.WriteLine("Введите кол-во строк матрицы:");
                userInput = Console.ReadLine();
                bool successParse = sbyte.TryParse(userInput, out sbyte rows);

                if (!successParse)
                {
                    Console.WriteLine("Ошибка при создании матрицы: Кол-во строк матрицы должно быть числом. Попробуйте снова.");
                    continue;
                }
                if (rows < 1)
                {
                    Console.WriteLine("Ошибка при создании матрицы: Кол-во строк матрицы должно быть больше 1. Попробуйте снова.");
                    continue;
                }

                Console.WriteLine("Введите кол-во столбцов матрицы:");
                userInput = Console.ReadLine();
                successParse = SByte.TryParse(userInput, out sbyte cols);

                if (!successParse)
                {
                    Console.WriteLine("Ошибка при создании матрицы: Кол-во столбцов матрицы должно быть числом. Попробуйте снова.");
                    continue;
                }
                if (cols < 1)
                {
                    Console.WriteLine("Ошибка при создании матрицы: Кол-во столбцов матрицы должно быть больше 1. Попробуйте снова.");
                    continue;
                }

                while (!successEnter)
                {
                    try
                    {
                        int[,] matrix = EnterMatrix(rows, cols);
                        return matrix;
                    }
                    catch (MatrixException e)
                    {
                        Console.WriteLine($"Ошибка при заполнении матрицы: {e.Message}. Попробуйте снова.");
                    }
                }
            }

            return new int[,] { };
        }

        /// <summary>
        /// Ввод числа в консоль
        /// </summary>
        /// <returns>Число</returns>
        static int EnterNumber()
        {
            string userInput;
            bool successEnter = false;

            while (!successEnter)
            {
                Console.WriteLine("Введите число, на которое хотите умножить матрицу:");
                userInput = Console.ReadLine();
                bool successParse = sbyte.TryParse(userInput, out sbyte number);

                if (!successParse)
                {
                    Console.WriteLine("Ошибка. Необходимо ввести число. Попробуйте снова.");
                    continue;
                }
                if (number < 1)
                {
                    Console.WriteLine("Ошибка. Число должно быть больше 0. Попробуйте снова.");
                    continue;
                }

                return number;
            }

            return 0;
        }

        /// <summary>
        /// Ввод матрицы в консоль
        /// </summary>
        /// <param name="rows">Кол-во строк</param>
        /// <param name="cols">Кол-во столбцов</param>
        /// <returns>Матрица</returns>
        public static int[,] EnterMatrix(int rows, int cols)
        {
            string userInput;
            bool successParse;
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"matrix[{i},{j}]: ");
                    userInput = Console.ReadLine();
                    successParse = SByte.TryParse(userInput, out sbyte number);

                    if (!successParse) throw new MatrixException("Елемент матрицы должен быть числом");
                    if (number < 1) throw new MatrixException("Елемент матрицы должен быть больше 1");

                    matrix[i, j] = number;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Вывод матрицы на экран с сообщением
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="message">Сообщение</param>
        public static void ShowMatrix(int[,] matrix, string message)
        {
            Console.WriteLine(message);
            ShowMatrix(matrix);
        }

        /// <summary>
        /// Вывод матрицы на экран
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public static void ShowMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="number">Число</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixMultiplication(int[,] matrix, int number)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= number;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матрицы на матрицу
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new MatrixException("При умножении матрицы A на матрицу B число столбцов матрицы A должно быть равно числу строк матрицы B.");
            }

            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            int matrix1Rows = matrix1.GetLength(0);
            int matrix1Cols = matrix1.GetLength(1);
            int matrix2Cols = matrix2.GetLength(1);

            for (var i = 0; i < matrix1Rows; i++)
            {
                for (var j = 0; j < matrix2Cols; j++)
                {
                    resultMatrix[i, j] = 0;

                    for (var k = 0; k < matrix1Cols; k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new MatrixException("Складывать можно только одинаковые по размеру матрицы.");
            }

            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            int[,] resultMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new MatrixException("Вычитать можно только одинаковые по размеру матрицы.");
            }

            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            int[,] resultMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Вывод заголовка в консоль
        /// </summary>
        /// <param name="message">Заголовок</param>
        static void ShowHeader(string message)
        {
            string divider = "----------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();
        }
    }
}
