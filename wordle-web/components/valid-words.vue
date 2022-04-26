<script lang="ts">
// import {  }
// import {  } from '@/scripts/wordService'
// import { Vue } from 'vue-class-component'

// import Vue from 'vue'
// import Component from 'vue-class-component'

// import { WordsService } from '@/scripts/wordsService'
// @Component
// export default class CandidateWords extends Vue {
//   // remainingWords: string[] = [WordsService.#words]
//   //   guess : string
//   //   public getCandidateWords(guess:string){
//   //       this.guess = guess;
//   //   }

//   static match: string[] = []

//   static getMatches(guess: string): string[] {
//     CandidateWords.match = WordsService.getCandWords(guess)
//     console.log(CandidateWords.match)
//     return CandidateWords.match
//   }
// }

// export default defineComponent({
//     setup() {

//     },
// })
/*
Note: Custom CSS can only be used where specified.

1. Create a custom component to show available words ❌✅
- Add a question mark key to the keyboard. This represents a placeholder for any character ✅
- Create/extend a word list component with a method called validWords that takes a string with 
    question marks and returns an array of valid words ❌✅
- Create unit tests for the validWords method ❌✅
- Display the number of valid words based on the entered letters ❌✅
- When the number is clicked, show a dialog with all the available words with scrolling if 
    there are too many to show on the screen. ❌✅
- When a word is clicked, the word should be entered as the guess but not submitted ❌✅
- Add a hover over for the word so it is obvious that it can be clicked. (No CSS) ❌✅
*/
</script>
