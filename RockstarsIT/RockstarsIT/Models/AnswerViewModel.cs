namespace RockstarsIT.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public int Result { get; set; }
        public string Feedback { get; set; }

        // Nieuwe eigenschap voor symbool
        public string ResultSymbol
        {
            get
            {
                return Result switch
                {
                    0 => "🔴", // Rode cirkel
                    1 => "🟡", // Gele cirkel
                    2 => "🟢", // Groene cirkel
                };
            }
        }
    }
}
