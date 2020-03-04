using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Joemomma.FPSTutorial
{

    [CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
    public class Gun : ScriptableObject
    {
        public string name;
        public float firerate;
        public GameObject prefab;
    }

}
