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
          <v-list-item>
            <!-- <v-list-item-content> -->
            <v-btn icon>
              <v-icon>mdi-magnify</v-icon>
            </v-btn>
            <!-- "CandidateWords.update(this.value)" -->
            <v-text-field @input="log(text)">
              <input v-model="text" key="in"
            /></v-text-field>
            <!-- </v-list-item-content> -->
          </v-list-item>

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

  log(s: string) {
    this.update(s)
  }

  data() {
    return {
      text: '???z',
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
