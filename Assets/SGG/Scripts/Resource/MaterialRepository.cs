// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: MaterialRepository.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS.Resource
{
   public sealed class MaterialRepository : MonoBehaviour
   {
      #region Static fields

      public static MaterialRepository Instance;

      #endregion

      #region Public fields

      public Material TileMaterial;
      public Material BackgroundMaterial;

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
