﻿using System;
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
                // Zadanie 4 - implementacja indeksera i iteratora
                using System;
using System.Collections;
using System.Collections.Generic;


public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>
{
    public int this[int i1, int i2]
    {
        get
        {
            if (i1 >= NumberOfRows || i1 < 0 || i2 >= NumberOfColumns || i2 < 0)
                throw new IndexOutOfRangeException();

            return BoolToBit(data[i1 * NumberOfRows + i2]);
        }

        set
        {
            if (i1 >= NumberOfRows || i1 < 0 || i2 >= NumberOfColumns || i2 < 0)
                throw new IndexOutOfRangeException();

            data[i1 * NumberOfRows + i2] = BitToBool(value);
        }
    }
    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
        {
            yield return BoolToBit(data[i]);
        }
    }
    IEnumerator<int> IEnumerable<int>.GetEnumerator() => (IEnumerator<int>)GetEnumerator();
}

                                //koniec zadnia 4
                    //Zadanie Zadanie 5 - implementacja interfejsu ICloneable
                    using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    public object Clone()
    {
        int[] bits = new int[NumberOfRows * NumberOfColumns];

        for (int i = 0; i < NumberOfColumns * NumberOfRows; i++)
            bits[i] = BoolToBit(data[i]);

        return new BitMatrix(NumberOfRows, NumberOfColumns, bits);
    }
}
                                            // koniec zadania 5
                                        // Zadanie 6 - parsowanie napisu


using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    public static BitMatrix Parse(string s)
    {
        if (s == null || s.Length == 0)
            throw new ArgumentNullException();

        s = s.Trim();
        string[] rows = s.Split(Environment.NewLine);

        List<int> bits = new List<int>();
        int lastSize = rows[0].Trim().Length;

        foreach (string row in rows)
        {
            int size = 0;

            foreach (char c in row.Trim())
            {
                if (c == '1' || c == '0')
                {
                    bits.Add(c == '1' ? 1 : 0);
                    size++;
                    continue;
                }

                throw new FormatException();
            }

            if (lastSize != size)
                throw new FormatException();
        }

        return new BitMatrix(rows.Length, bits.Count / rows.Length, bits.ToArray());
    }

    public static bool TryParse(string s, out BitMatrix result)
    {
        try
        {
            result = Parse(s);
        }
        catch
        {
            result = null;
            return false;
        }
        return true;
    }

}

                            // Koniec zadania 6
                    //Zadanie Zadanie 7 - konwersje jawne i niejawne
                    // file: BitMatrixPartial.cs
using System;
using System.Collections;
using System.Collections.Generic;

public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    public static explicit operator BitMatrix(int[,] arr)
    {
        if (arr == null)
            throw new NullReferenceException();

        if (arr.GetLength(0) == 0)
            throw new ArgumentOutOfRangeException();

        return new BitMatrix(arr);
    }

    public static implicit operator int[,](BitMatrix matrix)
    {
        int[,] arr = new int[matrix.NumberOfRows, matrix.NumberOfColumns];

        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                arr[i, j] = matrix[i, j];
            }
        }

        return arr;
    }

    public static explicit operator BitMatrix(bool[,] arr)
    {
        if (arr == null)
            throw new NullReferenceException();

        if (arr.GetLength(0) == 0)
            throw new ArgumentOutOfRangeException();

        return new BitMatrix(arr);
    }

    public static implicit operator bool[,](BitMatrix matrix)
    {
        bool[,] arr = new bool[matrix.NumberOfRows, matrix.NumberOfColumns];

        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                arr[i, j] = BitToBool(matrix[i, j]);
            }
        }

        return arr;
    }

    public static explicit operator BitArray(BitMatrix matrix)
    {
        BitArray arr = new BitArray(matrix.NumberOfRows * matrix.NumberOfColumns);

        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                arr[i * matrix.NumberOfColumns + j] = BitToBool(matrix[i, j]);
            }
        }

        return arr;
    }
}
                                        //Koniec zadania 7
                                    //Zadanie 8 - Operacje bitowe

using System;
using System.Collections;
using System.Collections.Generic;
public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
{
    private bool MatrixCom(BitMatrix other)
    {
        return NumberOfRows == other.NumberOfRows && NumberOfColumns == other.NumberOfColumns;
    }

    public BitMatrix And(BitMatrix other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        if (!MatrixCom(other))
            throw new ArgumentException("Matrices have different sizes.");

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] && other.data[i];
        }

        return this;
    }
    public BitMatrix Or(BitMatrix other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        if (!MatrixCom(other))
            throw new ArgumentException("Matrices have different sizes.");

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] || other.data[i];
        }

        return this;
    }

    public BitMatrix Xor(BitMatrix other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        if (!MatrixCom(other))
            throw new ArgumentException("Matrices have different sizes.");

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] ^ other.data[i];
        }

        return this;
    }

    public BitMatrix Not()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = !data[i];
        }

        return this;
    }
    public static BitMatrix operator &(BitMatrix a, BitMatrix b)
    {
        if (a == null || b == null)
            throw new ArgumentNullException();
        if (!a.MatrixCom(b))
            throw new ArgumentException("Matrices are not compatible");

        BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < a.NumberOfRows; i++)
        {
            for (int j = 0; j < a.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] & b[i, j];
            }
        }

        return result;
    }
    public static BitMatrix operator |(BitMatrix a, BitMatrix b)
    {
        if (a == null || b == null)
            throw new ArgumentNullException();
        if (!a.MatrixCom(b))
            throw new ArgumentException("Matrices are not compatible");

        BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < a.NumberOfRows; i++)
        {
            for (int j = 0; j < a.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] | b[i, j];
            }
        }

        return result;
    }

    public static BitMatrix operator ^(BitMatrix a, BitMatrix b)
    {
        if (a == null || b == null)
            throw new ArgumentNullException();
        if (!a.MatrixCom(b))
            throw new ArgumentException("Matrices are not compatible");

        BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < a.NumberOfRows; i++)
        {
            for (int j = 0; j < a.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] ^ b[i, j];
            }
        }

        return result;
    }
    public static BitMatrix operator !(BitMatrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        var result = new BitMatrix(matrix.NumberOfRows, matrix.NumberOfColumns);

        for (int i = 0; i < matrix.NumberOfRows; i++)
        {
            for (int j = 0; j < matrix.NumberOfColumns; j++)
            {
                result[i, j] = matrix[i, j] == 0 ? 1 : 0;
            }
        }

        return result;
    }
}
                    //koniec zadania 8