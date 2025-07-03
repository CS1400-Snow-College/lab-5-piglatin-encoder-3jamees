// See https://aka.ms/new-console-template for more information
// Name: James King II
// Date: July 1, 2025
// Lab: Lab 5 piglatin-encoder

        Console.WriteLine("Welcome! This program changes your message to Pig Latin and then hides it using a secret code.");

        Console.Write("Type a sentence: ");
        string sentence = Console.ReadLine()!.ToLower();

       
        string[] words = sentence.Split(' ');
        string pigLatin = "";

        
        foreach (string word in words)
        {
            string vowels = "aeiou";
            string newWord = word;

            if (vowels.Contains(word[0]))
            {
                if (vowels.Contains(word[word.Length - 1]))
                    newWord = word + "way";
                else
                    newWord = word + "ay";
            }
            else
            {
                int index = 0;
                while (index < word.Length && !vowels.Contains(word[index]))
                {
                    index++;
                }
                if (index < word.Length)
                {
                    string start = word.Substring(0, index);
                    string end = word.Substring(index);
                    newWord = end + start + "ay";
                }
                else
                {
                    newWord = word + "ay";
                }
            }

            pigLatin += newWord + " ";
        }

        Console.WriteLine("\nPig Latin: " + pigLatin);

       
        Random rand = new Random();
        int shift = rand.Next(1, 26);
        Console.WriteLine("Shift amount: " + shift);

        
        string encrypted = "";
        foreach (char c in pigLatin)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                char shifted = (char)((((c - baseChar) + shift) % 26) + baseChar);
                encrypted += shifted;
            }
            else
            {
                encrypted += c; 
            }
        }

        Console.WriteLine("Encrypted Message: " + encrypted);
    

