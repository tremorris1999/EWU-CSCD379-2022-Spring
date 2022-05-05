<template>
  <v-container fluid fill-height justify-center>
    <v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn color="primary" nuxt to="/" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-home </v-icon>
        </v-btn>
      </template>
      <span> Go Home </span>
    </v-tooltip>

    <v-card-text class="text-h1 font-weight-black text-center">
      Wordle Game Stats!
    </v-card-text>
    <v-card-actions>
        <v-btn color="primary" {{refreshStats}}> Refresh </v-btn>
    </v-card-actions>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class ScoreStats extends Vue {
    stats: any = []
    
    refreshStats(){
        this.$axios.get('https://localhost:7125/api/ScoreStats')
        .then(response => {
            this.stats = response.data
        })
    }
}
</script>
