export interface CheckResult {
    vokabelId: number,
    isCorrect: boolean,
    isSimilar: boolean,
    truth: string,
    phonetik: string,
    answer: string,
    truthSan: string,
    answerSan: string,
    truthArticle: string,
    answerArticle: string,
    isArtikelFehler: boolean,
    hasMultipleCorrectAnswers: boolean,
    furtherCorrectAnswers: string[],
    furtherCorrectAnswersSan: string[],
    similarityResult: SimilarityResult
}

export interface SimilarityResult {
    truth: string;
    answer: string;
    isAnswerEqual: boolean;
    isAnswerSimilar: boolean;
    isAnswerSimilarA: boolean;
    isAnswerSimilarC: boolean;
    isAnswerSimilarE: boolean;
    isAnswerSimilarI: boolean;
    isAnswerSimilarU: boolean;
    stringSimilaritiesLevenshtein: StringSimilaritiesLevenshtein;
    stringSimilaritiesOthers: StringSimilarities;
    editOperationsLeventhein: EditOperations[];
    numWrongCharsTruth: number;
    numWrongCharsAnswer: number;
}

interface StringSimilarities {
    dist_Metric_Damerau: number;
    longestCommonSubsequence: number;
    distance_JaroWinkler: number;
    similarity_JaroWinkler: number;
    subsequence_LongestCommonSubsequenceLength: number;
    dist_norm_NGram: number;
    optimalStringAlignment: number;
}

interface StringSimilaritiesLevenshtein {
    dist_Levenshtein: number;
    dist_Normalized_Levenshtein: number;
    similiarity_NormalizedLevenshtein: number;
    dist_Weighted: number;
    dist_WeightedA: number;
    dist_WeightedC: number;
    dist_WeightedE: number;
    dist_WeightedI: number;
    dist_WeightedU: number;
    levenstheinMethod: LevenstheinMethod[];
}

interface LevenstheinMethod {
    operation: number;
    operationStr: string;
    value: string;
}

interface EditOperations {
    key: number,
    value: string
}