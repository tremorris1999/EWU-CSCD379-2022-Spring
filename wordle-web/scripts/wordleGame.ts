import { Word } from './word'

export enum GameState {
  Active = 0,
  Won = 1,
  Lost = 2,
}

export class WordleGame {
  constructor(word: string) {
    this.words.push(new Word())
    this.word = word
  }

  maxGuesses = 6;

  private word: string
  words: Word[] = []
  state: GameState = GameState.Active

  get currentWord(): Word {
    return this.words[this.words.length - 1]
  }

  submitWord() {
    if (this.currentWord.evaluateWord(this.word)) {
      this.state = GameState.Won
    } else if (this.words.length === this.maxGuesses) {
      this.state = GameState.Lost
    } else {
      this.words.push(new Word())
    }
  }
}
