using System;

// Defining a class to represent a Circle
public class Circle
{
    // Properties for radius, x-coordinate, and y-coordinate
    public double Radius { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    // Constructor to initialize properties
    public Circle(double radius, double x, double y)
    {
        Radius = radius;
        X = x;
        Y = y;
    }

    // Method to calculate area of the circle
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    // Method to calculate perimeter of the circle
    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    // Method to check if a point (x, y) is inside the circle
    public bool IsPointInside(double x, double y)
    {
        double distance = Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));
        return distance <= Radius;
    }
}

// Define a class to manage operations related to circles
public class CircleManager
{
    // Method to create an array of circles based on user input
    public static Circle[] CreateCircles(int numberOfCircles)
    {
        Circle[] circles = new Circle[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            Console.WriteLine($"Enter the radius for circle {i + 1}:");
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the x-coordinate for circle {i + 1}:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the y-coordinate for circle {i + 1}:");
            double y = double.Parse(Console.ReadLine());

            circles[i] = new Circle(radius, x, y);
        }
        return circles;
    }

    // Method to print information of each circle
    public static void PrintCircleInfo(Circle circle)
    {
        Console.WriteLine($"Circle with radius {circle.Radius}, area: {circle.CalculateArea()}, perimeter: {circle.CalculatePerimeter()}");
    }

    // Method to check if a point is inside each circle and print the result
    public static void CheckPointInCircles(double x, double y, Circle[] circles)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            bool inside = circles[i].IsPointInside(x, y);
            Console.WriteLine($"Point ({x}, {y}) {(inside ? "is" : "is not")} inside circle {i + 1}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Asking user for the number of circles
        Console.WriteLine("Enter the number of circles:");
        int numberOfCircles = int.Parse(Console.ReadLine());

        // Creating circles based on user input
        Circle[] circles = CircleManager.CreateCircles(numberOfCircles);

        // Printing information of each circle
        Console.WriteLine("Circle information:");
        foreach (Circle circle in circles)
        {
            CircleManager.PrintCircleInfo(circle);
        }

        // Asking user for a point to check if it is inside the circles
        Console.WriteLine("Enter a point (x y) to check if it is inside the circles:");
        string[] point = Console.ReadLine().Split(' ');
        double x = double.Parse(point[0]);
        double y = double.Parse(point[1]);

        // Checking if the point is inside each circle and print the result
        CircleManager.CheckPointInCircles(x, y, circles);
    }
}
