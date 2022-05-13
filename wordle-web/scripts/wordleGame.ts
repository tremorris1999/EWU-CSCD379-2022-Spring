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
    this.player = [this.user, 1, 6]
  }

  private word: string
  private user: string
  private player: [name: string, guesses: number, seconds: number]
  words: Word[] = []
  state: GameState = GameState.Active
  readonly maxGuesses = 6
  private time: number = 0

  setUser(userName: string) {
    this.user = userName
  }

  setTime(t: number) {
    this.time = t
  }

  getPlayer(): [name: string, guesses: number, seconds: number] {
    return this.player
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
      this.player = [this.user, this.words.length, this.time]

      // DONE: get username
      // TODO: guesses = this.words.length
      // TODO: track time
      // TODO: POST (name, guesses, second)
      //
    } else if (this.words.length === this.maxGuesses) {
      this.state = GameState.Lost
    } else {
      this.words.push(new Word())
    }
  }
}
