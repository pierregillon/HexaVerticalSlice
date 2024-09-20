using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class FeedDisplayDbContext(
    DbContextOptions<FeedDisplayDbContext> options
) : DbContext(options);