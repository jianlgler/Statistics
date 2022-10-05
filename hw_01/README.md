# What is Statistics?
According to Wikipedia[^1], Statistics is the discipline that concerns the collection, organization, snalisys, interpretation and presentation of data.

In applying statistics to a scientific, industrial or social problem, it is conventional to begin with a statistical population[^2] or a statistical model[^3] to be studied. 

## Is it a science? 
Well, according to a related Quora thread[^4], the standard definition of “science” is “the systematic enterprise that builds and knowledge in the form of testable explanations and predictions about the universe”[^5].

However, the standard view of pure mathematics is that it exists independent of the physical and natural world, and is investigated by logic, rather than observation and experiment, and so we can say that maths is not a science itself, but can be considered an abstraction of reality. 

If we accept this definition of pure mathematics, we can assume that statistics has both some non-scientific pure mathematics and some scientific study. 
For example an introductory statistics course will generally include computation of binomial probabilities under ideal assumption (pure mathematics) and also data analisys: techniques that have been found generally usefull in real application[^6]. 

Most data analysis techniques do have theoretical justifications, which were generally developed after the techniques has been discovered empirically and were in wide practice, and often there are multiple theoretical justifications for the same technique. So someone might claim that the field of statistics is pure mathematics. 

We can conclude by saying that there are different opinions on this topic and so finding a correct answer might be difficoult.

[^1]: Wikipedia, Statistics: https://en.wikipedia.org/wiki/Statistics
[^2]: Wikipedia, Statistical population: https://en.wikipedia.org/wiki/Statistical_population
[^3]: Wikipedia, Statistical model: https://en.wikipedia.org/wiki/Statistical_model
[^4]: Quora, is statistics a science: https://www.quora.com/Is-statistics-a-science
[^5]: Wilson, E.O. (1999). "Consilience: The Unity of Knowledge": https://www.wtf.tw/ref/wilson.pdf
[^6]: Quora, Aaron Brown, MBA in Finance & Statistics (academic discipline), The University of Chicago Booth School of Business: https://qr.ae/pveYYf


# What is a dataset? From the observation units to the dataset attributes and values

The Latin word data is the plural of 'datum', "(thing) given," neuter past participle of dare "to give"[^7][^8].

So data is a collection of discrete values that convey information, describing quantity, quality, fact, statistics, other basic units of meaning, or simply sequences of symbols that may be further interpreted. A datum is an individual state in a set of data. Data usually is organized into structures such as tables that provide additional context and meaning, and which may themselves be used as data in larger structures. They may be used as variables in a computational[^9] process, or represent abstract ideas or concrete measurements[^10]. Data is commonly used in scientific research, finance, and in virtually every other form of human organizational activity. Examples of data sets include stock prices, crime rates, unemployment rates, literacy rates, and census data[^7].

Data, as a general concept, refers to the fact that some existing information or knowledge is represented or coded in some form suitable for better usage or processing and is the smallest units of factual information that can be used as a basis for calculation, reasoning, or discussion. Data can range from abstract ideas to concrete measurements, including but not limited to, statistics. Thematically connected data presented in some relevant context can be viewed as information[^7]. 

Ok so a dataset is a collection of data: it can corresponds to one or more database tables, or any other collection of documents or files[^10].

[^7]: Wikipedia, Dataset: https://en.wikipedia.org/wiki/Data_set
[^8]: Origin and meaning of data by Online Etymology Dictionary, data: https://www.etymonline.com/word/data
[^9]: Australian Bureau of Statistics, "Statistical Language - What are Data?", 2013-07-13: https://www.abs.gov.au/websitedbs/D3310114.nsf/Home/Statistical+Language?OpenDocument
[^10]: Diffen, "Data vs Information - Difference and Comparison": https://www.diffen.com/difference/Data_vs_Information
[^11]: Snijders, C.; Matzat, U.; Reips, U.-D. (2012). "'Big Data': Big gaps of knowledge in the field of Internet". International Journal of Internet Science: https://www.ijis.net/ijis7_1/ijis7_1_editorial.pdf

## What's a so called statistical unit?

In statistics, a unit is one member of a set of entities being studied. It is the main source for the mathematical abstraction of a "random variable". Common examples of a unit would be a single person, animal, plant, manufactured item, or country that belongs to a larger collection of such entities being studied[^12]. 
Units are often referred to as being either experimental units and sampling units (or unit of observation):

- An "experimental unit" is typically thought of as one member of a set of objects that are initially equal, with each object then subjected to one of several experimental treatments. Put simply, it is the smallest entity to which a treatment is applied.

- A "sampling unit" is typically thought of as an object that has been sampled from a statistical population. This term is commonly used in opinion polling and survey sampling.

For example, in an experiment on educational methods, methods may be applied to classrooms of students. This would make the classroom as the experimental unit. Measurements of progress may be obtained from individual students, as observational units. But the treatment (teaching method) being applied to the class would not be applied independently to the individual students. Hence the student could not be regarded as the experimental unit. The class, or the teacher by method combination if the teacher had multiple classes, would be the appropriate experimental unit[^12].

Also, the unit of observation should not be confused with the unit of analysis. A study may have a differing unit of observation and unit of analysis: for example, in community research, the research design may collect data at the individual level of observation but the level of analysis might be at the neighborhood level, drawing conclusions on neighborhood characteristics from data collected from individuals. Together, the unit of observation and the level of analysis define the population of a research enterprise[^13][^14].

[^12]: Wikipedia, Statistical unit: https://en.wikipedia.org/wiki/Statistical_unit
[^13]: Wikipedia, Unit of observation: https://en.wikipedia.org/wiki/Unit_of_observation
[^14]: Blalock, Hubert M., Jr. (1972), Social Statistics: https://archive.org/details/socialstatistic000blal

## Statistical Population

In statistics, a population is a set of similar items or events which is of interest for some question or experiment. A statistical population can be a group of existing objects (e.g. the set of all stars within the Milky Way galaxy) or a hypothetical and potentially infinite group of objects conceived as a generalization from experience (e.g. the set of all possible hands in a game of poker)[^15]. A common aim of statistical analysis is to produce information about some chosen population.[^16]

In statistical inference, a subset of the population (a statistical sample) is chosen to represent the population in a statistical analysis. Moreover, the statistical sample must be unbiased and accurately model the population (every unit of the population has an equal chance of selection). The ratio of the size of this statistical sample to the size of the population is called a sampling fraction. It is then possible to estimate the population parameters using the appropriate sample statistics[^16].

## What is a sample?

In statistics, sampling is the selection of a subset (a statistical sample) of individuals from within a statistical population to estimate characteristics of the whole population. Statisticians attempt to collect samples that are representative of the population in question. Sampling has lower costs and faster data collection than measuring the entire population and can provide insights in cases where it is infeasible to measure an entire population[^17].

Each observation measures one or more properties (such as weight, location, colour or mass) of independent objects or individuals.

## Variables and Attributes

In science and research, an attribute is a quality of an object (person, thing, etc.)[^18]. Attributes are closely related to variables. A variable is a logical set of attributes.[1] Variables can "vary" – for example, be high or low.[^18] How high, or how low, is determined by the value of the attribute (and in fact, an attribute could be just the word "low" or "high")[^19].

While an attribute is often intuitive, the variable is the operationalized way in which the attribute is represented for further data processing. In data processing data are often represented by a combination of items (objects organized in rows), and multiple variables (organized in columns)[^19].

Variables can be classified as qualitative or quantitative.

- Qualitative. The value of a qualitative variable is a name or a label. The color of a ball (e.g., red, green, blue) or the breed of a dog (e.g., collie, shepherd, terrier) would be examples of qualitative or categorical variables[^20].
- Quantitative. The value of a quantitative variable is a number. For example, when we speak of the population of a city, we are talking about the number of people in the city - a numerical attribute of the city. Therefore, population would be a quantitative variable.

In algebraic equations, quantitative variables are represented by symbols (e.g., x, y, or z)[^20].

Random variables can be either observed or expected: for example if we flip a coin N times, we would expect a result about 50 heads and 50 tails, but it might happen to obtain something like 70-30. First ones are expected values and seconds are observed values.   
In conclusion, we can say that observed variables are obtained by performing the experiment and recording (observing) the individual values of the random variable in question[^21].

[^15]: Weisstein, Eric W, "Statistical population": https://mathworld.wolfram.com/Population.html
[^16]: Wikipedia, Statistical Population: https://en.wikipedia.org/wiki/Statistical_population
[^17]: Wikipedia, Sampling (Statistics): https://en.wikipedia.org/wiki/Sampling_(statistics)
[^18]: Earl R. Babbie, The Practice of Social Research, 12th edition, Wadsworth Publishing, 2009: https://en.wikipedia.org/wiki/Earl_Babbie
[^19]: Wikipedia, Variable and Attribute: https://en.wikipedia.org/wiki/Variable_and_attribute_(research)
[^20]: Berman H.B., "Variables in Statistics": https://stattrek.com/descriptive-statistics/variables 
[^21]: Quora, Alex Sadovsky, Studied Mathematics & Biomechanics at University of California, Irvine: https://www.quora.com/What-are-observed-and-expected-values

# Application of Statistics in Cybersecurity
