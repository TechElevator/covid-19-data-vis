<template>
  <div class="card">
    <div class="card-content" v-if="loaded">
      <line-chart :chartdata="chartdata" :options="options" />
    </div>
  </div>
</template>

<script>
import LineChart from "./LineChart.vue";

export default {
  name: "RecoveredDeathsChart",
  components: { LineChart },
  data: () => ({
    loaded: false,
    chartdata: null,
    options: null
  }),
  props: {
    country: {
      type: String,
      default: ''
    }
  },
  methods: {
    getDateLabel: function(timeStamp) {
      const date = new Date(timeStamp);
      const months = { 
        "1": "Jan", 
        "2": "Feb", 
        "3": "Mar", 
        "4": "Apr", 
        "5": "May", 
        "6": "Jun",
        "7": "Jul", 
        "8": "Aug", 
        "9": "Sep", 
        "10": "Oct", 
        "11": "Nov",
        "12": "Dec"
      };
      return months[date.getMonth() + 1] + " " + (date.getDate() + 1);
    },
    getPercentage: function (curr, total) {
      return ((curr / total) * 100).toFixed(2);
    },
    loadData: function (country) {
      this.loaded = false;
      if(!country) return;

      try {
        fetch("https://api.covid19api.com/live/country/" + country + "/status/active")
          .then(response => response.json())
          .then(summaryData => {
            const filteredSummaryData = summaryData
              .map(sd => {
                return {
                  Date: sd.Date,
                  Deaths: sd.Deaths,
                  Recovered: sd.Recovered,
                };
              })
              .reduce((rv, x) => {
                const item = rv.find(i => i.Date === x.Date);
                if(item) {
                  item.Deaths += x.Deaths
                  item.Recovered += x.Recovered
                } else {
                  rv.push(x);
                }
                return rv;
              }, []);

            this.chartdata = {
              labels: filteredSummaryData.map(sd => this.getDateLabel(sd.Date)),
              datasets: [
                {
                  fill: false,
                  borderColor: 'green',
                  label: "Recovery Rate",
                  data: filteredSummaryData.map(sd => {
                    const casesUpToThisDate = filteredSummaryData.filter(sd2 => sd2.Date <= sd.Date);
                    const totalRecoveredAtThisDate = casesUpToThisDate.reduce((a, b) => a + b.Recovered, 0);
                    const totalDeathsAtThisDate = casesUpToThisDate.reduce((a, b) => a + b.Deaths, 0);
                    const totalCasesAtThisDate = totalDeathsAtThisDate + totalRecoveredAtThisDate;
                    
                    return this.getPercentage(totalRecoveredAtThisDate, totalCasesAtThisDate);
                  })
                },
                {
                  fill: false,
                  borderColor: 'red',
                  label: "Death Rate",
                  data: filteredSummaryData.map(sd => {
                    const casesUpToThisDate = filteredSummaryData.filter(sd2 => sd2.Date <= sd.Date);
                    const totalRecoveredAtThisDate = casesUpToThisDate.reduce((a, b) => a + b.Recovered, 0);
                    const totalDeathsAtThisDate = casesUpToThisDate.reduce((a, b) => a + b.Deaths, 0);
                    const totalCasesAtThisDate = totalDeathsAtThisDate + totalRecoveredAtThisDate;
                    
                    return this.getPercentage(totalDeathsAtThisDate, totalCasesAtThisDate);
                  })
                }
              ]
            };
            this.options = {
              responsive: false,
              maintainAspectRatio: false
            };
            this.loaded = true;
          });
      } catch (e) {
        console.error(e);
      }
    }
  },
  async mounted() {
    this.loadData(this.country);
  }, 
  watch: {
    country: function (newCountry) {
      this.loadData(newCountry);
    }
  },
};
</script>

<style>
  #line-chart {
    width: 100% !important;
    height: 100% !important;
  }
</style>