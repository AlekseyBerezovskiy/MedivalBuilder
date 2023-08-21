using System;
using System.Collections.Generic;
using MedivalBuilder.Characters.Interfaces;

namespace MedivalBuilder.Characters
{
    public class CharactersesStorage : ICharactersStorage
    {
        private List<CharacterController> _charactersStorage = new List<CharacterController>();
        
        public void Add(CharacterController characterController)
        {
            if (_charactersStorage.Contains(characterController))
            {
                return;
            }
            
            _charactersStorage.Add(characterController);
        }

        public CharacterController Get()
        {
            if (_charactersStorage.Count > 0)
            {
                return _charactersStorage[0];
            }

            return null;
        }
    }
}