<template>
  <v-toolbar
    color="primary"
  >
    <v-autocomplete
      v-model="select"
      :loading="loading"
      :items="items"
      :search-input.sync="search"
      cache-items
      class="mx-4"
      flat
      hide-no-data
      hide-details
      label="Which word are you searching for?"
      solo-inverted
    ></v-autocomplete>

    <v-btn icon>
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

  </v-toolbar>
</template>

<script>
  export default {
    mounted()
    {
      this.$axios.get("/api/Word/Get")
        .then((response) =>
        {
          this.items = response.data;
        })
    },

    data () {
      return {
        loading: false,
        items: [],
        search: null,
        select: null,
      }
    },
    watch: {
      search (val) {
        val && val !== this.select && this.querySelections(val)
      },
    },
    methods: {
      querySelections (v) {
        this.loading = true
        // Simulated ajax query
        setTimeout(() => {
          this.items = this.words.filter(e => {
            return (e || '').toLowerCase().indexOf((v || '').toLowerCase()) > -1
          })
          this.loading = false
        }, 500)
      },
    },
  }
</script>