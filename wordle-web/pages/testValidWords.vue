<template>
  <v-container>
    <v-card color="grey lighten-4" flat height="200px" tile>
      <v-toolbar>
        <v-text-field
          id="searchField"
          hide-details
          prepend-icon="mdi-magnify"
          single-line
          @input="logMatches(value)"
        >
          <CandidateWords />
        </v-text-field>
        <v-btn icon>
          <v-icon>mdi-dots-vertical</v-icon>
        </v-btn>
      </v-toolbar>
    </v-card>
  </v-container>
  <!--    
    <v-slot></v-slot>
    <v-virtual-scroll
      height="100"
      item-height="20"
      items="getCandidateWords"
    ></v-virtual-scroll> -->
</template>
<script lang="ts">
import { Component, Vue } from 'vue-class-component'
// import CandidateWords from '~/components/valid-words.vue'

import { WordsService } from '@/scripts/wordsService'
@Component
export default class CandidateWords extends Vue {
  // remainingWords: string[] = [WordsService.#words]
  //   guess : string
  //   public getCandidateWords(guess:string){
  //       this.guess = guess;
  //   }

  static match: string[] = []

  static getMatches(guess: string): string[] {
    CandidateWords.match = WordsService.getCandWords(guess)
    console.log(CandidateWords.match)
    return CandidateWords.match
  }
}
</script>
