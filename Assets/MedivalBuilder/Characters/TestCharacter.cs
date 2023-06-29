using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Inventory;
using UnityEngine;
using Zenject;

namespace MedivalBuilder.Characters
{
    public class TestCharacter : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform target2;
        
        private CharacterController _characterController;
        
        [Inject]
        private void Inject(CharactersFactory charactersFactory)
        {
            _characterController = charactersFactory.Create();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _characterController.SetWalk(target.position);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _characterController.SetWalk(target2.position);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _characterController.SetIdle();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _characterController.SetPickup(new Item());
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _characterController.SetBuild(3f);
            }
        }
    }
}