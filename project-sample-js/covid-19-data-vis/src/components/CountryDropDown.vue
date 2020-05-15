<template>
    <div class="control has-icons-left centered">
        <div class="select is-small">
          <select v-model="selectedCountry" v-on:change="$emit('country-changed', getSelectedCountryObject())">
            <option v-for="option in countryOptions" v-bind:value="option.value" :key="option.value">
            {{ option.text }}
            </option>
          </select>
        </div>
        <span class="icon is-small is-left">
            <i class="fas fa-globe"></i>
        </span>
    </div>
</template>

<script>
export default {
  name: 'CountryDropDown',
  data: () => ({
    countryOptions: [],
    firstItem: { displayText: '', text: '-- Select Country --', value: '' },
    selectedCountry: ''
  }),
  methods: {
    getAllCountries: function () {
      if(this.countryOptions.length > 0) return;
      fetch('https://api.covid19api.com/countries')
        .then(response => response.json())
        .then(countries => {
          this.countryOptions = countries
            .map(c => {
              return { 
                displayText: c.Country,
                text: c.Country,
                value: c.Slug 
              };
            })
            .sort((a, b) => a.value.localeCompare(b.value));

          this.countryOptions.unshift(this.firstItem);
        });
      return [];
    },
    getSelectedCountryObject: function () {
      if(!this.selectedCountry) return this.firstItem;

      return this.countryOptions.find(c => c.value === this.selectedCountry);
    }
  },
  mounted () {
    this.countryOptions = this.getAllCountries();
  }
}
</script>

<style scoped>

select {
  width: 200px;
}

</style>