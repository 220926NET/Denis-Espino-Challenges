int GetIntegerInput(string prompt)
{
    // Repeat until we get a valid integer from the user
    while(true)
    {
        // Display the prompt
        Console.WriteLine(prompt);

        // Get user input
        string? input = Console.ReadLine();

        // Retry if the user enters a null or empty string
        if (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("You have entered an empty input. Please try again.");
            continue;
        }

        // Retry if the user does not enter a valid integer
        int output;
        if (!int.TryParse(input, out output))
        {
            Console.WriteLine("You have not entered a valid integer. Please try again.");
            continue;
        }
        
        return output;
    }
}


// Display the program's name to the user
Console.WriteLine("Welcome to the Sweet'nSalty Application.");
Console.WriteLine("Press ENTER to continue.");
Console.ReadLine();

// The number we will start printing from and the number to stop print at
int numberStart, numberStop;

Console.WriteLine("You will enter a number to start counting from and a number to stop at. The numbers must be less than 1000 apart.");

// Repeat until the difference between the start and stop variables is less than 1000
while(true)
{
    numberStart = GetIntegerInput("What number would you like to start from?");
    numberStop = GetIntegerInput("What number would you like to stop at?");

    if (numberStart > numberStop)
    {
        Console.WriteLine("Sorry but the starting number must be less than the stopping number. Please try again.");
    }
    else if (numberStop - numberStart > 1000)
    {
        Console.WriteLine("Sorry but your numbers must be less than 1000 apart. Please try again.");
    }
    else
        break;
}


// The amount of numbers we will display per line
int numbersPerLine;

Console.WriteLine("You will enter the quantity of numbers to display per line. The quantity must be between 5 and 30.");

// Repeat until the numbersPerLine variable is between 5 and 30
while(true)
{
    numbersPerLine = GetIntegerInput("How many numbers per line do you want to see?");
    if (numbersPerLine > 30 || numbersPerLine < 5)
    {
        Console.WriteLine("Sorry but the quantity must be between 5 and 30.");
    }
    else
        break;
}

Console.WriteLine($"Printing the Sweet'nSalty numbers from {numberStart} to {numberStop}...");

// Keep track of the quantity of numbers printed on the current line
int numbersOnThisLine = 0;

// Count instances of each occurrence
int sweetSaltyCount = 0; 
int saltyCount = 0;
int sweetCount = 0;

for (int i = numberStart; i <= numberStop; i++)
{
    // Print and count the occurrence of each
    if (i % 15 == 0)
    {
        Console.Write("Sweet'nSalty");
        sweetSaltyCount++;
    }
    else if (i % 5 == 0)
    {
        Console.Write("Salty");
        saltyCount++;
    }
    else if (i % 3 == 0 )
    {
        Console.Write("Sweet");
        sweetCount++;
    }
    else
        Console.Write(i);

    // Go to next line if the numbers per line limit has been reached, else print a space
    if (++numbersOnThisLine >= numbersPerLine)
    {
        Console.WriteLine();
        numbersOnThisLine = 0;
    }
    else
        Console.Write(" ");
}

Console.WriteLine();

// Print the results
Console.WriteLine("Let's count the occurrence of each event:");
Console.WriteLine($"\"Sweet\" was counted {sweetCount} {(sweetCount == 1 ? "time" : "times")}.");
Console.WriteLine($"\"Salty\" was counted {saltyCount} {(saltyCount == 1 ? "time" : "times")}.");
Console.WriteLine($"\"Sweet'nSalty\" was counted {sweetSaltyCount} {(sweetSaltyCount == 1 ? "time" : "times")}.");