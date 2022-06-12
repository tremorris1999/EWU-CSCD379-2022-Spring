<template>
  <v-container>
    <v-row justify="center">
      <v-col :cols="cols">
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <NotWordleLogo />
          </v-card-title>

          <v-card-actions class="justify-center">
            <v-btn nuxt to="/game" color="orange" x-large width="130px">
              !Wordle
            </v-btn>

            <v-btn nuxt to="/game_otd" color="green" x-large width="230px">
              Word Of The Day
            </v-btn>

            
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>


    <v-row>
      <v-col align="center">
        <v-btn nuxt to="/instructions" color="blue" x-large width="180px">
          How to Play
        </v-btn>
      </v-col>
    </v-row>

    <v-row> 
      <v-col align="center">
        <v-btn nuxt to="/log-in"  color="red" x-large width="130px">
          Log In <v-icon>mdi-notebook-edit</v-icon></v-btn>
      </v-col>
    </v-row>

      
      

  </v-container>
</template>

<script lang="ts">
import {Component, Vue }from 'vue-property-decorator'

@Component
export default class IndexPage extends Vue {
  get cols(): string {
    switch (this.$vuetify.breakpoint.name) {
      case 'xs':
      case 'sm':
        return '12'
      default:
        return '9'
    }
  }
}
</script>

