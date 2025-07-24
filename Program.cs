internal class Program
{
    static List<int> numberList = new List<int>();
    static string[,] bingoCard = new string[3, 9];
    private static void Main(string[] args)
    {
        InitialiseBingoCard();
        BuildCard();
        PrintCard();
    }

    private static void BuildCard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int tempNumber = GenerateRandomNumber();
                int column = (tempNumber - 1) / 10; // Determine the column based on the number
                if (bingoCard[i, column]==String.Empty) // Ensure the column can hold the number
                {
                    bingoCard[i, column] += tempNumber.ToString().PadLeft(2, '0') + " "; // Add the number to the column
                }
                else
                {
                    j--; // If the column is full, retry this iteration
                    continue;
                }
               
            }
        }
        SortCard(); // Sort the card after filling it
    }
    private static void SortCard()
    {
        List<int> tempList = new List<int>();
        // sort the card by columns
        for (int column = 0; column < 9; column++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (bingoCard[row,column]!="")
                {
                    tempList.Add(Convert.ToInt32(bingoCard[row,column]));
                }
                
            }
            tempList.Sort(); // Sort the numbers in the column
            for (int row =2; row >= 0; row--)
            {
                if (tempList.Count == 0)
                {
                    break; // If there are no numbers left, exit the loop
                }
                if (bingoCard[row, column] != "")
                {
                    bingoCard[row, column] =  tempList[tempList.Count-1].ToString().PadLeft(2, '0') ; 
                    tempList.RemoveAt(tempList.Count - 1); // Remove the last element after assigning it
                }
            }
            tempList.Clear(); // Clear the temporary list for the next column
        }
    }

    private static void PrintCard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (bingoCard[i, j] == "")
                {
                    Console.Write("   "); // Print empty space for unfilled cells
                }
                else
                {
                    Console.Write(bingoCard[i, j].TrimEnd() + " "); // Print the numbers in the column
                }
            }
            Console.WriteLine();
        }
    }
    private static int GenerateRandomNumber()
    {
        Random rnd = new Random();
        while (true)
        {
            int number = rnd.Next(1, 91); // Generate a number between 1 and 90
            if (!numberList.Contains(number))
            {
                numberList.Add(number);
                return number;
            }
        }
    }
    private static void InitialiseBingoCard()
    {
        // Initialize the bingo card with empty strings
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                bingoCard[i, j] = "";
            }
        }
    }
}