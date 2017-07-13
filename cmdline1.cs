// 
// Main CmdLine - Examples on how to consume both exponential and self-simuilar distributions objects
//


using System;
using System.Threading;



public class CommandLine
{
   public static void Main(string[] args)
   {

       int N = 100;                     // Number of customers
       double h = 0.20;                 // Percentage ex: 20% of all customers use 80% of the resources(VMs)
       int totalVMs = 50000;            // Total number of VMs

       double[] weightPercentageArray;  // Array to store the percentage of allocation of the resources. 

       // Create a Self-Similar Distribution
       SelfSimilarDistribution selfsimilar = new SelfSimilarDistribution(N,h);

       // Function returns how much weight to allocate resources to a given virtual user
       selfsimilar.Samples(out weightPercentageArray);

       Console.WriteLine("Self-Similar Distribution");
       Console.WriteLine("AllocatedVMs %Allocation Iteration: ");
              
       for (int i = 0; i < N; i++)
       {
           long allocatedVMs = (long)Math.Round((weightPercentageArray[i] * totalVMs));
           
           Console.WriteLine("{0},{1:N3},{2}", allocatedVMs, weightPercentageArray[i]*100, i);
       }


       Console.WriteLine("Press any key to continue...");
       Console.ReadKey(true);
       

       // Create an exponential distribution
       double rate = 5; // On average get 5 events per unit of time (ex: 5 per min). 
       ExponentialDistribution exponentialDistribution = new ExponentialDistribution(rate);

       Console.WriteLine("Exponential Distribution");

       
      
       double[] exponentialArray; // Array to store the exponential random numbers

       exponentialDistribution.Samples(out exponentialArray, N);

       
       for (int i = 0; i < N; i++)
       {
           Console.WriteLine("{0:N9},{1}", exponentialArray[i] * 60, i); // Multiply by 60 to convert in seconds
       }

       Console.WriteLine("Press any key to continue...");
       Console.ReadKey(true);

       // Another example on how to use the exponentialDistribution function
       // Fire an event at rate of 5 events per minutes
       ConsoleKeyInfo cki;
       Console.WriteLine("Fire an event at rate of 5 events per minutes");
       do
       {
           int exponentialRandom = (int) (exponentialDistribution.Next() * 60000); // Multiply by 60000 to convert in milliseconds

           Console.WriteLine("Waiting {0} milliseconds before firing the next event", exponentialRandom);
           
           // Wait for thread
           System.Threading.Thread.Sleep(exponentialRandom); 
           Console.WriteLine("Firing event.");

           Console.WriteLine("Press ESC to stop.");
           cki = Console.ReadKey(true);

       } while (cki.Key != ConsoleKey.Escape);
       
   }

}

