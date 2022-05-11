<template>
  <v-container>
    <v-btn @click="refresh">Refresh</v-btn>
    <v-container v-if="!hasData">
      There are no leaderboard entries at this time...
    </v-container>
    <v-container v-if="hasData">
    <v-row 
      v-for="t in arr"
      :key="t"
      justify="center"
      >
      <v-col col="3"  justify="center">
        {{t.name}}
      </v-col>
      <v-col cols="3">
        {{t.gameCount}}
      </v-col>
      <v-col cols="3">
        {{t.averageGuesses}}
      </v-col>
      <v-col cols="3">
        {{t.averageSecondsPerGame}}
      </v-col>
    </v-row>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class LeaderBoard2 extends Vue{
  arr: any[] = []
  hasData = false

  refresh()
  {
    this.$axios.get('/api/Player').then((response) => {
      this.setData(response.data)
    })
  }

  setData(arr: any)
  {
    this.arr = arr;
    this.hasData = this.arr.length == 0 ? false : true
  }
}
</script>