namespace STGramApi.MessageModels
{
    class Sticker : BaseDocumentComponents
    {
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Is_animated { get; set; }
        public bool Is_video { get; set; }
        public PhotoSize Thumb { get; set; } = new PhotoSize();
        public string Emoji { get; set; }
        public string Set_name { get; set; }
        public File Premium_animation { get; set; } = new File();
        public MaskPosition Mask_position { get; set; } = new MaskPosition();
        public string Custom_emoji_id { get; set; }

    }
}
