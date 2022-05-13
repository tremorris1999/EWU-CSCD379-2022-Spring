import { LetterStatus } from './letter'
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
    this.user = 'Guest'
  }

  private word: string
  private user: string
  words: Word[] = []
  state: GameState = GameState.Active
  readonly maxGuesses = 6
  private time: number

  setUser(userName: string) {
    this.user = userName
  }

  setTime(t: number) {
    this.time = t
  }

  get currentWord(): Word {
    return this.words[this.words.length - 1]
  }

  get gameOver(): Boolean {
    return this.state === GameState.Won || this.state === GameState.Lost
  }

  get correctChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    return allLetters
      .filter((x) => x.status === LetterStatus.Correct)
      .map((x) => x.char)
  }

  get wrongPlaceChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    const wrongPlaceLetters = allLetters
      .filter((x) => x.status === LetterStatus.WrongPlace)
      .map((x) => x.char)
    return wrongPlaceLetters.filter((x) => !this.correctChars.includes(x))
  }

  get wrongChars() {
    const allLetters = this.words.map((x) => x.letters).flat()
    return allLetters
      .filter((x) => x.status === LetterStatus.Wrong)
      .map((x) => x.char)
  }

  submitWord() {
    if (this.currentWord.evaluateWord(this.word)) {
      this.state = GameState.Won
      // DONE: get username
      // TODO: guesses = this.words.length
      // TODO: track time
      // TODO: POST (name, guesses, second)
      this.$axios.POST('api/PlayerService', {
        name: this.user,
        guesses: this.words.length,
        seconds: this.time,
      })
    } else if (this.words.length === this.maxGuesses) {
      this.state = GameState.Lost
      this.$axios.POST('api/PlayerService', {
        name: this.user,
        guesses: this.words.length,
        seconds: this.time,
      })
    } else {
      this.words.push(new Word())
    }
  }
}
