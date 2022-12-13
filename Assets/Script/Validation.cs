using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Validation
{
    public static Vector2[] isTris(bool[,] matrix)
    {
        Vector2[] trisPoints = new Vector2[2];

        //rows
        if (matrix[0, 0] && matrix[1, 0] && matrix[2, 0])
        {
            trisPoints[0] = new Vector2(-0.25f, 0);
            trisPoints[1] = new Vector2(2.25f, 0);
            return trisPoints;
        }

        if (matrix[0, 1] && matrix[1, 1] && matrix[2, 1])
        {
            trisPoints[0] = new Vector2(-0.25f, 1);
            trisPoints[1] = new Vector2(2.25f, 1);
            return trisPoints;
        }

        if (matrix[0, 2] && matrix[1, 2] && matrix[2, 2])
        {
            trisPoints[0] = new Vector2(-0.25f, 2);
            trisPoints[1] = new Vector2(2.25f, 2);
            return trisPoints;
        }

        //columns
        if (matrix[0, 0] && matrix[0, 1] && matrix[0, 2])
        {
            trisPoints[0] = new Vector2(0, -0.25f);
            trisPoints[1] = new Vector2(0, 2.25f);
            return trisPoints;
        }

        if (matrix[1, 0] && matrix[1, 1] && matrix[1, 2])
        {
            trisPoints[0] = new Vector2(1, -0.25f);
            trisPoints[1] = new Vector2(1, 2.25f);
            return trisPoints;
        }

        if (matrix[2, 0] && matrix[2, 1] && matrix[2, 2])
        {
            trisPoints[0] = new Vector2(2, -0.25f);
            trisPoints[1] = new Vector2(2, 2.25f);
            return trisPoints;
        }

        //Diagonals
        if (matrix[0, 0] && matrix[1, 1] && matrix[2, 2])
        {
            trisPoints[0] = new Vector2(-0.25f, -0.25f);
            trisPoints[1] = new Vector2(2.25f, 2.25f);
            return trisPoints;
        }

        if (matrix[2, 0] && matrix[1, 1] && matrix[0, 2])
        {
            trisPoints[0] = new Vector2(2.25f, -0.25f);
            trisPoints[1] = new Vector2(-0.25f, 2.25f);
            return trisPoints;
        }

        return null;
    }
}
