<template>
  <v-container>
    <v-row>
      <v-col>
        <v-list>
          <v-list-item v-for="c in candidates" :key="c">
            <v-list-item-content>
              {{ c }}
            </v-list-item-content>
          </v-list-item>
          <v-btn icon>
            <v-icon @click="$emit('log')">mdi-magnify</v-icon>
          </v-btn>
          <!-- "CandidateWords.update(this.value)" -->
          <v-text-field @input="log(text)">
            <input v-model="text"
          /></v-text-field>

          <!-- @input="" -->
        </v-list>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class CandidateWords extends Vue {
  word: string
  candidatesList: string[]

  constructor() {
    super()
    this.word = ''
    this.candidatesList = []
  }

  log() {
    console.log(this.update('ac'))
  }

  data() {
    return {
      text: '',
    }
  }

  update(current: string) {
    this.candidatesList = WordsService.getCandWords(current)
    for (const str of this.candidatesList) {
      console.log(str)
    }
  }
}
</script>
