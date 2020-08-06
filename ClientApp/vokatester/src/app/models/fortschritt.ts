export interface Fortschritt {
    userId: number,
    userUserName: string,
    lektionId: number,
    lektionName: string,
    letzteVokabelCorrectId: number
    letzteVokabelCorrectFrz: string,
    letzteVokabelWrongId: number | null
    letzteVokabelWrongFrz: string | null,
    isBeginning: boolean
}