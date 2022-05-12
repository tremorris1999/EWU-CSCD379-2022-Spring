<template>
  <v-container>
    <v-btn @click="refresh">Refresh</v-btn>

    <v-container v-if="!hasData">
      There are no leaderboard entries at this time...
    </v-container>

    <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <starLogo /> <starLogo /> <starLogo />
          </v-card-title>
          <v-card color="transparent" flat>
            <v-card-title class="justify-center text-h4 font-weight-bold">
              Top Awesome Players
            </v-card-title>
            </v-card-actions>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>

    <v-container>
      <v-card>
        <v-row class="grow" color = "green" ></v-row>
        </v-card>


        <!-- <v-col col = "3" justify="center"> Game Count </v-col>
        <v-col col = "3" justify="center"> Average Guesses </v-col>
        <v-col col = "3" justify="center"> Average Seconds/Game </v-col> -->

      
    </v-container>

    <v-container px-5>
    <v-row justify="center" >
      <v-col cols="12">
        <v-card color="green">
          <v-card-title>Chocolate cheesecake recipe</v-card-title>
          <c-card-text>
            <ul>
              <li>5 eggs</li>
              <li>1 cup of warm milk</li>


  <v-container v-if="hasData">
    <v-row 
      v-for="t in arr"
      :key="t"
      justify="center"
      color = "white"
      rounded
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

    </v-container>

              <li>...</li>
            </ul>
          </c-card-text>
        </v-card>
      </v-col>
    </v-row>
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