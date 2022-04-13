export enum LetterStatus
{
    Unknown = 0,
    Correct = 1,
    WrongPlace = 2,
    Wrong = 3
}

export class Letter
{
    char: string;
    status: LetterStatus;

    constructor(char: string)
    {
        this.char = char;
        this.status = LetterStatus.Unknown;
    }
}