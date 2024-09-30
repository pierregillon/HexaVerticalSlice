namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

public record CommentDescription
{
    public CommentDescription(string Value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(Value));
        }

        this.Value = Value;
    }

    public string Value { get; init; }
}