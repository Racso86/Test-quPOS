using System;
using System.Collections.Generic;
using System.Linq;

public class WordFinder
{
    private readonly char[][] _matrix;
    private readonly int _numRows;
    private readonly int _numCols;

    public WordFinder(IEnumerable<string> matrix)
    {
        this._matrix = matrix.Select(row => row.ToLower().ToCharArray()).ToArray();
        this._numRows = matrix.Count();
        this._numCols = matrix.First().Length;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        // Build a hash set of unique words to search for
        // Applying Distinct in order to remove repeated words
        // Using HashSet<T> instead of a List<T> to enhance performance for greater matrix dimensions
        HashSet<string> uniqueWords = new HashSet<string>(wordstream.Select(word => word.ToLower()).Distinct());

        // Initialize a dictionary to count the occurrences of each word in wordstream
        Dictionary<string,int>? wordsFound = uniqueWords.ToDictionary(word => word, _ => 0); 
        // Search horizontally
        for (int i = 0; i < this._numRows; i++)
        {
            //Creating a new string from the whole nth row
            string row = new string(_matrix[i]);
            foreach (string word in uniqueWords)
            {
                if (row.Contains(word))
                {
                    wordsFound[word]++;
                }
            }
        }

        // Search vertically
        for (int j = 0; j < this._numCols; j++)
        {
            //Creating a new string from the whole nth column
            string column = new string(_matrix.Select(row => row[j]).ToArray());
            foreach (string word in uniqueWords)
            {
                if (column.Contains(word))
                {
                    wordsFound[word]++;

                }
            }
        }


        // Return the top 10 most repeated words where appears int the matrix at least once
        return wordsFound.Where(kv => kv.Value > 0)
                        .OrderByDescending(kv => kv.Value)
                        .Take(10)
                        .Select(kv => kv.Key)
                        .ToList();
    }
}