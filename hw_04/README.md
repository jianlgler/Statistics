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

# HOMEWORK 04

# Parallels between relative frequency and the axioms for probability

Andrey Kolmogorov was a Russian mathematician. In 1933, he contribuited to probability theory introducing his axioms: they are known today as probability theory fundamentals by the name of Kolmogorov axioms.

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
3. $f_{A \cup B} = f_A + f_B $ - f_{A \cap B}$, where $f_{A \cap B} = 0$ if $A$ and $B$ are disjointed
