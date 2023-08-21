namespace MedivalBuilder.Characters.Interfaces
{
    public interface ICharactersStorage
    {
        void Add(CharacterController characterController);
        CharacterController Get();
    }
}