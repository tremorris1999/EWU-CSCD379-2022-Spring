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
      <v-row
        ><v-card :key="time">YO {{ time }}</v-card></v-row
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

  mounted() {
    setTimeout(() => {
      this.isLoaded = true
    }, 1000)

    setInterval(() => this.updateTime(), 1000)
  }

  updateTime() {
    this.time += 1
  }

  setUser(name: string) {
    this.user = name
  }

  updateUsername(u: string) {
    this.user = u
    return this.user
  }

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
  }

  get gameResult() {
    if (this.wordleGame.state === GameState.Won) {
      // TODO: call this.wordleGame.setTime(this.time)
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
