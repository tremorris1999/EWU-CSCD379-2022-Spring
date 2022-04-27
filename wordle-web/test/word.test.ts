import { Word } from '@/scripts/word'
import { LetterStatus } from '~/scripts/letter'

describe('Word Test', () => {
  test('is an instance', () => {
    const word = new Word()
    expect(word).toBeTruthy()
    word.addLetter('A')
    expect(word.length).toEqual(1)
    word.removeLetter()
    expect(word.length).toEqual(0)
  })
})

describe('Word Text', () => {
  test('Get word text', () => {
    const word = new Word()
    word.addLetter('A')
    word.addLetter('P')
    word.addLetter('P')
    word.addLetter('L')
    word.addLetter('E')
    expect(word.text).toBe('APPLE')
  })
})

describe('Word Evaluation', () => {
  test('Wrong Word', () => {
    const word = new Word()
    word.addLetter('A')
    word.addLetter('P')
    word.addLetter('P')
    word.addLetter('L')
    word.addLetter('E')
    expect(word.evaluateWord('PAPAL')).toBe(false)
    expect(word.letters[0].status).toBe(LetterStatus.WrongPlace)
    expect(word.letters[1].status).toBe(LetterStatus.WrongPlace)
    expect(word.letters[2].status).toBe(LetterStatus.Correct)
    expect(word.letters[3].status).toBe(LetterStatus.WrongPlace)
    expect(word.letters[4].status).toBe(LetterStatus.Wrong)
  })

  test('Wrong Word Correct Stats', () => {
    const word = new Word()
    word.addLetter('O')
    word.addLetter('E')
    word.addLetter('L')
    word.addLetter('L')
    word.addLetter('O')
    expect(word.evaluateWord('HELLO')).toBe(false)
    expect(word.letters[0].status).toBe(LetterStatus.Wrong)
    expect(word.letters[1].status).toBe(LetterStatus.Correct)
    expect(word.letters[2].status).toBe(LetterStatus.Correct)
    expect(word.letters[3].status).toBe(LetterStatus.Correct)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })

  test('Correct Word', () => {
    const word = new Word()
    word.addLetter('A')
    word.addLetter('P')
    word.addLetter('P')
    word.addLetter('L')
    word.addLetter('E')
    expect(word.evaluateWord('APPLE')).toBe(true)
    expect(word.letters[0].status).toBe(LetterStatus.Correct)
    expect(word.letters[1].status).toBe(LetterStatus.Correct)
    expect(word.letters[2].status).toBe(LetterStatus.Correct)
    expect(word.letters[3].status).toBe(LetterStatus.Correct)
    expect(word.letters[4].status).toBe(LetterStatus.Correct)
  })
})
