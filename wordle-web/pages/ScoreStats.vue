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
    <v-card>
        <v-card-title>
          <h1 class="display-1">Score Stats</h1>
        </v-card-title>
    <v-card-text>
        <v-simple-table>
            <thead>
                <tr>
                    <th>Score</th>
                    <th>Avg. Seconds</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(stat, index) in stats " :key="index">
                    <td>{{ stat.score }}</td>
                    <td>{{ stat.averageSeconds }}</td>
                     </tr>
            </tbody>
        </v-simple-table>
    </v-card-text>
    <v-card-actions>
        <v-btn color="primary" @click="refreshStats"> Refresh </v-btn>
    </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class ScoreStats extends Vue {
    stats: any = []
    
    refreshStats(){
        this.$axios.get('/api/ScoreStats')
        .then(response => {
            this.stats = response.data
        })
    }
}
</script>
