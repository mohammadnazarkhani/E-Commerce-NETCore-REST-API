namespace TondForoosh.Api.Common
{
    // This interface defines the method UpdateEntity for entities that can be updated.
    public interface IUpdatable<TDto>
    {
        // This method will update the entity properties based on the data from the DTO.
        void UpdateEntity(TDto dto);
    }
}
