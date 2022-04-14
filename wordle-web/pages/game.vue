<template>
  <v-container fill-height justify-center>
    <v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn to="/" color="primary" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-home </v-icon>
        </v-btn>
      </template>
      <span> Home </span>
    </v-tooltip>

    <v-card-text class="text-h1 font-weight-black text-center">
      Wordle
    </v-card-text>

    <gameboard :wordleGame="wordleGame" />
    <keyboard :wordleGame="wordleGame" />
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import Keyboard from '@/components/keyboard.vue'
import Gameboard from '@/components/gameboard.vue'
import { WordleGame } from '@/scripts/wordleGame'
import { WordsService } from '~/scripts/wordsService'

@Component({ components: { Keyboard, Gameboard } })
export default class Game extends Vue {
    wordOfTheDay: string = WordsService.getRandomWord();
    wordleGame: WordleGame = new WordleGame(this.wordOfTheDay);

    resetGame(){
        this.wordOfTheDay = WordsService.getRandomWord();
        this.wordleGame = new WordleGame(this.wordOfTheDay);
    }
}
</script>
