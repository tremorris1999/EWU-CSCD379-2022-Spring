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

  get letterColor(): string {
    return Letter.getColorCode(this.status)
  }

  static getColorCode(status: LetterStatus) {
    switch (status) {
      case LetterStatus.Unknown: {
        return ''
      }
      case LetterStatus.Correct: {
        return 'success'
      }
      case LetterStatus.WrongPlace: {
        return 'warning'
      }
      case LetterStatus.Wrong: {
        return 'error'
      }
    }
  }
}
