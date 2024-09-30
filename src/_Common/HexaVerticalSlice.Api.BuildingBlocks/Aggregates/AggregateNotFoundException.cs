namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public class AggregateNotFoundException(IAggregateId aggregateId, Type aggregateType)
    : Exception($"The {aggregateType.Name} aggregate with id '{aggregateId.Value}' could not be found.");
