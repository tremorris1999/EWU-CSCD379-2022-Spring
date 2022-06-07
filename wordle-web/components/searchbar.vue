
<!--
Provide a text box for searching words AS YOU TYPE 
which supports searching for words starting with letters specified
-->
    
<template>

    <v-toolbar
      dark
      color="teal"
    >      
      <v-autocomplete
        v-model="select"
        :loading="loading"
        :items="items"
        :search-input.sync="search"
        cache-items
        class="mx-4"
        flat
        hide-no-data
        hide-details
        label="Which word are you looking for?"
        solo-inverted
      ></v-autocomplete>
      <v-btn icon>
        <v-icon> mdi-database-search </v-icon>
      </v-btn>
    </v-toolbar>

</template>



<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { Letter, LetterStatus } from '~/scripts/letter'
import { WordleGame } from '~/scripts/wordleGame'
import { WordsService } from '~/scripts/wordsService'

@Component
export default class SearchBar extends Vue {
  @Prop({ required: true })

  wordlist 

  wordleGame!: WordleGame



}
