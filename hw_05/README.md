
<script type="text/x-mathjax-config">
    MathJax.Hub.Config({
      tex2jax: {
        skipTags: ['script', 'noscript', 'style', 'textarea', 'pre'],
        inlineMath: [['\\(','\\)'], ['$', '$']],
        displayMath: [ ['$$','$$'], ["\\[","\\]"] ],
      }
    });
  </script>
  <script src="https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML" type="text/javascript"></script>


# HOMEWORK 05

# Arithmetic Mean: Derivations and Generalization

In mathematics and statistics, the arithmetic mean is the sum of a collection of numbers divided by the count of numbers in the collection[^1].
Its formula is: 
    $$(1/n)*\sum_{i=1}^{n }\ a_{i}$$

The arithmetic mean is the most commonly used and readily understood measure of central tendency in a data set. In statistics, the term average refers to any of the measures of central tendency. Actually mean functions tend to represent the whole set of values with a single number...its about synthesis of the population.
Arithmetic mean is just one of the many different function used to analyze distriubtion and with it follow some derivations:

## Geometric Mean

The geometric mean is a mean or average which indicates a central tendency of a set of numbers by using the product of their values [^2] (as opposed to the arithmetic mean which uses their sum). The geometric mean is defined as the nth root of the product of n numbers, i.e., for a set of numbers x1, x2, ..., xn, the geometric mean is defined as  
    $$(\prod_{i=1}^{n} x_1)^{1/n}=\sqrt[n]{x_1 x_2 ... x_n}$$

## Harmonic Mean

It's one of several kinds of average. It is sometimes appropriate for situations when the average rate is desired.
The harmonic mean can be expressed as the reciprocal of the arithmetic mean of the reciprocals of the given set of observations[^3]. 
    $$H = \frac{n}{\frac{1}{x_1}+\frac{1}{x_2}+...+\frac{1}{x_n}}$$
    
## Weighted Arithmetic Mean

The weighted arithmetic mean is similar to an ordinary arithmetic mean (the most common type of average), except that instead of each of the data points contributing equally to the final average, some data points contribute more than others. The notion of weighted mean plays a role in descriptive statistics and also occurs in a more general form in several other areas of mathematics[^4].
     $$(1/n)*\sum_{i=1}^{n }\ w_{i}*a_{i}$$
     
It can be thought as a generalization of the standard arithmetic mean: actually if all the weights are equal, then the weighted mean is the same as the arithmetic mean. 
     
    
[^1]: Wikipedia, Arithmetic Mean: https://en.wikipedia.org/wiki/Arithmetic_mean
[^2]: Wikipedia, Geometric Mean: https://en.wikipedia.org/wiki/Geometric_mean 
[^3]: Wikipedia, Harmonic Mean: https://en.wikipedia.org/wiki/Harmonic_mean
[^4]: Wikipedia, Weighted Arithmetic Mean: https://en.wikipedia.org/wiki/Weighted_arithmetic_mean
