export enum LetterStatus {
  Unknown = 0,
  Correct = 1,
  WrongPlace = 2,
  Wrong = 3,
}

export class Letter {
  constructor(char: string) {
    this.char = char
  }

  char: string
  status: LetterStatus = LetterStatus.Unknown
}
