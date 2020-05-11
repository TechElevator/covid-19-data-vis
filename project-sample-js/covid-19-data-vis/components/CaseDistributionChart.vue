<template>
  <pie-chart v-if="loaded" :chartdata="chartdata" :options="options" />
</template>

<script>
import PieChart from "./PieChart.vue";

export default {
  name: "CaseDistributionChart",
  components: { PieChart },
  data: () => ({
    loaded: false,
    chartdata: null,
    options: null
  }),
  methods: {
    getCountryLabel: function(countryData, totalConfirmedAllCountries) {
      const percentageOfCases = (
        (countryData.TotalConfirmed / totalConfirmedAllCountries) *
        100
      ).toFixed(2);
      return `${countryData.Country}: ${percentageOfCases}% (${countryData.TotalConfirmed})`;
    },
    getRandomHex: function() {
      return "#" + Math.floor(Math.random() * 16777215).toString(16);
    }
  },
  async mounted() {
    this.loaded = false;
    try {
      fetch("https://api.covid19api.com/summary")
        .then(response => response.json())
        .then(summaryData => {
          const filteredSummaryData = summaryData.Countries.map(sd => {
            return {
              Country: sd.Country,
              TotalConfirmed: sd.TotalConfirmed
            };
          })
            .sort((a, b) => b.TotalConfirmed - a.TotalConfirmed)
            .slice(0, 10);

          const totalConfirmed = filteredSummaryData.reduce(
            (a, b) => a + b.TotalConfirmed,
            0
          );

          this.chartdata = {
            labels: filteredSummaryData.map(sd =>
              this.getCountryLabel(sd, totalConfirmed)
            ),
            datasets: [
              {
                backgroundColor: filteredSummaryData.map(this.getRandomHex),
                data: filteredSummaryData.map(sd => sd.TotalConfirmed)
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
};
</script>

<style>
  #pie-chart {
    width: 50% !important;
    height: 50% !important;
  }
</style>