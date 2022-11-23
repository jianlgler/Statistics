# HOMEWORK 08

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
  
    
# Box-Muller Trasform and Marsaglia Polar Method

To change coordinates we used the following formulas (referring to the first application):

$$
x = r \cos (\theta)
$$ 

and 

$$
y = r \sin (\theta) 
$$

The polar coordinates are generated through a Random object, which return a double that falls inside $[0, 360°]$ for the angle and inside $[0, radius]$ for the module.
We can notice that X and Y's distributions have a so-called bell shape...they resemble two normal distributions!
This is because we are simulating something that is very similar to a Box–Muller transform [^1]:  it is a random number sampling method for generating pairs of independent, standard, normally distributed random numbers, given a source of uniformly distributed random numbers.
Suppose $U_1, U_2$ as independent samples chosen from the uniform distribution on the unit interval (0, 1):

$$
Z_0 = R \cos (\Theta) = \sqrt {-2\ln U_1} {\cos 2\pi U_2}
$$

and

$$
Z_1 = R \sin (\Theta) = \sqrt {-2\ln U_1} {\sin 2\pi U_2}
$$

Then $Z_0$ and $Z_1$ are independent random variables with a standard normal distribution.
The difference we notice between our method and the Box-Muller method is that we obtain by the following formula: $R = rU_1$ instead of $R = \sqrt {-2\ln U_1}$

The polar form of this method is called the Marsaglia Polar Method[^2]: again we use two uniform random variables $U_1$ and $U_2$ generate two normal random variables $X$  and $Y$. 
The polar method works by sampling random points (u, v) in the square −1 < x < 1, −1 < y < 1 until

$$
0 < s = u^2 + v^2 < 1
$$

We now identify the value of $s$ with that of $U_1$ and ${\theta\over 2\pi}$ with that of $U_2$ in the basic form. 
The values $\cos \theta = \cos{2\pi U_2}$ and $\sin \theta = \sin{2\pi U_2}$ in the basic form can be replaced with the ratios $\cos \theta = \frac{u}{R} = \frac{u}{\sqrt s}$ and $\sin \theta = \frac{v}{R} = \frac{v}{\sqrt s}$, respectively. 
The advantage is that calculating the trigonometric functions directly can be avoided. This is helpful when trigonometric functions are more expensive to compute than the single division that replaces each one.

Finally we obtain: 

$$
Z_0 = \sqrt {-2\ln U_1} {\cos 2\pi U_2} = \sqrt {-2\ln s}(\frac{u}{\sqrt s}) = u \sqrt{\frac{-2 \ln s}{s}}
$$

and 

$$
Z_1 = \sqrt {-2\ln U_1} {\sin 2\pi U_2} = \sqrt {-2\ln s}(\frac{v}{\sqrt s}) = v \sqrt{\frac{-2 \ln s}{s}}
$$

# First App

Here's an application that generate random polar coordinates, transpose them into cartesians, plot them in a chart and plot X and Y variable's distrubions on the side: 

![image](https://user-images.githubusercontent.com/74598295/203375793-976c9db2-cb65-48b6-9534-f468c3c352a6.png)

![image](https://user-images.githubusercontent.com/74598295/203375881-f33c4348-cc31-4218-873b-b1803f9e8156.png)

Code's avaible on GitHub or [Drive](https://drive.google.com/file/d/1MffYJjZ6b9x9Gf9SZY43FZQRpekpmgNL/view?usp=share_link)

# Derivates of the Normal Distribution

In statistics, a normal distribution or Gaussian distribution is a type of continuous probability distribution for a real-valued random variable. The general form of its probability density function is:

$$
f(x) = \frac{1}{\sigma\sqrt {2\pi}}e^{\frac{1}{2}(\frac{x - \mu}{\sigma})^2}
$$

The parameter $\mu$  is the mean or expectation of the distribution, while the parameter \sigma is its standard deviation. The variance of the distribution is $\sigma ^{2}$. A random variable with a Gaussian distribution is said to be normally distributed, and is called a normal deviate.

Normal distributions are important in statistics and are often used in the natural and social sciences to represent real-valued random variables whose distributions are not known. Their importance is partly due to the central limit theorem[^3]. It states that, under some conditions, the average of many samples (observations) of a random variable with finite mean and variance is itself a random variable—whose distribution converges to a normal distribution as the number of samples increases[^4]. Therefore, physical quantities that are expected to be the sum of many independent processes, such as measurement errors, often have distributions that are nearly normal. We can say that most kinds of variables in natural and social sciences are normally or approximately normally distributed.
Moreover, Gaussian distributions have some unique properties that are valuable in analytic studies. For instance, any linear combination of a fixed collection of normal deviates is a normal deviate.

## Standard Normal Distribution

The simplest case of a normal distribution is known as the standard normal distribution or unit normal distribution. This is a special case when $\mu = 0$ and $\sigma =1$, and it is described by this probability density function (or density):

$$
\phi(z) = \frac{e^{-z^2\over 2}}{\sqrt{2\pi}}
$$

The variable $z$ has a mean of 0 and a variance and standard deviation of 1. The density $\phi (z)$ has its peak $1/{\sqrt {2\pi }}$ at $z=0$ and inflection points at $z = +1$ and $z = -1$.

### Generalization and Notation

Every normal distribution is a version of the standard normal distribution, whose domain has been stretched by a factor $\sigma$ (the standard deviation) and then translated by $\mu$ (the mean value):

$$
f(x | \mu, \sigma^2) = {1 \over\sigma}\phi(\frac{x - \mu}{\sigma})
$$

The probability density must be scaled by $1/\sigma$  so that the integral is still 1.
If $Z$ is a standard normal deviate, then $ X=\sigma Z+\mu$ will have a normal distribution with expected value $\mu$  and standard deviation $\sigma$. This is equivalent to saying that the "standard" normal distribution $Z$ can be scaled/stretched by a factor of $\sigma$ and shifted by $\mu$ to yield a different normal distribution, called $X$. Conversely, if $X$ is a normal deviate with parameters $\mu$ and $\sigma ^{2}$, then this $X$ distribution can be re-scaled and shifted via the formula $Z=\frac{(X-\mu )}{\sigma}$ to convert it to the "standard" normal distribution. This variate is also called the standardized form of $X$.

The normal distribution is often referred to as $N(\mu, \sigma^2)$. Thus when a random variable $X$ is normally distributed with mean $\mu$ and standard deviation $\sigma$, one may write $X \sim N(\mu, \sigma^2)$

### De Moivre-Laplace Theorem

The de Moivre–Laplace theorem states that the normal distribution may be used as an approximation to the binomial distribution under certain conditions[^5]. In particular, the theorem shows that the probability mass function of the random number of "successes" observed in a series of $n$ independent Bernoulli trials, each having probability $p$ of success (a binomial distribution with $n$ trials), converges to the probability density function of the normal distribution with mean $np$ and standard deviation ${\sqrt {np(1-p)}}$, as $n$ grows large, assuming $p$ is not 0 or 1.

This is one derivation of the particular Gaussian function used in the normal distribution.

As $n$ grows large, for $k$ in the neighborhood of $np$ we can approximate:

$$
{n\choose k}p^{k}q^{n-k}\simeq{\frac{1}{\sqrt{2\pi npq}}}\,e^{-{\frac{(k-np)^{2}}{2npq}}},\qquad p+q=1,\ p,q>0
$$

in the sense that the ratio of the left-hand side to the right-hand side converges to 1 as $n → ∞$

### Gaussian Functions

In mathematics, a Gaussian function, often simply referred to as a Gaussian, is a function of the form

$$
f(x) = ae^(-\frac{(x-b)^2}{2c^2})
$$

for arbitrary real constants a, b and non-zero c.

[^1]: Wikipedia, Box-Muller Transform: https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
[^2]: Wikipedia, Marsaglia Polar Method: https://en.wikipedia.org/wiki/Marsaglia_polar_method
[^3]: Wikipedia, Central Limit Theorem: https://en.wikipedia.org/wiki/Central_limit_theorem
[^4]: Wikipedia, Normal Distribution: https://en.wikipedia.org/wiki/Normal_distribution
[^5]: Wikipedia, De Moivre-Laplace Theorem: https://en.wikipedia.org/wiki/De_Moivre%E2%80%93Laplace_theorem
[^6]: Wikipedia, Gaussian Function: https://en.wikipedia.org/wiki/Gaussian_function
