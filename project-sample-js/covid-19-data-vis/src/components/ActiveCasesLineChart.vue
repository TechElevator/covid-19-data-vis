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
  name: "ActiveCasesLineChart",
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
    loadData: function(country) {
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
                  Active: sd.Active
                };
              })
              .reduce((rv, x) => {
                const item = rv.find(i => i.Date === x.Date);
                if(item) {
                  item.Active += x.Active
                } else {
                  rv.push(x);
                }
                return rv;
              }, []);

            this.chartdata = {
              labels: filteredSummaryData.map(sd => this.getDateLabel(sd.Date)),
              datasets: [
                {
                  backgroundColor: '#add8e6',
                  borderColor: '#003366',
                  label: "Active Cases",
                  data: filteredSummaryData.map(sd => sd.Active)
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
  watch: {
    country: function (newCountry) {
      this.loadData(newCountry);
    }
  },
  async mounted() {
    this.loadData(this.country)
  }
};
</script>

<style>
  #line-chart {
    width: 100% !important;
    height: 100% !important;
  }
</style>