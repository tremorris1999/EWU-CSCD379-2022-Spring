<template>
  <v-container>
    <v-container fluid fill-height justify-end>
      <v-dialog 
      justify-end
      v-model="dialog" 
      persistent
       max-width="600px">
      <template v-slot:activator="{ on, attrs }">
        <v-btn color="primary" dark v-bind="attrs" v-on="on">
          {{ playerName }}
        </v-btn>
      </template>
      <v-card>
        <v-text-field
          type="text"
          v-model="playerName"
          placeholder="Guest"
        ></v-text-field>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="dialog = false">
            Close
          </v-btn>
          <v-btn color="blue darken-1" text @click="dialog = false">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    </v-container>

    <v-container fluid fill-height justify-center>
      <v-tooltip bottom>
        <template #activator="{ on, attrs }">
          <v-btn color="primary" nuxt to="/" fab v-bind="attrs" v-on="on">
            <v-icon> mdi-home </v-icon>
          </v-btn>
        </template>
        <span> Go Home </span>
      </v-tooltip>

      <v-card-text class="text-h1 font-weight-black text-center">
        Wordle!
      </v-card-text>

      <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
        {{ gameResult.text }}
        <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
      </v-alert>

      <game-board :wordleGame="wordleGame" />

      <keyboard :wordleGame="wordleGame" />
    </v-container>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  //? need this for closing button

  playerName = "GUEST"
  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)

  //localStorage: this.any.setItem(playerName)
  //localStorage: this.$any: any.setItem(playerName) 
  //.setItem('name', playerName)
  /*const player = {
    name: this.playerName
  }*/

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      return { type: 'success', text: 'Yay! You won!' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return { type: 'error', text: `You lost... :( The word was ${this.word}` }
    }
    return { type: '', text: '' }
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }
  data() {
    return {
      dialog: false,
    }
  }
}
</script>
