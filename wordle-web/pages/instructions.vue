<template>
  <v-container>
    <v-row justify="center">


      <!-- Instructor Cards -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1> Instructions </h1>
          </v-card-title>
        </v-card>
      </v-col>

      <v-col cols="9">
        <v-card>
          <div class="d-flex align-center">
            <v-container >
              <v-card>
                <v-card-text>
                    <v-icon class="pa-0 my-2">mdi-check</v-icon>You have to guess the !Wordle in six guesses or less. <v-spacer></v-spacer>
                     <v-icon class="pa-0 my-2">mdi-check</v-icon> Letters can be used more than once. <v-spacer></v-spacer>
                     <v-icon class="pa-0 my-2">mdi-check</v-icon> Answers are never plurals.<v-spacer></v-spacer>   
                     <h-2>Example:</h-2> <v-spacer></v-spacer>                                 
                    
                    <!-- BASIC word -->
                    <v-btn color=error small class="pa-0 my-4">B</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">A</v-btn> 
                    <v-btn color=error small class="pa-0 my-4">S</v-btn> 
                    <v-btn color=error small class="pa-0 my-4">I</v-btn> 
                    <v-btn color=error small class="pa-0 my-4">C</v-btn>
                    <v-spacer></v-spacer>

                    The A is IN the word but in the WRONG spot, the rest are not in the word. <v-spacer></v-spacer>
                    

                    <!-- APPLE word -->
                    <v-btn color=success small class="pa-0 my-4">A</v-btn> 
                    <v-btn color=error small class="pa-0 my-4">P</v-btn> 
                    <v-btn color=error small class="pa-0 my-4">P</v-btn> 
                    <v-btn color=warning small class="pa-0 my-4">L</v-btn> 
                    <v-btn color=warning small class="pa-0 my-4">E</v-btn>
                    <v-spacer></v-spacer>
                    The A is IN the word and in the CORRECT spot.<v-spacer></v-spacer>
                    The L, E is IN the word but in the WRONG spot, the rest are not in the word.
                    <v-spacer></v-spacer>

                    <!-- ANGEL word -->
                    Correct word: 
                    <v-btn color=success small class="pa-0 my-4">A</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">N</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">G</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">E</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">L</v-btn> 
                    <v-spacer></v-spacer>                    

                    <v-icon class="pa-0 my-2">mdi-lightbulb-on-outline</v-icon>
                    There are a list of "available words" for you to choose from <v-spacer></v-spacer>  

                    <v-icon class="pa-0 my-2">mdi-lightbulb-on-outline</v-icon>
                    You can place <v-btn color=primary small class="pa-0 my-4">?</v-btn> anywhere and choose from the list.<v-spacer></v-spacer>
                    (color varies by theme)

                    
                

                </v-card-text>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class InstructionsPage extends Vue {

}
</script>
