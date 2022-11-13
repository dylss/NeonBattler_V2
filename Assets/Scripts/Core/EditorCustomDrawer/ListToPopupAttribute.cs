using System;
using UnityEngine;

namespace Editor
{
    public class ListToPopupAttribute : PropertyAttribute
    {
        public Type myType;
        public string propertyName;

        public ListToPopupAttribute(Type myType, string propertyName)
        {
            this.myType = myType;
            this.propertyName = propertyName;
        }
    }
}