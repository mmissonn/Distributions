using System;

//
// The SelfSimilarDistribution class implements the Self-Simular (80-20) rule algorithm.
// Based on the MS Research paper: Gray, "Quickly Generating Billion-Record Synthetic Databases", p. 23, 2000, ACM
// See http://research.microsoft.com/pubs/68246/syntheticdatagen.pdf
// 
  
public class SelfSimilarDistribution
{
    protected Random randomVariable;            // Random Variable
    protected double exponent;                  // exponent used in the formula : weight = 1 + (long)(N * Math.Pow(rdm, Math.Log(h) / Math.Log(1.0 - h)));
    internal const int seedDefault = 12;        // Default seed for the random variable. Use the same seed when invoking the random function in order to be able to generate the same data as needed.
    internal const double hDefault = 0.20;      // By default assigning 20% to implement a 80-20 rule Ex: 20% of the users would have 80% of the resources allocated.
    protected int totalNumber;                  // Total number of entries. For ex: total number of users in a simulation.

   

    // Constructor with a default value for h, assign 20% to implement a 80-20 rule 
    // Ex: 20% of the users would have 80% of the resources allocated.  
    // Using a default seed value for the random variable
    // N is the total number of entries
    public SelfSimilarDistribution(int N, double h=hDefault, int seed=seedDefault)
    {
        this.totalNumber = N;
        this.exponent = Math.Log(h) / Math.Log(1.0 - h);
        this.randomVariable = new Random(seed);

    }

    // Returns the next weight value of the Self-Similar distribution using a random variable
    public long Next()
    {
        return 1 + (long)(this.totalNumber * Math.Pow(this.randomVariable.NextDouble(), this.exponent));
    }


    // Method to sample the distribution, generates the distribution weights where weigthPercentageArray contains all the percentages
    public void Samples(out double[] weightPercentageArray)
    {
        
        long[] weightArray = new long[this.totalNumber];       // Contains all the weights sampled from the distribution
        weightPercentageArray = new double[this.totalNumber];  // Contains all the percentages of the distribution. Ex: Determines how to allocate resources to a user.

        
        long totalWeight = 0;

        for (int i = 0; i < this.totalNumber; i++)
        {
            long weight = this.Next();
            
            totalWeight = weight + totalWeight;

            weightArray[i] = weight;

        }

        // Calculates the percentage
        for (int i = 0; i < this.totalNumber; i++)
        {
            weightPercentageArray[i] = ((double)((double)weightArray[i] / (double)totalWeight));
                       
        }
    }

    // Method to sample the distribution, generates the distribution weights
    public void Samples(out long[] weightArray)
    {

        weightArray = new long[this.totalNumber];       // Contains all the weights sampled from the distribution
        
        for (int i = 0; i < this.totalNumber; i++)
        {
                              
            weightArray[i] = this.Next();

        }

        
    }
}

