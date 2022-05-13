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
      <v-row>
        <v-col cols="2" />
        <v-col cols="1" class="ma-0 pa-0 mx-auto">
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

        <v-col cols="2" class="float-right">
          <DialogBox @loaded-name="setUser" />
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
          <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
        </v-alert>
      </v-row>

      <v-row
        ><v-card :key="time" class="py-2 px-3">
          {{ word + ' ' }} + time to complete:
          {{
            Math.floor(time / 60) +
            ' minutes, ' +
            (time % 60) +
            ' seconds' +
            word
          }}</v-card
        ></v-row
      >

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
  word: string = WordsService.getRandomWord()
  user: string = 'Guest'
  wordleGame = new WordleGame(this.word)
  isLoaded: boolean = false
  time: number = 0
  // visible: boolean = false
  sent: boolean = false

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 1000)

    setInterval(() => this.updateTime(), 1000)
  }

  updateTime() {
    if (!this.sent) {
      this.time += 1
      this.wordleGame.setTime(this.time)
    }
  }

  setUser(name: string) {
    this.user = name
  }

  updateUsername(u: string) {
    this.user = u
    return this.user
  }

  resetGame() {
    this.time = 0
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.sent = false
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      // TODO: call this.wordleGame.setTime(this.time)
      if (this.user === 'Guest') {
        // this.visible = true
      }

      if (!this.sent) {
        this.wordleGame.setTime(this.time)

        const player = this.wordleGame.getPlayer()

        // console.log('name ' + player[0])
        // console.log('guesses ' + player[1])
        // console.log('sec ' + player[2])

        this.$axios.post('api/Player', {
          name: player[0],
          guesses: player[1],
          seconds: player[2],
        })

        this.sent = true
      }

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
}
</script>
