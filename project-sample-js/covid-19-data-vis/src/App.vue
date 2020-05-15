<template>
  <div id="app container is-fluid">
    <div class="tile is-ancestor">
      <div class="tile is-parent">
        <article class="tile is-child box">
          <p class="subtitle centered">Case Distribution</p>

          <CaseDistributionChart />
        </article>
      </div>

      <div class="tile is-parent">
        <article class="tile is-child box">
          <p class="subtitle centered">{{ updateCountryLabel(outcomeOfClosedCasesCountry, 'Outcome of Closed Cases') }}</p>
          
          <RecoveredDeathsChart :country="outcomeOfClosedCasesCountry.value" />
        
          <div class="columns margin-top-1">
            <div class="column"></div>
            <div class="column">
              <CountryDropDown v-on:country-changed="(country) => outcomeOfClosedCasesCountry = country" />
            </div>
            <div class="column"></div>
          </div>
        </article>
      </div>
    </div>
    
    <div class="tile is-ancestor">
      <div class="tile is-parent">
        <article class="tile is-child box">
          <p class="subtitle centered">{{ updateCountryLabel(activeCasesCountry, 'Active Cases') }}</p>
          
          <ActiveCasesLineChart :country="activeCasesCountry.value" />
          
          <div class="columns margin-top-1">
            <div class="column"></div>
            <div class="column">
              <CountryDropDown v-on:country-changed="(country) => activeCasesCountry = country" />
            </div>
            <div class="column"></div>
          </div>
        </article>
      </div>

      <div class="tile is-parent">
        <article class="tile is-child box">
          <p class="subtitle centered">{{ updateCountryLabel(activeCasesByProvinceCountry, 'Active Cases By Province') }}</p>
          
          <ActiveCasesByProvinceLineChart :country="activeCasesByProvinceCountry.value" />
          
          <div class="columns margin-top-1">
            <div class="column"></div>
            <div class="column">
              <CountryDropDown v-on:country-changed="(country) => activeCasesByProvinceCountry = country" />
            </div>
            <div class="column"></div>
          </div>
        </article>
      </div>
    </div>
  </div>
</template>

<script>
import ActiveCasesByProvinceLineChart from './components/ActiveCasesByProvinceLineChart.vue'
import ActiveCasesLineChart from './components/ActiveCasesLineChart.vue'
import CaseDistributionChart from './components/CaseDistributionChart.vue'
import CountryDropDown from './components/CountryDropDown.vue'
import RecoveredDeathsChart from './components/RecoveredDeathsChart.vue'

export default {
  name: 'App',
  components: {
    ActiveCasesByProvinceLineChart,
    ActiveCasesLineChart,
    CaseDistributionChart,
    CountryDropDown,
    RecoveredDeathsChart
  },
  data: () => ({
    activeCasesByProvinceCountry: '',
    activeCasesCountry: '',
    outcomeOfClosedCasesCountry: ''
  }),
  methods: {
    updateCountryLabel: function (country, defaultText) {
      if(country && country.displayText) {
        return `${defaultText} - ${country.displayText}`;
      }
      
      return defaultText;
    }
  }
}
</script>

<style>
@import "../node_modules/bulma/css/bulma.css";
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.margin-top-1 {
  margin-top: 1rem;
}

.centered {
  text-align: center;
}

</style>
