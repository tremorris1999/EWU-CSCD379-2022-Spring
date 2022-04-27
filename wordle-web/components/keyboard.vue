<template>
  <v-card class="ma-0 pa-0" color="transparent" flat>
    <v-row v-for="(charRow, i) in chars" :key="i" no-gutters justify="center">
      <v-col v-for="char in charRow" :key="char" cols="1" class="ma-0 pa-0">
        <v-container class="text-center ma-0 pa-0">
          <v-btn
            class="pa-1 ma-0"
            small
            :color="letterColor(char)"
            :disabled="wordleGame.gameOver"
            @click="setLetter(char)"
          >
            {{ char }}
          </v-btn>
        </v-container>
      </v-col>
    </v-row>
    <v-btn
      small
      :disabled="wordleGame.gameOver"
      class="float-left"
      @click="guessWord"
    >
      Guess
    </v-btn>
    <v-btn
      small
      :disabled="wordleGame.gameOver"
      icon
      class="float-right"
      @click="removeLetter"
    >
      <v-icon>mdi-backspace</v-icon>
    </v-btn>
    <v-row>
      <CandidateDisplay
        :candidatesArray="candidatesArray"
        :display="render"
        @fill-word="fillWord"
      />
    </v-row>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { Letter, LetterStatus } from '~/scripts/letter'
import { WordleGame } from '~/scripts/wordleGame'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class KeyBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  candidatesArray: string[] = []
  render: boolean = false

  beforeMount()
  {
    this.updateCandidates()
  }

  chars = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm', '?'],
  ]

  setLetter(char: string) {
    this.wordleGame.currentWord.addLetter(char)
    this.updateCandidates()
  }

  removeLetter() {
    this.wordleGame.currentWord.removeLetter()
    this.updateCandidates()
  }

  updateCandidates() {
    const word = this.wordleGame.currentWord.text
    this.candidatesArray = WordsService.validWords(word)
    this.render = false;
  }

  guessWord() {
    if (
      this.wordleGame.currentWord.length ===
      this.wordleGame.currentWord.maxLetters
    ) {
      this.wordleGame.submitWord()
      this.wordleGame.currentWord
      this.updateCandidates()
    }
  }

  fillWord(str: string) {
    while (this.wordleGame.currentWord.length > 0) {
      this.removeLetter()
    }

    for (const c of str.split('')) {
      this.setLetter(c.toLowerCase())
    }
  }

  letterColor(char: string): string {
    if (this.wordleGame.correctChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Correct)
    }
    if (this.wordleGame.wrongPlaceChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.WrongPlace)
    }
    if (this.wordleGame.wrongChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Wrong)
    }

    return Letter.getColorCode(LetterStatus.Unknown)
  }
}
</script>
