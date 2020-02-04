using System;

public class Doolittle
{
    // C# Program to decompose a matrix into 
    // lower and upper traingular matrix

    //static int MAX = 100; 
    static String s = "";
    static void luDecomposition(int[,] mat, int n)
    {
        int[,] lower = new int[n, n];
        int[,] upper = new int[n, n];

        // Decomposing matrix into Upper and Lower 
        // triangular matrix 
        for (int i = 0; i < n; i++)
        {

            // Upper Triangular 
            for (int k = i; k < n; k++)
            {

                // Summation of L(i, j) * U(j, k) 
                int sum = 0;
                for (int j = 0; j < i; j++)
                    sum += (lower[i, j] * upper[j, k]);

                // Evaluating U(i, k) 
                upper[i, k] = mat[i, k] - sum;
            }

            // Lower Triangular 
            for (int k = i; k < n; k++)
            {
                if (i == k)
                    lower[i, i] = 1; // Diagonal as 1 
                else
                {

                    // Summation of L(k, j) * U(j, i) 
                    int sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += (lower[k, j] * upper[j, i]);

                    // Evaluating L(k, i) 
                    lower[k, i] = (mat[k, i] - sum) / upper[i, i];
                }
            }
        }

        // setw is for displaying nicely 
        Console.WriteLine(setw(2) + "	 Lower Triangular"
            + setw(10) + "Upper Triangular");

        // Displaying the result : 
        for (int i = 0; i < n; i++)
        {
            // Lower 
            for (int j = 0; j < n; j++)
                Console.Write(setw(4) + lower[i, j] + "\t");
            Console.Write("\t");

            // Upper 
            for (int j = 0; j < n; j++)
                Console.Write(setw(4) + upper[i, j] + "\t");
            Console.Write("\n");
        }
    }
    static String setw(int noOfSpace)
    {
        s = "";
        for (int i = 0; i < noOfSpace; i++)
            s += " ";
        return s;
    }

	// Driver code 
	//public static void Main(String[] arr)
	//{
	//	int[,] mat = { { 2, -1, -2 },
	//				{ -4, 6, 3 },
	//				{ -4, -2, 8 } };

	//	luDecomposition(mat, 3);
	//}
}
