<template>
  <v-card width="400" color="transparent" class="ma-0 pa-0" flat>
    <v-container>
      <v-row justify="center" v-for="row in wordleGame.maxGuesses" :key="row" no-gutters>
        <v-col cols="2" class="ma-1 pa-0" v-for="index in wordleGame.currentWord.maxLetters" :key="index">
          <v-card class="ma-0 pa-0" height="60" :color="letterColor(getLetter(row, index))" outlined>
            <v-card-text class="text-center">
              {{ getChar(getLetter(row, index)) }}
            </v-card-text>
          </v-card>
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
