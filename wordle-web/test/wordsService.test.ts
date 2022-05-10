import { WordsService } from '@/scripts/wordsService'

describe('Word Service', () => {
  test('Get a word', () => {
    const word = WordsService.getRandomWord()
    expect(word).not.toBeNull()
    expect(word).toHaveLength(5)
    expect(word).not.toHaveLength(4)
  })

  test('Words are private', () => {
    expect((WordsService as any).words).toBeUndefined()
  })
})
describe('Search Results Test', () => {
  test('Finds correct results', () => {
    let candWords = WordsService.validWords('z')
    expect(candWords.length === 1 && candWords[0] === 'zebra')
    candWords = WordsService.validWords('zeb')
    expect(candWords.length === 1 && candWords[0] === 'zebra')
    candWords = WordsService.validWords('??z')
    expect(candWords.length === 4 && candWords.includes('hazel'))
    candWords = WordsService.validWords('?z?z')
    expect(candWords.length === 0)
    candWords = WordsService.validWords('qv')
    expect(candWords.length === 0)
    candWords = WordsService.validWords('')
    expect(candWords.length === 631)
  })
})
