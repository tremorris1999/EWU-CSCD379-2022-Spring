<template>
  <v-container fluid fill-height>
    <v-container v-if="!isLoaded">
      <v-row justify="center">
        <v-card loading>
          <v-card-title class="justify-left">
            You're being exploited for ad 
            <v-spacer v-if="$vuetify.breakpoint.mobile"/>
            revenue, please standby...
          </v-card-title>
          <PrerollAd />
        </v-card>
      </v-row>
    </v-container>

    <v-container v-if="isLoaded">
      <v-row justify="center">
        <v-col cols="5"  align="center">
          <!-- <v-card-text align="right"> -->
            <v-btn>
              <v-icon>mdi-timer</v-icon>
              {{ displayTimer() }}

            </v-btn>
          <!-- </v-card-text> -->
        </v-col>

        <v-col cols="2" class="my-0 mb-0 pt-0 pb-0" align="center">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
                  <v-btn
                    color="primary"
                    x-small
                    nuxt
                    to="/"
                    fab
                    v-bind="attrs"
                    v-on="on"
                  >
                    <v-icon>mdi-home</v-icon>
                  </v-btn>
            </template>
            <span> Go Home </span>
          </v-tooltip>
        </v-col>

        <v-col cols="5" align="center">
          <v-dialog v-model="dialog" justify-end persistent max-width="600px">
            <template #activator="{ on, attrs }">
              <v-btn color="primary" dark v-bind="attrs" v-on="on">
                {{ playerName }}
              </v-btn>
            </template>
            <v-card>
              <v-card-text>
                <v-text-field
                  v-model="playerName"
                  type="text"
                  placeholder="Guest"
                ></v-text-field>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialog = false">
                  Close
                </v-btn>
                <v-btn
                  color="blue darken-1"
                  text
                  @click=";(dialog = false), setUserName(playerName)"
                >
                  Save
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-col>
      </v-row>
            

      
      <v-row justify="center" class="mt-10">
        <v-alert v-if="wordleGame.gameOver" width="80%" :type="gameResult.type">
          {{ gameResult.text }}
          <v-btn class="ml-2" @click="resetGame"> Play Again? </v-btn>
        </v-alert>
      </v-row>

      <v-container class="fill-height">
        <v-row
          align="center"
          justify="center"
        >
          <v-btn 
            color=primary
            dark
            @click.stop="drawer = !drawer"
          >
            Instructions
          </v-btn>
        </v-row>
      </v-container> 

      <v-navigation-drawer 
      v-model="drawer"
      width="600"
      absolute
      temporary
      left
      >
      <!-- Instructions Details Cards -->
      <v-col cols="12">
        <v-card>
          <div class="d-flex align-center">
            <v-container >
              <v-card >
                
                    <v-icon class="pa-1 my-2">mdi-check</v-icon>You have to guess the !Wordle in six guesses or less. <v-spacer></v-spacer>
                     <v-icon class="pa-1 my-2">mdi-check</v-icon> Letters can be used more than once. <v-spacer></v-spacer>
                     <v-icon class="pa-1 my-2">mdi-check</v-icon> Answers are never plurals.<v-spacer></v-spacer>  
                    
                     <v-icon class="pa-1 my-2">mdi-lightbulb-on-outline</v-icon>
                    There are a list of "available words" for you to choose from <v-spacer></v-spacer>  

                    <v-icon class="pa-1 my-2">mdi-lightbulb-on-outline</v-icon>
                    You can place <v-btn color=primary small class="pa-0 my-4">?</v-btn> anywhere and choose from the list.<v-spacer></v-spacer>
                    <h-4 class ="pa-1 my-2">(color varies by theme)</h-4>
                    
                     <v-divider></v-divider> 
                     <h2 class="pa-1 mt-2">Example:</h2>                                
                    
                    <!-- BASIC word -->
                    <v-btn color=error small class="pa-0 mt-4 mb-2">B</v-btn> 
                    <v-btn color=warning small class="pa-0 mt-4 mb-2">A</v-btn> 
                    <v-btn color=error small class="pa-0 mt-4 mb-2">S</v-btn> 
                    <v-btn color=error small class="pa-0 mt-4 mb-2">I</v-btn> 
                    <v-btn color=error small class="pa-0 mt-4 mb-2">C</v-btn>
                    <v-spacer></v-spacer>
                    The A is IN the word but in the WRONG spot, the rest are not in the word. <v-spacer></v-spacer>
                    
                    <!-- APPLE word -->
                    <v-btn color=success small class="pa-0 mt-6 mb-2">A</v-btn> 
                    <v-btn color=error small class="pa-0 mt-6 mb-2">P</v-btn> 
                    <v-btn color=error small class="pa-0 mt-6 mb-2">P</v-btn> 
                    <v-btn color=warning small class="pa-0 mt-6 mb-2">L</v-btn> 
                    <v-btn color=warning small class="pa-0 mt-6 mb-2">E</v-btn>
                    <v-spacer></v-spacer>
                    The A is IN the word and in the CORRECT spot.<v-spacer></v-spacer>
                    The L, E is IN the word but in the WRONG spot, the rest are not in the word.
                    <v-spacer></v-spacer>

                    <!-- ANGEL word -->
                    <h2 class="mt-4">Correct word:</h2>
                     
                    <v-spacer></v-spacer>
                    <v-btn color=success small class="pa-0 my-4">A</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">N</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">G</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">E</v-btn> 
                    <v-btn color=success small class="pa-0 my-4">L</v-btn> 
                    <v-spacer></v-spacer>                    
                
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>
      <!--END Instructions Details Cards -->

      </v-navigation-drawer>
      

      <v-row justify="center">
        <game-board :wordleGame="wordleGame" />
      </v-row>
      <v-row cols="12" justify="center">
        <keyboard :wordleGame="wordleGame" />
      </v-row>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService'
import { GameState, WordleGame } from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import { Word } from '~/scripts/word'

@Component({ components: { KeyBoard, GameBoard } })
export default class Game extends Vue {
  // ? need this for closing button
  @Prop({required: false})
  randomMode: boolean = true

  dialog: boolean = false
  playerName: string = this.retrieveUserName();
  timeInSeconds: number = 0
  startTime: number = 0
  endTime: number = 0
  intervalID: any
  word: string = ''
  wordleGame: WordleGame
  gameId: number = 0;

  isLoaded: boolean = false
  constructor() {
    super()
    this.wordleGame = null!
  }

  created()
  {
       this.$axios.get('/api/Game', { params: { dateTime: new Date().toISOString() , name: this.playerName, random: this.randomMode} }).then((response) => {
         console.log(response);
         this.isLoaded = true
         this.word = response.data.word
         this.wordleGame = new WordleGame(this.word)
         this.gameId = response.data.gameId
         console.log(this.word)
         console.log(this.gameId)

       })
  }

  mounted() {
    setTimeout(() => this.startTimer(), 5000) // delay is because of ad loading
  }

  resetGame() {
    this.word = WordsService.getRandomWord()
    this.wordleGame = new WordleGame(this.word)
    this.timeInSeconds = 0
    this.startTimer()
  }

  get gameResult() {
    this.stopTimer()
    this.timeInSeconds = Math.floor(this.endTime - this.startTime)
    if (this.wordleGame.state === GameState.Won) {
      if (
        this.playerName.toLocaleLowerCase() !== 'guest' &&
        this.playerName !== ''
      ) {
        this.endGameSave()
      } else {
        this.dialog = true
      }
      this.$axios.put("/api/Game", { GameId: this.gameId, Guesses: this.wordleGame.words.length, Seconds: this.timeInSeconds})
      console.log(this.gameId);
      console.log(this.wordleGame.words.length);
      console.log(this.timeInSeconds);
      return { type: 'success', text: 'You won! :^)' }
    }
    if (this.wordleGame.state === GameState.Lost) {
      return {
        type: 'warning',
        text: `You lost... :^( The word was ${this.word}`,
      }
    }
    return { type: '', text: '' }
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }

  retrieveUserName(): string {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      return 'Guest'
    } else {
      return userName
    }
  }

  setUserName(userName: string) {
    localStorage.setItem('userName', userName)
    if (this.wordleGame.state === GameState.Won) {
      this.endGameSave()
    }
  }

  startTimer() {
    this.startTime = Date.now() / 1000
    this.intervalID = setInterval(this.updateTimer, 1000)
  }

  updateTimer() {
    this.timeInSeconds = Math.floor(Date.now() / 1000 - this.startTime)
  }

  stopTimer() {
    this.endTime = Date.now() / 1000
    clearInterval(this.intervalID)
  }

  displayTimer() {
    let text = `${
      this.timeInSeconds / 60 / 60 > 1
        ? Math.floor(this.timeInSeconds / 60 / 60) + ':'
        : ''
    }`
    text += `${
      Math.floor((this.timeInSeconds / 60) % 60) < 10
        ? '0' + Math.floor((this.timeInSeconds / 60) % 60)
        : Math.floor((this.timeInSeconds / 60) % 60)
    }:`
    text += `${
      Math.floor(this.timeInSeconds % 60) < 10
        ? '0' + Math.floor(this.timeInSeconds % 60)
        : Math.floor(this.timeInSeconds % 60)
    }`
    return text
  }

  endGameSave() {
    this.$axios.post('/api/Players', {
      name: this.playerName,
      attempts: this.wordleGame.words.length,
      seconds: this.timeInSeconds,
    })
  }
}
</script>
