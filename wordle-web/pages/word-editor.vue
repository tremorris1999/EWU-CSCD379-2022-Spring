<template>
  <v-container>
    <v-row justify="center" class="my-4">
      <v-btn color="primary" nuxt to="/" fab x-small>
        <v-icon>mdi-home</v-icon>
      </v-btn>
    </v-row>

    <v-row v-if="CreateUpdateVisibility">
      <v-col>
        <v-alert class="justify-center">
          <v-text-field label="new value" v-bind="newWord">{{
            newWord
          }}</v-text-field>
          <v-btn @click="newWordApiCall({ newWord })">Submit Change</v-btn>
        </v-alert>
      </v-col>
    </v-row>

    <v-row justify="center">
      <v-col cols="8">
        <v-card>
          <v-card-title class="justify-center">Word Editor</v-card-title>
          <!-- <SearchBar :wordList="this.wordList" v-bind="results" @update="update" />-->
          <v-row justify="center" v-for="r in this.resultsSubset" :key="r">
            <v-col cols="6">
              <!-- <v-btn outlined text @click="showEditMenu(r)"> {{ r }} </v-btn> -->
              {{ r }}
            </v-col>

            <v-col cols="2" />
            <v-col cols="1">
              <v-btn fab x-small @click="removeWord">
                <v-icon> mdi-delete-forever </v-icon>
              </v-btn>
            </v-col>
          </v-row>

          <v-row class="justify-center"
            ><v-btn class="ma-2" @click="displayPrevPage"
              ><v-icon>mdi-arrow-left-bold-circle-</v-icon>back</v-btn
            >
            <v-btn class="ma-2" @click="displayNextPage"
              ><v-icon>mdi-arrow-right-bold-circle-</v-icon>forward</v-btn
            >
          </v-row>
        </v-card>
      </v-col>
    </v-row>

    <v-row justify="center" class="pa-4">
      <v-btn fill color="primary" @click="showAddMenu"> Add New Word </v-btn>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
// import { mdiArrowLeftCircle } from '@mdi/js'
// import { mdiArrowRightCircle } from '@mdi/js'

// import { Keyboard } from '~/components/keyboard.vue'
// import { NoGameCandidateDisplay } from '~/components/NoGameCandidateDisplay.vue'
// import { wordsService } from '~/scripts/wordsService'
// import { Game } from '@/pages/game.vue'
// import { WordleGame } from '~/scripts/wordleGame'

@Component
export default class WordEditor extends Vue {
  wordList: string[] = [
    'apple',
    'avent',
    'banjo',
    'brick',
    'caulk',
    'donut',
    'greet',
    'joker',
    'lemur',
    'young',
    'zebra',
    'zoolu',
  ]
  // TODO: remove hardcoded list

  results: string[] = this.wordList

  resultsSubset: string[] = []
  position: number = 0
  CreateUpdateVisibility: boolean = false

  // wordGettingUpdated: string | null = null

  mounted() {
    this.refresh()
    for (let i = 0; i < this.results.length && i < 10; i++) {
      this.resultsSubset.push(this.results[i])
      this.position++
    }
  }

  deleteWord() {
    this.$axios.get('')
  }

  showAddMenu() {
    this.CreateUpdateVisibility = true
  }

  newWordApiCall(newWord: string) {
    this.CreateUpdateVisibility = false
    this.addWord(newWord)
  }

  displayNextPage() {
    this.resultsSubset = []
    const targetPosition = this.position + 10
    for (
      let i = this.position;
      i < this.results.length && i < targetPosition;
      i++
    ) {
      this.resultsSubset.push(this.results[i])
      this.position++
    }
    this.position = this.position - (this.position % 10)
    console.log(this.position)
  }

  displayPrevPage() {
    this.resultsSubset = []
    const targetPosition = this.position
    this.position = this.position - 10 >= 0 ? this.position - 10 : 0
    console.log('target' + targetPosition + 'position' + this.position)
    this.position = Math.floor(this.position / 10)
    console.log('florPosition' + this.position)
    // console.log('prev' + this.position)
    for (
      let i = this.position;
      i < this.results.length && i < targetPosition;
      i++
    ) {
      this.resultsSubset.push(this.results[i])
      this.position++
    }
    // console.log(this.position)
  }

  created() {
    this.refresh()
  }

  update(results: string[]) {
    this.results = results
  }

  refresh() {
    this.$axios.get('/api/Words').then((response) => {
      this.wordList = response.data
    })
  }

  addWord(word: string) {
    this.$axios.post('/api/Words/add', { value: word })
    this.refresh()
  }

  updateWord(word: string, updatedWord: string) {
    this.$axios.post('/api/Words/update', { value: word, value2: updatedWord })
  }

  removeWord(word: string) {
    this.$axios.delete('/api/Words/delete')
  }
}
</script>
