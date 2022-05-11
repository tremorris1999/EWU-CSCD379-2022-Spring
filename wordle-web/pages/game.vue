<template>
  <v-container fluid fill-height>
    <v-container v-if="!isLoaded">
      <v-row justify="center">
        <v-card loading>
          <v-card-title class="justify-center">
            You're being exploited for ad revenue, please standby...
          </v-card-title>
          <PrerollAd />
        </v-card>
      </v-row>
    </v-container>
    <v-container v-if="isLoaded">
      <v-row justify="center">
        <v-col cols="5"></v-col>
        <v-col cols="2" class="mt-0 mb-0 pt-0 pb-0">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-container>
                <v-row justify="center">
                  <v-btn
                    color="primary"
                    x-small
                    nuxt
                    to="/"
                    fab
                    v-bind="attrs"
                    v-on="on"
                  >
                    <v-icon>mdi-home</v-icon>
                  </v-btn>
                </v-row>
              </v-container>
            </template>
            <span> Go Home </span>
          </v-tooltip>
        </v-col>
        <v-col cols="5" class="d-flex flex-row-reverse">
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
            <v-btn color="blue darken-1" text @click="dialog = false, setUserName(playerName)">
              Save
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      </v-col>
      </v-row>

      <v-row justify="center" class="mt-0 pt-2">
        <v-col class="mt-2 mb-0 pt-0 pb-0">
          <v-card flat color="transparent" class="mt-0 mb-0 pt-0 pb-0">
            <v-card-text
              class="text-h3 font-weight-black text-center ma-0 pa-0"
            >
              !Wordle
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>

      <v-row justify="center" class="mt-10">
        <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
          {{ gameResult.text }}
          <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
        </v-alert>
      </v-row>

      <v-row justify="center">
        <game-board :wordleGame="wordleGame" />
      </v-row>
      <v-row justify="center">
        <keyboard :wordleGame="wordleGame" />
      </v-row>
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

  playerName: string = "";
  word: string = WordsService.getRandomWord()
  wordleGame = new WordleGame(this.word)

  isLoaded: boolean = false

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 5000)
    this.retrieveUserName();
  }

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      return { type: 'success', text: 'You won! :^)' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return {
        type: 'error',
        text: `You lost... :^( The word was ${this.word}`,
      }
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

  retrieveUserName()
  {
    var userName = localStorage.getItem('userName');
    if (userName == null)
    {
      this.playerName = "Guest";
    }
    else
    {
      this.playerName = userName;
    }
  }

  setUserName(userName: string)
  {
    localStorage.setItem('userName', userName);
  }
}
</script>
