namespace DocumentConverter.Business.Documents
{
    public class ParsedDocumentModel
    {
        public string Text { get; set; }
        public string Title { get; set; }

        public ParsedDocumentModel(string text, string title)
        {
            Text = text;
            Title = title;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        // Constructor is needed for XML parser, internal to avoid other usage
        internal ParsedDocumentModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
