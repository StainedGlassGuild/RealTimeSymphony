// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: ComponentExtensions.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS.Utils
{
   public static class ComponentExtensions
   {
      #region Static methods

      public static T CreateComponentInNewChildGameObj<T>(this Component a_Component)
         where T : Component
      {
         return a_Component.CreateComponentInNewChildGameObj<T>(typeof(T).Name);
      }

      public static T CreateComponentInNewChildGameObj<T>(this Component a_Component,
                                                          string a_ObjName)
         where T : Component
      {
         var obj = new GameObject(a_ObjName, typeof(T));
         obj.transform.parent = a_Component.transform;
         return obj.GetComponent<T>();
      }

      #endregion
   }
}
