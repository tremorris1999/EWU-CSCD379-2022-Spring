<template>
  <v-card class="ma-0 pa-0" color="transparent" flat>
    <v-row v-for="(charRow, i) in chars" :key="i" justify="center">
      <v-col v-for="char in charRow" :key="char" cols="1" class="ma-0 pa-0">
        <v-container class="text-center ma-0 pa-0">
          <v-btn
            class="pa-1 mx-3 my-1"
            elevation="8"
            :color="letterColor(char) == '' ? 'info' : letterColor(char)"
            style="
              background: linear-gradient(
                180deg,
                rgba(0, 0, 0, 0.4) 0%,
                rgba(0, 0, 0, 0) 40%,
                rgba(0, 0, 0, 0) 100%
              );
            "
            :disabled="wordleGame.gameOver"
            @click="keyPress(char)"
          >
            {{ char }}
          </v-btn>
        </v-container>
      </v-col>
    </v-row>

    <v-row justify="center">
      <v-col cols="2">
        <v-btn
          :disabled="wordleGame.gameOver"
          class="float-left pa-1 ml-3"
          @click="guessWord"
        >
          Guess
        </v-btn>
      </v-col>

      <v-col cols="8">
        <CandidateDisplay
          class="pa-0"
          :disable="wordleGame.gameOver"
          :candidatesArray="candidatesArray"
          :display.sync="render"
          @fill-word="fillWord"
        />
      </v-col>

      <v-col cols="2">
        <v-btn
          :disabled="wordleGame.gameOver"
          class="float-right pa-1"
          @click="removeLetter"
        >
          <v-icon>mdi-backspace</v-icon>
        </v-btn>
      </v-col>
    </v-row>
    <v-row justify="center" class="mt-n2"> </v-row>
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
  sfx?: HTMLAudioElement

  keyPress(char: string) {
    if (this.sfx) {
      this.sfx.play()
    }

    this.setLetter(char)
  }

  beforeMount() {
    this.candidatesArray = WordsService.validWords('')
    this.sfx = new Audio('key.wav')
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
    this.render = false
  }

  guessWord() {
    if (
      this.wordleGame.currentWord.length ===
      this.wordleGame.currentWord.maxLetters
    ) {
      this.wordleGame.submitWord()
      // this.wordleGame.currentWord
      this.candidatesArray = WordsService.validWords('')
      this.render = false
    }
  }

  fillWord(str: string) {
    while (this.wordleGame.currentWord.length > 0) {
      this.removeLetter()
    }

    for (const choice of str.split('')) {
      this.setLetter(choice.toLowerCase())
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
