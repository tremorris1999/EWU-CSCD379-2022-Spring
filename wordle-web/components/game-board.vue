<template>
  <v-card class="ma-5 py-1" max-width="500">
    <v-container>
      <v-row v-for="row in wordleGame.maxGuesses" :key="row" justify="center">
        <v-col
          v-for="index in wordleGame.currentWord.maxLetters"
          :key="index"
          cols="2"
          class="ma-2 pa-2"
        >
          <v-row>
            <v-card
              class="ma-0 pa-2"
              justify="center"
              text-lg-center
              height="50"
              width="400"
              :color="letterColor(getLetter(row, index))"
              outlined
              d-flex
            >
              <v-card-text class="text-center pa-1">
                {{ getChar(getLetter(row, index)) }}
              </v-card-text>
            </v-card>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '~/scripts/wordleGame'
import { Word } from '~/scripts/word'
import { Letter } from '~/scripts/letter'

@Component({ components: {} })
export default class GameBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  getLetter(row: number, index: number): Letter | null {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1] ?? null
    }
    return null
  }

  getChar(letter: Letter | null) {
    if (letter === null) return ''
    return letter.char
  }

  letterColor(letter: Letter | null): string {
    if (letter === null) return ''
    return letter.letterColor
  }
}
</script>
