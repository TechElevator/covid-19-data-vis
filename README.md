
## COVID-19 Data Visualization

The goal of this project is to visualize the data that is being aggregated by external sources about COVID-19.


### Overview

Visualizing data is often the best way to convey information to your audience. By taking on this project, you will become familiar with:

- Retrieving and manipulating data from an external API.
	- Typically data that you gather, whether that be from your own database or from an external source, is in a different structure than you want it in. Furthermore, the data may require additional calculations or aggregation to be performed against it.
- Reading and understanding external documentation
	- When utilizing code from an external source, you will often encounter documentation describing what the code is for and how to use it. Becoming familiar with the norms of documentation and code itself is a skill that takes repetition. Meaning, the more that you use external code, the easier it becomes to use external code. 
- Data visualization using JavaScript
 
### Prerequisites

**COVID-19 Data API**

[COVID-19 API](https://documenter.getpostman.com/view/10808728/SzS8rjbc?version=latest) - A publicly available API providing statistics for COVID-19.

**Data Visualization JavaScript Libraries**

[Chart.js](https://www.chartjs.org/) - Simple yet flexible JavaScript charting for designers & developers.

[D3js](https://d3js.org/) - A JavaScript library for advanced-level creative coding and data visualization.


### Sample Ideas
In the folder, [samples](samples), we have provided a number of visualizations for you to use as a reference or even to mimic.

Here are some examples of what you may do:

- A table displaying the case data by country.
	- Other options that you could layer on this idea:
		- The number of cases per 1 million in population.
		- Order by most cases to least.
		- Allow for sorting of any column in the table.
- A chart of the total number of cases over time for a given country.
	- Other options that you could layer on this idea:
		- Toggle the country data that displays on the chart via a drop down list.
		- Display the number of cases (y-axis) using a logarithmic scale. [Example](samples/total-cases-usa-logarithmic.png)
- A chart of the number of active cases over time for a given country. [Example](samples/active-cases.png)
- A pie chart comparing the top 20 or so countries affected by COVID-19. [Example](samples/case-distribution.png)
- A 7 day moving average of the daily new cases across the world. [Example](samples/7-day-average-new-cases.png)
- Outcome (recovery or death) of closed cases over time. [Example](samples/outcome-closed-cases.png)