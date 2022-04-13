namespace Api_imdb.DTO
{
    public class VoteDTO
    {
        public int IdVoto { get; set; }
        public int IdMovie { get; set; }
        public string TitleMovie { get; set; }
        public short ValueVote { get; set; }
        public int? CountVotesMovie { get; set; }

    }
}
