namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs;

public record InterfaceTypeCollection(IReadOnlyCollection<Type> BaseInterfaces)
{
    public bool IsValid(Type type) =>
        type.GetInterfaces().Any(Match);

    private bool Match(Type interfaceToCheck) =>
        BaseInterfaces.Any(baseInterface =>
            (!baseInterface.IsGenericType && interfaceToCheck == baseInterface)
            || (baseInterface.IsGenericType
                && interfaceToCheck.IsGenericType
                && interfaceToCheck.GetGenericTypeDefinition() == baseInterface)
        );
}