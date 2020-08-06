namespace VokaTester.Features.Fortschritt.Dto
{
    public class FortschrittDto
    {
        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public int LektionId { get; set; }

        public string LektionName { get; set; }

        public int LetzteVokabelCorrectId { get; set; }

        public string LetzteVokabelCorrectFrz { get; set; }

        public int? LetzteVokabelWrongId { get; set; }

        public string LetzteVokabelWrongFrz { get; set; }

        public bool IsBeginning { get; set; }
    }
}
