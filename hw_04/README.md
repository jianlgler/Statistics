# HOMEWORK 04

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


# Parallels between relative frequency and the axioms for probability

Andrey Kolmogorov was a Russian mathematician. In 1933, he contribuited to probability theory introducing his axioms: they are known today as probability theory fundamentals by the name of Kolmogorov axioms[^1].

## First Axiom

The probability of an event is a non-negative real number:
$$P(E)\in\mathbb{R}, \quad P(E)\ge0 \quad \forall \ E\in F$$

where $F$ is the event space. It follows that $P(E)$ is always finite, in contrast with more general measure theory. 

## Second Axiom

This is the assumption of unit measure: that the probability that at least one of the elementary events in the entire sample space will occur is 1
\\[P(&Omega;) = 1\\]

## Third Axiom
This is the assumpion of σ-additivity:
  Any countable sequence of disjoint sets $E_1, E_2,...$ satisfies
  $$P(\bigcup_{i=1}^{\infty}E_i)= \sum_{i=1}^{\infty} P(E_i)$$

We can find parallels of these axioms in relative frequency, let define $A$ and $B$ as events: 
1. $0\leq f_A \leq 1$
2. $f(\emptyset)=0$ and $f(Population)=1$
3. $f_{A \cup B} = f_A + f_B - f_{A \cap B}$, where $f_{A \cap B} = 0$ if $A$ and $B$ are disjointed


These parallels could find explaantion in the so called "frequentist definition[^2]" of probability, which claims that the probability of a random event denotes the relative frequency of occurrence of an experiment's outcome when the experiment is repeated indefinitely. This interpretation considers probability to be the relative frequency "in the long run" of outcomes. 
(**REMEMBER**: multiple definition of probability were be given throughout the time)

[^1]: Wikipedia, Probability Axioms: https://en.wikipedia.org/wiki/Probability_axioms
[^2]: Wikipedia, Probability: https://en.wikipedia.org/wiki/Probability

# Example of a Probability Measure Space

We indicate a probability space with a triplet (&Omega;, &epsilon;, P), where **&Omega;** is a sample space, **&epsilon;** is a &sigma;-algebra of events and **P** is probability measure. **(_Explanation for this in the next section_)**

## Think about tossing a coin: 

$\Omega = \\{ T, H \\} $

$\epsilon = \\{ \Omega, \emptyset , T, H, \bar{T}, \bar{H}, T \cup H, T \cap H \\} $

## Other examples:

• Positive integers: Ω = {1, 2, 3, . . . }

• Two tosses of a coin: Ω = {HH, HT , TH, T T}

# Measure Theory as Foundation of Probability Theory

Probability Theory finds its foundation in Measure Theory[^3]:

First let's introduce the concept of σ-algebra[^4]: in mathematical analysis and in probability theory, a σ-algebra on a set X is a nonempty collection Σ of subsets of X closed under complement, countable unions, and countable intersections.

Let now $X$ be a set and $\Sigma$  a $\sigma$ -algebra over $X$. A set function $\mu$  from $\Sigma$  to the extended real number line is called a measure if it satisfies the following properties:

**Non-negativity**: For all $E$ in $\Sigma$ , we have $\mu (E)\geq 0$.

**Null empty set**: $\mu (\varnothing )=0$.

**Countable additivity** (or $\sigma$ -additivity): For all countable collections $\\{ E_{k}\\}$ of pairwise disjoint sets in $\Sigma$,

$$\mu \left(\bigcup_{k=1}^{\infty }E_{k}\right)=\sum_{k=1}^{\infty }\mu (E_{k}).$$

If at least one set $E$ has finite measure, then the requirement that $\mu (\varnothing )=0$ is met automatically. Indeed, by countable additivity,

$$\mu (E)=\mu (E\cup \varnothing )=\mu (E)+\mu (\varnothing ),$$

and therefore $\mu (\varnothing )=0$.

If the condition of non-negativity is omitted but the second and third of these conditions are met, and $\mu$  takes on at most one of the values $\pm \infty$  then $\mu$  is called a signed measure.

The pair $(X,\Sigma )$ is called a measurable space, and the members of $\Sigma$ are called measurable sets.

A triple $(X,\Sigma ,\mu )$ is called a measure space. A probability measure is a measure with total measure one – that is, $\mu (X)=1$. A probability space is a measure space with a probability measure.

[^3]: Wikipedia, Measure (Mathematics): https://en.wikipedia.org/wiki/Measure_(mathematics)
[^4]: Wikipedia, σ-algebra: https://en.wikipedia.org/wiki/%CE%A3-algebra
