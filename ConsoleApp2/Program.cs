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
            // koniec zadania 01 !!!


// W następnym zadaniu tj 02. BitMatrix - dodatkowe konstruktory !!! w miejscu poleceń należy wkleić ten kod 
using System;
using System.Collections;

public partial class BitMatrix
{
    public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
    {
        if (numberOfColumns < 1 || numberOfRows < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns);
        if (bits != null && bits.Length > 0)
        {
            for (int i = 0; i < bits.Length && i < data.Length; i++)
            {
                data[i] = BitToBool(bits[i]);
            }
        }
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
    public BitMatrix(int[,] bits)
    {
        if (bits == null)
            throw new NullReferenceException("bits array is null");
        int numberOfRows = bits.GetLength(0);
        int numberOfColumns = bits.GetLength(1);
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns);
        bool anyValue = false;
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                data[i * numberOfColumns + j] = BitToBool(bits[i, j]);
                if (bits[i, j] != 0)
                    anyValue = true;
            }
        }
        if (!anyValue)
            throw new ArgumentOutOfRangeException("bits array does not contain any non-zero values");
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
    public BitMatrix(bool[,] bits)
    {
        if (bits == null)
            throw new NullReferenceException("bits array is null");
        int numberOfRows = bits.GetLength(0);
        int numberOfColumns = bits.GetLength(1);
        if (numberOfRows < 1 || numberOfColumns < 1)
            throw new ArgumentOutOfRangeException("Incorrect size of matrix");
        data = new BitArray(numberOfRows * numberOfColumns);
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                data[i * numberOfColumns + j] = bits[i, j];
            }
        }
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
}
            // Koniec zadania 02 !

            // zadanie 03 BitMatrix - equals !!! Skopiuj kod i wklej w okno odpowiedzi
            using System;
using System.Collections;

public partial class BitMatrix : IEquatable<BitMatrix>
{
    public bool Equals(BitMatrix other)
    {
        if (ReferenceEquals(this, other))
            return true;

        if (ReferenceEquals(other, null))
            return false;

        if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows)
            return false;

        for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
        {
            if (data[i] != other.data[i])
                return false;
        }
        return true;
    }

    public override bool Equals(object obj) => Equals(obj as BitMatrix);

    public override int GetHashCode() => data.GetHashCode();

    public static bool operator ==(BitMatrix left, BitMatrix right) => Equals(left, right);
    public static bool operator !=(BitMatrix left, BitMatrix right) => !Equals(left, right);
}

                // koniec zadania 3
