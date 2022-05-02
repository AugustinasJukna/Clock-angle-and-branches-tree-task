using System;

//Author: Augustinas Jukna
namespace reiz_tech
{
    internal class Program
    {

        //First task
        static void FirstTask(int hours, int minutes)
        {
            double degreesPerHour = 360 / 12;
            double degreesPerMinute = 360 / 60;
            if (hours > 12)
            {
               hours -= 12;
            }

            double hoursDegree = (double) hours * degreesPerHour;
            if (minutes > 0) //Calculates the hour hand's position
            {
                hoursDegree += (double) (1 / (60 / (double) minutes)) * degreesPerHour;
            }


            double difference = Math.Abs(hoursDegree  - minutes * degreesPerMinute);
            if (difference > 180) //Makes sure that the smaller angle is calculated
            {
                difference = 360 - difference;
            }
            Console.WriteLine(String.Format("The angle is {0}", difference));


        }
        static void Main(string[] args)
        {
            FirstTask(12, 15);

            Branch exampleTree = Branch.RecreateExampleStructure();
            Console.WriteLine(String.Format("Example tree height: {0}", exampleTree.CalculateHeight()));

            Branch testTree = Branch.TestingTree(20);
            //Given parameter should be equal to the output 
            Console.WriteLine(String.Format("Test tree height: {0}", testTree.CalculateHeight()));


        }
    }

}