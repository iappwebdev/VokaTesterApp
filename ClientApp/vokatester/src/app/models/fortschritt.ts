export interface Fortschritt {
    userId: number,
    userUserName: string,
    lektionId: number,
    lektionName: string,
    bereichId?: number,
    bereichName?: string,
    letzteVokabelCorrectId: number
    letzteVokabelCorrectFrz: string,
    letzteVokabelWrongId?: number,
    letzteVokabelWrongFrz?: string,
    isBeginning: boolean
}