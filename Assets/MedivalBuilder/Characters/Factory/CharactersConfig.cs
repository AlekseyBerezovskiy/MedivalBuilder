using System;
using UnityEngine;

namespace MedivalBuilder.Characters.Factory
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Config/CharactersConfig")]
    public class CharactersConfig : ScriptableObject
    {
        public CharactersData data;
    }

    [Serializable]
    public struct CharactersData
    {
        public float Speed;
    }
}