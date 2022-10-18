
# HOMEWORK 03

# Conditional Frequency

In a contingency table (sometimes called a two way frequency table), conditional frequency is a fraction that tells you how many members of a group have a particular characteristic. More technically, it is the ratio of a frequency in the center of the table to the frequency’s row total or column total[^1]. 
To be clearer, a conditional distribution is a univariate distribution, composed by its frequency, built on the costraint of a value. 
It refers to a subset of the whole population.

# Joint Frequency

In a bivariate distribution, given the variables X and Y, the joint frequency represents the number of statistical units which have X_i value and Y_j value at the same time. 
To simplify: A joint frequency is how many times a combination of two conditions happens together. For example a dog owner who is also a woman[^2].

# Marginal Frequency 

It is the ratio between the frequency of a row total or column total to the total frequency of the data. It is commonly used to analyze general trends in one specific category of data[^3].
To simplify: A marginal frequency can be calculated by dividing a row total or a column total by the total frequency of the data[^4].

[^1]: Statistics How To: Conditional Relative Frequency: https://www.statisticshowto.com/conditional-relative-frequency/
[^2]: Statistics How To , Joint Frequency, https://www.statisticshowto.com/joint-frequency/#:~:text=What%20is%20Joint%20Frequency%3F,of%20two%20conditions%20happens%20together.
[^3]: Study: https://study.com/learn/lesson/conditional-joint-marginal-relative-frequency-overview-comparison-examples.html
[^4]: onlinemath4all: how to calculate marginal relative frequency: https://www.onlinemath4all.com/how-to-calculate-marginal-relative-frequency.html

# Statistical Indipendence 

To discuss about the concept of independence between two variables (X, Y) we must refer to bivariate distributions. 
In a contingency table, we look at the univariate conditional distribution: significant changes among conditional distributions with a changing variable's value means strong correlation. To simplify: if the conditional distributions has different graphs we can say that the two variables X and Y are dependant.
However, if the shape of the graph are similar (or equal), we can say that there are no correlation between the variables. If this happens, conditional distributions are equal to each other, and also to the marginal one.

We can transpose this definition to frequencies.
Formally: given two variable X and Y, they are indipendent if for each i, Freq(X_i, Y_j) are equal for every j.
So they are also equal to the marginal Freq(X_i). 
Numerically: 

  | N_i_j/N_+_j == N_i_+/N | N_i_j/N_i_+ == N_+_j/N |
  
These two formulas lead to | N_i_j x N == N_i_+ x N_+_j |
  

