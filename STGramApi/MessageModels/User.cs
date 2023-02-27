namespace STGramApi.MessageModels
{
    public class User
    {
        public long Id { get; set; }
        public bool Is_bot { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Username { get; set; }
        public string Language_code { get; set; }
        public bool Is_premium { get; set; }
        public bool Added_to_attachment_menu { get; set; }
        public bool Can_join_groups { get; set; }
        public bool Can_read_all_group_messages { get; set; }
        public bool Supports_inline_queries { get; set; }
    }
}
