namespace AOC_Day_8;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-8-data.txt");

        int[][] mat = CreateMatrix(lines);

        bool visible = false;

        int outerEdgeVisible = 0;
        int innerEdgeVisible = 0;

        outerEdgeVisible += (2 * mat[0].Length) + (2 * mat.Length - 4);

        for (int i = 1; i < mat.Length - 1; i++)
        {
            for (int j = 1; j < mat[0].Length - 1; j++)
            {
                visible = IsVisible(i, j, mat);

                if (visible)
                {
                    innerEdgeVisible++;
                }
            }
        }

        Console.WriteLine(outerEdgeVisible + innerEdgeVisible);

        int scenicScore = 0;
        int maxScore = int.MinValue;

        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                scenicScore = GetScenicScore(i, j, mat);
                maxScore = Math.Max(maxScore, scenicScore);
            }
        }

        Console.WriteLine(maxScore);
    }

    static int[][] CreateMatrix(string[] lines)
    {
        int[][] mat = new int[lines.Length][];
        int i = 0;
        int j = 0;

        foreach (string line in lines)
        {
            j = 0;
            mat[i] = new int[line.Length];

            foreach (char ch in line)
            {
                mat[i][j] = ch - '0';
                j++;
            }

            i++;
        }

        return mat;
    }

    static bool IsVisible(int indX, int indY, int[][] mat)
    {
        int rowLen = mat.Length;
        int colLn = mat[0].Length;
        int posHeight = mat[indX][indY];

        bool top = true, left = true, right = true, bottom = true;

        //check for left
        for (int j = 0; j < indY; j++)
        {
            if (mat[indX][j] >= posHeight)
            {
                left = false;
            }
        }

        //check for right
        for (int j = indY + 1; j < colLn; j++)
        {
            if (mat[indX][j] >= posHeight)
            {
                right = false;
            }
        }

        //check for top
        for (int i = indX - 1; i >= 0; i--)
        {
            if (mat[i][indY] >= posHeight)
            {
                top = false;
            }
        }

        //check for bottom
        for (int i = indX + 1; i < rowLen; i++)
        {
            if (mat[i][indY] >= posHeight)
            {
                bottom = false;
            }
        }

        return (left || right || bottom || top);
    }

    static int GetScenicScore(int indX, int indY, int[][] mat)
    {
        int rowLen = mat.Length;
        int colLn = mat[0].Length;
        int posHeight = mat[indX][indY];

        int top = 0, left = 0, right = 0, bottom = 0;

        //check for left
        for (int j = indY - 1; j >= 0; j--)
        {
            left++;
            if (mat[indX][j] >= posHeight)
            {
                break;
            }
        }

        //check for right
        for (int j = indY + 1; j < colLn; j++)
        {
            right++;
            if (mat[indX][j] >= posHeight)
            {
                break;
            }
        }

        //check for top
        for (int i = indX - 1; i >= 0; i--)
        {
            top++;
            if (mat[i][indY] >= posHeight)
            {
                break;
            }
        }

        //check for bottom
        for (int i = indX + 1; i < rowLen; i++)
        {
            bottom++;
            if (mat[i][indY] >= posHeight)
            {
                break;
            }
        }

        return (left * right * bottom * top);
    }
}