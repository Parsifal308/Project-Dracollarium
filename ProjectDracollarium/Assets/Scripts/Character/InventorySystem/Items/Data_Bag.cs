using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Dracollarium.Items
{
    public class Data_Bag : Data_Container
    {
        [Header("BAG INFORMATION:"), Space(10)]
        [SerializeField] private Database_Bag bagData;
        [SerializeField] private float effectIntensity;
        [SerializeField] private float quality;

        [Header("-> TESTING <-"), Space(10)]
        public GameObject itemA;
        public GameObject itemB;

        public override Database_Item GetData { get { return bagData; } }
        public override float EffectIntensity { get { return effectIntensity; } set { effectIntensity = value; } }
        public override float Quality { get { return quality; } set { quality = value; } }
    }
}