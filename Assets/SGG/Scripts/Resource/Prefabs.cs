// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Prefabs.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS.Resource
{
   public sealed class Prefabs : MonoBehaviour
   {
      #region Static fields

      public static Prefabs Instance;

      #endregion

      #region Public fields

      public GameObject TestUnit;
      public GameObject SelectionBox;
      public GameObject GameObjSelectionElem;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Instance = this;
      }

      #endregion
   }
}
