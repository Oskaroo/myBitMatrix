using System;
using System.Collections;
using System.Text;

// prostokątna macierz bitów o wymiarach m x n
public partial class BitMatrix
{
    private BitArray data;
    public int NumberOfRows { get; }
    public int NumberOfColumns { get; }
    public bool IsReadOnly => false;

    // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
    public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
    {
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }

    public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
    public static bool BitToBool(int bit) => bit != 0;
}
    //Wyżej podany kod, jest to wstęp do zadań.


    // W drugim zadaniu tj.01. BITMATRIX - TOSTRING TEST !!! należy dodać metodę ToString, aby to zrobić w wierszu poleceń należy wpisać

    using System;
    using System.Collections;
    using System.Text;
    public partial class BitMatrix
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    sb.Append(BoolToBit(data[i * NumberOfColumns + j]) == 1 ? "1" : "0");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
