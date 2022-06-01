<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-2 justify-center">
        Stats
      </v-card-title>
      <v-card-text class="text-center">
        Last 10 daily words
      </v-card-text>
      <v-card-text>
        <v-simple-table>
          <thead>
            <tr>
              <th>Date</th>
              <th style="text-align: center"># Games</th>
              <th style="text-align: center">Avg. Attempts</th>
              <th style="text-align: center">Avg. Seconds</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(player, playerId) in players" :key="playerId">
              <td>{{ player.Date }}</td>
              <td style="text-align: center">{{ player.gameCount }}</td>
              <td style="text-align: center">
                {{ player.averageAttempts.toFixed(2) }}
              </td>
              <td style="text-align: center">
                {{ player.averageSecondsPerGame }}
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-card-text>

      <v-container>
          You haven't played today, wanna 
          <v-btn color="primary" nuxt to="/" >Play</v-btn>?
      </v-container>

      <v-container>
          You played today, did you have fun? 
          <v-btn color="primary" nuxt to="/game" >Yes</v-btn>
          <v-btn color="primary" nuxt to="/game" >No</v-btn>
      </v-container>


      <!-- <v-card-actions class="justify-center">
        <v-btn color="primary" @click="getTop10Players">
          Get Top 10 Players
        </v-btn>
      </v-card-actions> -->

    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class leaderboard extends Vue {
  players: any = []
  title: string = ''

  get class(): string{
    if (this.$vuetify.breakpoint.mobile)
      return "display-2 justify-center"
    else
      return "display-3 justify-center"
  }

  created() {
    this.getTop10Players()
  }

  getAllPlayers() {
    this.title = 'All Players'
    this.$axios.get('/api/Players').then((response) => {
      this.players = response.data
    })
  }

  getTop10Players() {
    this.title = 'Top 10 Players'
    this.$axios.get('/api/Players/GetTop10').then((response) => {
      this.players = response.data
    })
  }
}
</script>
