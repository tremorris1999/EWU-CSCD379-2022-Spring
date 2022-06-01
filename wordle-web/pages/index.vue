<template>
  <v-container>
    <v-row justify="center">
      <v-col :cols=cols>
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <NotWordleLogo />
          </v-card-title>

            <v-card-actions class="justify-center">
              <v-btn nuxt to="/game" color="primary" x-large width="150px">
                !Wordle
              </v-btn>

              <v-btn nuxt to="/game_otd" color="primary" x-large width="250px">
                Word Of The Day
              </v-btn>
            </v-card-actions>
          </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang='ts'>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class IndexPage extends Vue {
    get cols(): string{
    switch(this.$vuetify.breakpoint.name){
      case'xs':case'sm':
        return "12"
      default:
        return "9"
    }
  }

}
</script>

<!-- <v-btn color="info" nuxt to="/leaderboard">
            Leader Board
          </v-btn> -->
