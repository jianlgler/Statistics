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

# First App

Here's an application that generate random polar coordinates, transpose them into cartesians, plot them in a chart and plot X and Y variable's distrubions on the side: 

![image](https://user-images.githubusercontent.com/74598295/203375793-976c9db2-cb65-48b6-9534-f468c3c352a6.png)

![image](https://user-images.githubusercontent.com/74598295/203375881-f33c4348-cc31-4218-873b-b1803f9e8156.png)

Code's avaible on GitHub or [Drive](https://drive.google.com/file/d/1MffYJjZ6b9x9Gf9SZY43FZQRpekpmgNL/view?usp=share_link)

To change coordinates we used the following formulas:

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

A derivation of this formula is the Marsaglia Polar Method, which allows us to transform 

[^1]: Wikipedia, Box-Muller Transform: https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
