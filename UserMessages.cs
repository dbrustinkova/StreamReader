using System;

namespace SeparateFiles
{
    public static class UserMessages
    {
        public const string AskWhichFile = "Which file would you like to split?";
        public const string AskWhereToSave = "Where you want to save the files?";
        public const string AskHowManyFiles = "How many parts to split a file?";

        /// <summary>
        /// Show a message to the user on the console, and take in a response.
        /// </summary>
        /// <param name="question">The question/statment to show the user.</param>
        /// <returns>An answer given by the user.</returns>
        public static string PromptUserForAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
