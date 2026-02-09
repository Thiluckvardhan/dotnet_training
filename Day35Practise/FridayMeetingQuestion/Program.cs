// Question
// ------------
// A linguistics trainer is teaching students how to compare two words based on their common letters.
// To test their understanding, she gives them a challenge:
// Given two words:
// Identify the common characters between the two words (case-sensitive)
// Count how many characters must be removed from the first word so that it contains only those common characters
// Two students, Sam and John, want to complete the task efficiently, and they ask for your help.
// Your job is to determine how many deletions are required from word1.
// Functionality Required
// Write a program that:
// Takes two words from the user
// Finds characters that are not common between the two words
// Counts how many characters must be deleted from word1
// Prints this number
// Example 1
// Input
// word1 = sea
// word2 = eat
// Process
// Common letters between both words: e, a
// Characters in word1 but NOT common: s → must be removed
// Characters in word2 don't matter for removal count.
// Output
// 2
// (1 character removed from word1 + 1 character from word2?
// or simply total mismatched count across both words — but your example shows sum of mismatches across both strings is counted.)
// Example 2
// Input
// word1 = leetcode
// word2 = etco
// Process
// Common letters: e, t, c, o
// Letters in word1 that must be removed: l, e, d, e → 4 removals
// Output
// 4

public class Program
{
    public static void Main()
    {
        System.Console.Write("Enter First Word: ");
        string? input1 = Console.ReadLine();
        System.Console.Write("Enter Second Word: ");
        string? input2 = Console.ReadLine();
        
        if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
        {
            System.Console.WriteLine("Invalid input");
            return;
        }
        
        Dictionary<char, int> freq1 = new Dictionary<char, int>();
        Dictionary<char, int> freq2 = new Dictionary<char, int>();
        
        foreach (char c in input1)
        {
            if (freq1.ContainsKey(c))
                freq1[c]++;
            else
                freq1[c] = 1;
        }
        
        foreach (char c in input2)
        {
            if (freq2.ContainsKey(c))
                freq2[c]++;
            else
                freq2[c] = 1;
        }
        
        int totalDeletions = 0;
        
        foreach (char c in freq1.Keys)
        {
            int count1 = freq1[c];
            int count2 = freq2.ContainsKey(c) ? freq2[c] : 0;
            totalDeletions += Math.Abs(count1 - count2);
        }
        
        foreach (char c in freq2.Keys)
        {
            if (!freq1.ContainsKey(c))
            {
                totalDeletions += freq2[c];
            }
        }
        
        System.Console.WriteLine(totalDeletions);
    }
}