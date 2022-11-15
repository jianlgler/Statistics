# HOMEWORK 07


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

# What is the Lebesgue Integral?

The Lebesgue integral plays an important role in probability theory, real analysis, and many other fields in mathematics. It is named after Henri Lebesgue (1875–1941), who introduced the integral in 1904.
The usual definition of the Lebesgue integral has little to do with probability or random variables (though the notions of measure theory and the integral can then be applied to the setting of probability, where under suitable interpretations it will turn out that the Lebesgue Integral of a certain functions corresponds to the expectation of a random variable)[1].
Here is an intuitive idea of what the Lebesgue integral is, as compared to the Riemann integral.
Recall from Calculus the idea behind the Riemann integral: the integral $\int_a^b f(x) \, dx$ is meant to represent the net signed area between the x-axis, the graph of $y=f(x)$, and the lines x=a and x=b. The way we attempt to do this is by breaking up the domain, [a,b], into subintervals $[a=x_0,x_1], [x_1,x_2],…,[x_n−1,x_n=b]$. Then, on each subinterval $[x_i,x_(i+1)]$ we pick a point $p_i$, and we estimate the area under the graph of the function with the rectangle of height $f(p_i)$ and base $[x_i,$ $x_i+1$ $]$. This leads to the Riemann sums

[1]: StackExchange, Lebesque Integral Basics: https://math.stackexchange.com/questions/7436/lebesgue-integral-basics