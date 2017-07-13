// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: SpriteRepository.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;
using System.Linq;

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS.Resource
{
   public sealed class SpriteRepository : MonoBehaviour
   {
      #region Nested types

      [Serializable]
      public struct StaveUnitEntry
      {
         public UnitFunction Function;
         public NoteValue Value;
         public Sprite MainSprite;
      }

      #endregion

      #region Static fields

      public static SpriteRepository Instance;

      #endregion

      #region Public fields

      [SerializeField]
      public StaveUnitEntry[] StaveUnits;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Instance = this;
      }

      public Sprite GetStaveUnitSprite(UnitFunction a_Function, NoteValue a_Value)
      {
         return StaveUnits.First(a_Entry => a_Entry.Function == a_Function &&
                                            a_Entry.Value == a_Value).MainSprite;
      }

      #endregion
   }
}
