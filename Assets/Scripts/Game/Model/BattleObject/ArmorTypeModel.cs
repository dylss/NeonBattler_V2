

using System;
using Core.Model;

namespace DefaultNamespace
{
    [Serializable]
    public class ArmorTypeModel : Model<ArmorTypeModel>
    {
        public float damageResistanceMultiplier;
    }
}