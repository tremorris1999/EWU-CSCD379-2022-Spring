<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-2 justify-center"> Stats </v-card-title>
      <v-card-text class="text-center"> Last 10 daily words </v-card-text>
      <v-card-text>
        <v-simple-table>
          <thead>
            <tr>
              <th>Date (YYYY/MM/DD)</th>
              <th style="text-align: center">Guesses</th>
              <th style="text-align: center">Time</th>
              <th style="text-align: center">Played</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="g in games" :key="g">
              <td>{{ g.date.replace('T00:00:00', '') }}</td>
              <td style="text-align: center">{{ g.averageGuesses }}</td>
              <td style="text-align: center">
                {{ g.averageSeconds }}
              </td>
              <td style="text-align: center">
                <v-checkbox v-model="g.wasPlayed" disabled></v-checkbox>
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-card-text>

      <!-- <v-container>
          You haven't played today, wanna 
          <v-btn color="primary" nuxt to="/" >Play</v-btn>?
      </v-container>

      <v-container>
          You played today, did you have fun? 
          <v-btn color="primary" nuxt to="/game" >Yes</v-btn>
          <v-btn color="primary" nuxt to="/game" >No</v-btn>
      </v-container> -->

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
export default class Stats extends Vue {
  games: any = []
  title: string = ''

  get class(): string {
    if (this.$vuetify.breakpoint.mobile) return 'display-2 justify-center'
    else return 'display-3 justify-center'
  }

  created() {
    this.getTop10Players()
  }

  getTop10Players() {
    this.title = 'Top 10 Players'
    console.log(this.retrieveUserName())
    this.$axios
      .get('/api/Game/last-ten', {
        params: { playerName: this.retrieveUserName() },
      })
      .then((response) => {
        this.games = response.data
      })
  }

  retrieveUserName(): string {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      return 'Guest'
    } else {
      return userName
    }
  }

  // checkPlayed(value: boolean): string
  // {
  //   return value ? "true" : "false";
  // }
}
</script>
