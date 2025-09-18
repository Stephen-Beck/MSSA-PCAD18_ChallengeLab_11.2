/*
1189. Maximum Number of Balloons 

public class Solution {
    public int MaxNumberOfBalloons(string text) {
        
    }
}
*/

/*
Given a string text, you want to use the characters of text to form as many instances of the word "targetDict" as possible.

You can use each character in text at most once. Return the maximum number of instances that can be formed.

    Example 1:
        Input: text = "nlaebolko"
        Output: 1

    Example 2:
        Input: text = "loonbalxballpoon"
        Output: 2

    Example 3:
        Input: text = "leetcode"
        Output: 0
*/

namespace ChallengeLab_11._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "nlaebolko";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 1

            text = "loonbalxballpoon";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 2

            text = "leetcode";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 0

            // custom test cases
            text = "aaaaaaaaaabbbbbbbbbooooooooollllllllllnnnnnnnnn";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 4

            text = "balloonxballoonxballoon";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 3

            text = "baboon";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 0

            text = "baloon";
            Console.WriteLine($"Input: text = \"{text}\"");
            Console.WriteLine($"Output: {MaxNumberOfBalloons(text)}\n"); // expect 0
        }

        static int MaxNumberOfBalloons(string text)
        {
            // Generate a dictionary for target word (could have hardcoded this as well, but this allows for better reusability)
            string targetWord = "balloon";
            Dictionary<char, int> targetDict = new();
            foreach (char c in targetWord)
            {
                if (targetDict.ContainsKey(c)) targetDict[c]++;
                else targetDict.Add(c, 1);
            }

            // Generate dictionary for text
            Dictionary<char, int> textDict = new();
            foreach(char c in text)
            {
                if (textDict.ContainsKey(c)) textDict[c]++;
                else textDict.Add(c, 1);
            }

            // Calculate how many instances of "balloon" can be made from the text
            int instances = -1; // set to -1 so it's clear if there is an error in the code output
            foreach (var c in targetDict.Keys)
            {
                // if text does not contain a letter in "balloon"
                if (!textDict.ContainsKey(c)) return 0;

                int calculation = textDict[c] / targetDict[c];

                if (instances == -1)
                {
                    // Assign initial value to instances
                    instances = calculation;
                }
                else
                {
                    // Keep the smaller of the two values between instances and calculation
                    instances = Math.Min(instances, calculation);
                }
            }

            return instances;
        }
    }
}
