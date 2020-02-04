using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decomposition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MatrixClass();
        DoolittleClass();
    }

    private void DoolittleClass()
    {
        //Coefficient matrix A
        int[,] coefficientMatrix = {
                                    { 1, 2, 4 },
                                    { 3, 8, 14 },
                                    { 2, 6, 13 }
                                  };

        Doolittle.LUDecomposition(coefficientMatrix, 3);
    }

    private void MatrixClass()
    {
        //A*X=B
        //Values for Matrix A
        var coefficientMatrixValues = "1 2 4\r\n" +
                                      "3 8 14\r\n" +
                                      "2 6 13";

        //Values for Matrix B
        var resultMatrixValues = "3\r\n" +
                                 "13\r\n" +
                                 "4";

        //Converts sting to Matrix
        Matrix coefficientMatrix = Matrix.Parse(coefficientMatrixValues);
        Debug.Log("A Matrix:\n" + coefficientMatrix.ToString());

        //Uncomment if you want to use random values
        //Matrix coeficientMatrix = Matrix.RandomMatrix(3, 3, 5);
        //Debug.Log(coeficientMatrix.ToString());

        //Makes L and U matrices and stores the values to L and U property
        coefficientMatrix.MakeLU();
        Debug.Log("L Matrix:\n" + coefficientMatrix.L.ToString());
        Debug.Log("U Matrix:\n" + coefficientMatrix.U.ToString());


        //Result matrix B
        Matrix resultMatrix = Matrix.Parse(resultMatrixValues);
        Debug.Log("resultMatrix:\n" + resultMatrix.ToString());

        //Solves the system of linear equations, stores the result to X and prints the result
        var xMatrix = coefficientMatrix.SolveWith(resultMatrix);
        Debug.Log("xMatrix:\n" + xMatrix.ToString());
    }
}
