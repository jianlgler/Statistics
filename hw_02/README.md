# HOMEWORK 02

# What's a Distribution?

The distribution of a variable is a description of the relative numbers of times each possible outcome will occur in a number of trials. The function describing the probability that a given value will occur is called the probability density function (abbreviated PDF), and the function describing the cumulative probability that a given value or any value smaller than it will occur is called the distribution function (or cumulative distribution function, abbreviated CDF)[^1].

Formally, a distribution can be defined as a normalized measure, and the distribution of a random variable x is the measure P_x on S^' defined by setting


The distribution of a variable is a description of the relative numbers of times each possible outcome will occur in a number of trials. The function describing the
probability that a given value will occur is called the probability density function (abbreviated PDF), and the function describing the cumulative probability that a given value or any value smaller than it will occur is called the distribution function (or cumulative distribution function, abbreviated CDF).

Formally, a distribution can be defined as a normalized measure, and the distribution of a random variable x is the measure P_x on S^ defined by setting 
![alt text](https://mathworld.wolfram.com/images/equations/StatisticalDistribution/NumberedEquation1.svg)
where (S, S^, P) is a probability space, (S, S^) si a measurable space, and P a measure on S^ with P(S) = 1. If the measure is a Radon measure (which is usually the case), then the statistical distribution is a generalized function in the sense of a generalized function[^2].

[^1]: WolframAlpha, Statistical Distribution: https://www.wolframalpha.com/entities/mathworld/statistical_distribution/5k/4v/44/
[^2]: Wolfram MathWorld, Statistical Distribution: https://mathworld.wolfram.com/StatisticalDistribution.html

## Univariate Distribution

In statistics, a univariate distribution is a probability distribution of only one random variable. This is in contrast to a multivariate distribution, the probability distribution of a random vector (consisting of multiple random variables).
One of the simplest examples of a discrete univariate distribution is the discrete uniform distribution, where all elements of a finite set are equally likely. It is the probability model for the outcomes of tossing a fair coin, rolling a fair die, etc. The univariate continuous uniform distribution on an interval [a, b] has the property that all sub-intervals of the same length are equally likely[^3]. 
At least 750 univariate discrete distributions have been reported in the literature[^4], examples include the binomial, geometric, negative binomial, and Poisson distributions[^5].
Examples of commonly applied continuous univariate distributions[^6] include the normal distribution, Student's t distribution, chisquare distribution, F distribution, exponential and gamma distributions.

[^3]: Wikipedia, Univariate Distribution: https://en.wikipedia.org/wiki/Univariate_distribution
[^4]: Wimmer G, Altmann G (1999) Thesaurus of univariate discrete probability distributions
[^5]: Johnson, N.L., Kemp, A.W., and Kotz, S. (2005) Discrete Univariate Distributions
[^6]: Johnson N.L., Kotz S, Balakrishnan N. (1994) Continuous Univariate Distributions Vol 1. Wiley Series in Probability and Statistics

## Multivariate Distribution

Multivariate distributions show comparisons between two or more measurements and the relationships among them. For each univariate distribution with one random variable, there is a more general multivariate distribution. For example, the normal distribution is univariate and its more general counterpart is the multivariate normal distribution. While the multivariate normal model is the most commonly used model for analyzing multivariate data [^7], there are many more: the multivariate lognormal distribution, the multivariate binomial distribution, and so on.
A bivariate distribution is the simplest multivariate distribution, comprised of one pair of random variables. However, theoretically at least, you could have an infinite number of pairs; all results from a bivariate distribution for two pairs can be generalized to n random variables.

[^7]: Engineering Statistics Handbook: The Multivariate Normal Distribution. Retrieved November 11, 2021 from: https://www.itl.nist.gov/div898/handbook/pmc/section5/pmc542.htm

## Conditional Distribution

A conditional distribution is a distribution of values for one variable that exists when you specify the values of other variables. This type of distribution allows you to assess the dispersal of your variable of interest under specific conditions, hence the name[^8].

In probability theory and statistics, given two jointly distributed random variables X and Y, the conditional probability distribution of Y given X is the probability distribution of Y when X is known to be a particular value. When both X and Y are categorical variables, a conditional probability table is typically used to represent the conditional probability. The conditional distribution contrasts with the marginal distribution of a random variable, which is its distribution without reference to the value of the other variable. More generally, one can refer to the conditional distribution of a subset of a set of more than two variables; this conditional distribution is contingent on the values of all the remaining variables, and if more than one variable is included in the subset then this conditional distribution is the conditional joint distribution of the included variables[^9].

## Marginal Distribution

In probability theory and statistics, the marginal distribution of a subset of a collection of random variables is the probability distribution of the variables contained in the subset. It gives the probabilities of various values of the variables in the subset without reference to the values of the other variables. This contrasts with a conditional distribution, which gives the probabilities contingent upon the values of the other variables.
The distribution of the marginal variables (the marginal distribution) is obtained by marginalizing (that is, focusing on the sums in the margin) over the distribution of the variables being discarded, and the discarded variables are said to have been marginalized out.

The context here is that the theoretical studies being undertaken, or the data analysis being done, involves a wider set of random variables but that attention is being limited to a reduced number of those variables. In many applications, an analysis may start with a given collection of random variables, then first extend the set by defining new ones (such as the sum of the original random variables) and finally reduce the number by placing interest in the marginal distribution of a subset (such as the sum). Several different analyses may be done, each treating a different subset of variables as the marginal variables[^10].

For example: 
  Suppose that the probability that a pedestrian will be hit by a car, while crossing the road at a pedestrian crossing, without paying attention to the traffic light, is to be computed. Let H be a discrete random variable taking one value from {Hit, Not Hit}. Let L (for traffic light) be a discrete random variable taking one value from {Red, Yellow, Green}.

Realistically, H will be dependent on L. That is, P(H = Hit) will take different values depending on whether L is red, yellow or green (and likewise for P(H = Not Hit)). A person is, for example, far more likely to be hit by a car when trying to cross while the lights for perpendicular traffic are green than if they are red. In other words, for any given possible pair of values for H and L, one must consider the joint probability distribution of H and L to find the probability of that pair of events occurring together if the pedestrian ignores the state of the light.

However, in trying to calculate the marginal probability P(H = Hit), what is being sought is the probability that H = Hit in the situation in which the particular value of L is unknown and in which the pedestrian ignores the state of the light. In general, a pedestrian can be hit if the lights are red OR if the lights are yellow OR if the lights are green. So, the answer for the marginal probability can be found by summing P(H | L) for all possible values of L, with each value of L weighted by its probability of occurring.


[^8]: Conditional Distribution, Definition & Finding, Jim Frost: https://statisticsbyjim.com/basics/conditional-distribution/
[^9]: Wikipedia, Conditional probability distribution: https://en.wikipedia.org/wiki/Conditional_probability_distribution
[^10]: Wikipedia, Marginal distribution: https://en.wikipedia.org/wiki/Marginal_distribution
