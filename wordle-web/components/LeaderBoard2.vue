<template>
  <v-container>
    <v-btn @click="refresh">Refresh</v-btn>

    <v-container v-if="!hasData">
      There are no leaderboard entries at this time...
    </v-container>

    <v-container>
      <v-row justify="left">
        <v-col cols="10">
          <v-card color="transparent" flat>
            <v-card-title class="justify-center">
            
            </v-card-title>
          <v-card color="transparent" flat>
            <v-card-title class="justify-center text-h3 font-weight-bold" >
              <starLogo /> <starLogo /> <starLogo />  Top Awesome Players   <starLogo /> <starLogo /> <starLogo />
            </v-card-title>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
    </v-container>


  <v-container v-if="hasData" class="item">
    <v-row 
      v-for="t in arr"
      :key="t"
      justify="center"
      color = "green"
      class="text-h6"
      >

      <v-col col="3"  justify="center">
        {{t.name}}
      </v-col>

      <v-col cols="3" justify="center">
        {{t.gameCount}}
      </v-col>

      <v-col cols="3" justify="center">
        {{t.averageGuesses}}
      </v-col>

      <v-col cols="3" justify="center">
        {{t.averageSecondsPerGame}}
      </v-col>
    </v-row>
  </v-container>

  </v-container>



    <!-- <v-container v-if="hasData">
    <v-row 
      v-for="t in arr"
      :key="t"
      justify="center"
      >
      <v-col col="5"  justify="center">
        {{t.name}}
      </v-col>

      <v-col cols="2">
        {{t.gameCount}}
      </v-col>

      <v-col cols="2">
        {{t.averageGuesses}}
      </v-col>
      <v-col cols="3">
        {{t.averageSecondsPerGame}}
      </v-col>
    </v-row>
    </v-container> -->

</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class LeaderBoard2 extends Vue{
  arr: any[] = []
  hasData = false

  beforeMount() {
    this.refresh()
  }

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

<style>
.item
{
  transform: rotateY(1400deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}

</style>