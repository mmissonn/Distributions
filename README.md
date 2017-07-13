# Distributions
Mathematical distributions (self similar and exponential)

CmdLine utility shows examples on how to consume both exponential and self-simuilar distributions classes.

ExponentialDistribution implements an exponential distribution.
Exponentially distributed variables are often use to model the time interval between customers entering a system.
The algorithm is based on the WikiPedia mathematical model using the inversion method

LAMBDA is the rate paramater: how many events per unit of time
X is a random variable [0,1]
1 / LAMBDA represents the average time interval between events

Y = LOG ( 1- X ) / -LAMBDA

See http://en.wikipedia.org/wiki/Exponential_distribution


The SelfSimilarDistribution class implements the Self-Simular (80-20) rule algorithm.
Based on the MS Research paper: Gray, "Quickly Generating Billion-Record Synthetic Databases", p. 23, 2000, ACM

See http://research.microsoft.com/pubs/68246/syntheticdatagen.pdf
 
