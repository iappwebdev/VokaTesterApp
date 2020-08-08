export interface TestResult {
    id: number;
    userName: string;
    vokabelId: number;
    bereichName: string;
    lektionName: string;
    question: string;
    phonetik: string;
    truth: string;
    truthSan: string;
    answer: string;
    answerSan: string;
    isCorrect: true;
    isSimilar: false;
    isArtikelFehler: false;
    isSimilarAndArtikelFehler: false;
    isWrong: false;
    dateTested: string;
    similarityResult: null;
}