using System;


//
// ExponentialDistribution implements an exponential distribution.
// Exponentially distributed variables are often use to model the time interval between customers entering a system.
// 
// 
// The algorithm is based on the WikiPedia mathematical model using the inversion method
//
// LAMBDA is the rate paramater: how many events per unit of time
// X is a random variable [0,1]
// 1 / LAMBDA represents the average time interval between events
//
// Y = LOG ( 1- X ) / -LAMBDA
//
// See http://en.wikipedia.org/wiki/Exponential_distribution
//

class ExponentialDistribution
{
    protected Random randomVariable;            // Random Variable
    internal const int seedDefault = 12;        // Default seed for the random variable
    internal const double lambdaDefault = 1;    // Default value for lambda
    protected double lambda;                    // Represents the rate at which events happens. 
                                                // Ex: if Lambda=5, on average we would get 5 events per unit of time  

    

    // Constructor using default seed value for the random variable and a default lambda value
    public ExponentialDistribution(double lambda=lambdaDefault, int seed=seedDefault)
    {
        this.randomVariable = new Random(seed);
        this.lambda = lambda;
    }

    // Returns the next value of the exponential distribution using a random variable
    public double Next()
    {
        return Math.Log(1 - this.randomVariable.NextDouble()) / -this.lambda;
    }

    // Method to sample the distribution, generates the distribution and fill the array
    public void Samples(out double[] exponentialArray, int totalNumber)
    {
        exponentialArray = new double[totalNumber];

        for (int i = 0; i < totalNumber; i++)
        {
            
            exponentialArray[i] = this.Next();

        }
         
    }

}

