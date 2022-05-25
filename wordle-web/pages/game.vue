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
        <v-col cols="1" class="mt-0 mb-0 pt-0 pb-0">
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
          {{ user }}
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

      <v-row v-if="wordleGame.gameOver" justify="center" class="mt-10">
        <v-alert width="80%" :type="gameResult.type">
          {{ gameResult.text }}

          <v-btn class="ml-2" @click="resetGame">don't save results</v-btn>
          <v-btn class="ml-2" @click="dialogBox.visibility(true)"
            >save my results!</v-btn
          >
        </v-alert>
      </v-row>

      <v-row v-if="dialogBox.visible" justify="center" class="mt-10">
        <DialogBox @reset="resetGame" />
        <v-btn class="h3" @click="dialogBox.visibility(true)"
          >Logged in as {{ user }}
        </v-btn>
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
import DialogBox from '@/components/DialogBox.vue'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  // ? need this for closing button
  dialog: boolean = false
  playerName: string = ''
  timeInSeconds: number = 0
  startTime: number = 0
  endTime: number = 0
  intervalID: any
  word: string = WordsService.getRandomWord()
  user: string = 'Guest'
  wordleGame = new WordleGame(this.word)
  dialogBox = new DialogBox()

  isLoaded: boolean = false

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 5000)
  }

  setUser(name: string) {
    this.user = name
    this.resetGame()
  }

  isLoaded: boolean = false

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 5000)
    this.retrieveUserName()
    setTimeout(() => this.startTimer(), 5000) // delay is because of ad loading
  }

  resetGame() {
    this.dialogBox.visibility(false)
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.timeInSeconds = 0
    this.startTimer()
  }

  get gameResult() {
    this.stopTimer()
    this.timeInSeconds = Math.floor(this.endTime - this.startTime)
    if (this.wordleGame.state === GameState.Won) {
      return {
        type: 'success',
        text: '\t\tYou won! :^) \nWould you like to make a profile and save your results?',
      }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return {
        type: 'error',
        text: `\t\tYou lost... :^( The word was ${this.word} \nWould you like to make a profile and save your results?`,
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

  retrieveUserName() {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      this.playerName = 'Guest'
    } else {
      this.playerName = userName
    }
  }

  setUserName(userName: string) {
    localStorage.setItem('userName', userName)
    if (this.wordleGame.state === GameState.Won) {
      this.endGameSave()
    }
  }

  startTimer() {
    this.startTime = Date.now() / 1000
    this.intervalID = setInterval(this.updateTimer, 1000)
  }

  updateTimer() {
    this.timeInSeconds = Math.floor(Date.now() / 1000 - this.startTime)
  }

  stopTimer() {
    this.endTime = Date.now() / 1000
    clearInterval(this.intervalID)
  }

  displayTimer() {
    let text = `${
      this.timeInSeconds / 60 / 60 > 1
        ? Math.floor(this.timeInSeconds / 60 / 60) + ':'
        : ''
    }`
    text += `${
      Math.floor((this.timeInSeconds / 60) % 60) < 10
        ? '0' + Math.floor((this.timeInSeconds / 60) % 60)
        : Math.floor((this.timeInSeconds / 60) % 60)
    }:`
    text += `${
      Math.floor(this.timeInSeconds % 60) < 10
        ? '0' + Math.floor(this.timeInSeconds % 60)
        : Math.floor(this.timeInSeconds % 60)
    }`
    return text
  }

  endGameSave() {
    this.$axios.post('/api/Players', {
      name: this.playerName,
      attempts: this.wordleGame.words.length,
      seconds: this.timeInSeconds,
    })
  }
}
</script>
