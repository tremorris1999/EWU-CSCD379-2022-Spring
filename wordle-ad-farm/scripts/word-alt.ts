import { Letter } from '~/scripts/letter';
import { LetterStatus } from '~/scripts/letter';
import WordService from './wordsService';

export class Word
{
    readonly max: number;
    readonly letters: Letter[] = [];

    constructor(word: string, max: number)
    {
        for(var i = 0; i < max; i++)
        {
            this.letters.push(new Letter(word.charAt(i)));
        }

        this.max = max;
    }

    contains(letter: Letter): boolean
    {
        for (const l of this.letters)
        {
            if(l.char === letter.char)
                return true;
        }

        return false;
    }

    get text()
    {
        return this.letters.map(word => word.char).join('');
    }

    evaluateWord(word: Word): boolean
    {
        let result: boolean = true;
        let copy: Word = new Word(this.text, this.max);
        for(var i = 0; i < this.max; i++)
        {
            if(this.letters[i].char === word.letters[i].char && copy.contains(word.letters[i]))
            {
                word.letters[i].status = LetterStatus.Correct;
                copy.letters.splice(i, 1);
            }
            else if(this.contains(word.letters[i]) && copy.contains(word.letters[i]))
            {
                word.letters[i].status = LetterStatus.Misplaced;
                copy.letters.splice(i, 1);
                result = false;
            }
            else
            {
                word.letters[i].status = LetterStatus.Incorrect;
                result = false;
            }
        }

        return result;
    }

}