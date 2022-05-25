<template>
  <v-card class="ma-5 py-1" max-width="600px" flat>
    <v-container>
      <v-row v-for="row in wordleGame.maxGuesses" :key="row" justify="center">
        <v-col
          v-for="index in wordleGame.currentWord.maxLetters"
          :key="index"
          cols="1"
          class="ma-2 pa-2"
        >
          <v-row>
            <v-card
              elevation="4"
              class="pa-1"
              justify="center"
              height="50px"
              width="100px"
              style="
                background: linear-gradient(
                  180deg,
                  rgba(0, 0, 0, 0.4) 0%,
                  rgba(0, 0, 0, 0) 40%,
                  rgba(0, 0, 0, 0) 100%
                );
              "
              :color="letterColor(getLetter(row, index))"
            >
              <v-card-text class="text-h4 text-center pa-1">
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
    return letter.char.toUpperCase()
  }

  letterColor(letter: Letter | null): string {
    if (letter === null) return ''
    return letter.letterColor
  }
}
</script>
