
<!--
Provide a text box for searching words AS YOU TYPE 
which supports searching for words starting with letters specified
-->
    
<template>
    <v-container>
        <v-row align="center">

          <v-col
            cols="12"
            sm="6"
          >
            <v-text-field
              v-model="message4"
              label="Search"
              outlined
              clearable
            ></v-text-field>
          </v-col>
        </v-row>
    </v-container>

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

  getresults() {

  }

}
