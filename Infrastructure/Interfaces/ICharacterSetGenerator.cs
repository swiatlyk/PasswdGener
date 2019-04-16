using Infrastructure.DTO;

namespace Infrastructure.Interfaces
{
    public interface ICharacterSetGenerator
    {
        string Generate(GeneratorConfig dto);
    }
}