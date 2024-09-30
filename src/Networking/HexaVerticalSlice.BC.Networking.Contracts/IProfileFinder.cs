namespace HexaVerticalSlice.BC.Networking.Contracts;

public interface IProfileFinder
{
    Task<Guid> FindFromUserId(Guid userId);
    Task<IReadOnlyCollection<ProfileDetails>> GetDetails(IEnumerable<Guid> profileIds);
}

public record ProfileDetails(Guid Id, string EmailAddress);