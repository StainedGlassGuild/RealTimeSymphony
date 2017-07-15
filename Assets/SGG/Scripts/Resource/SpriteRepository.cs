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

using SGG.RTS.Unit;

using UnityEngine;

namespace SGG.RTS.Resource
{
   public sealed class SpriteRepository : MonoBehaviour
   {
      #region Nested types

      public enum SpriteType
      {
         MAIN,
         GLOW
      }

      [Serializable]
      public struct StaveUnitEntry
      {
         public UnitFunction Function;
         public NoteValue Value;
         public Sprite MainSprite;
         public Sprite GlowSprite;
      }

      #endregion

      #region Static fields

      public static SpriteRepository Instance;

      #endregion

      #region Public fields

      [SerializeField, UsedImplicitly]
      private StaveUnitEntry[] m_StaveUnits;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Instance = this;
      }

      public Sprite GetStaveUnitSprite(UnitFunction a_Function, NoteValue a_Value, SpriteType a_Type)
      {
         var spriteEntry = m_StaveUnits.First(a_Entry => a_Entry.Function == a_Function &&
                                                       a_Entry.Value == a_Value);
         return a_Type == SpriteType.MAIN ? spriteEntry.MainSprite : spriteEntry.GlowSprite;
      }

      #endregion
   }
}
