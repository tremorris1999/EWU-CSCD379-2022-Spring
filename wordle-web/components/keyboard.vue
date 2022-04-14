<template>
  <v-card width="100%" class="my-5 pa-5">
    <v-row v-for="(lettersRow, i) in letters" :key="i" no-gutters justify="center">
      <v-col v-for="letter in lettersRow" :key="letter" cols="1"> 
           <v-container class="text-center">
               <v-btn>
                   {{letter}} 
               </v-btn>
           </v-container>
    </v-col>
    </v-row>

    <v-btn class="float-left"> Guess </v-btn>

    <v-btn icon class="float-right"> <v-icon> mdi-backspace </v-icon> </v-btn>

  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '@/scripts/wordleGame'

@Component({ components: {} })
export default class Keyboard extends Vue {
    @Prop({ required: true })
    wordleGame!: WordleGame;

  letters = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm', '?'],
  ]
}
</script>
