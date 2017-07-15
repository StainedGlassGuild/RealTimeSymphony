// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: WorldGenerationScript.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System;
using System.Collections.Generic;

namespace SGG.RTS.World
{
   [Serializable]
   public struct WorldGenerationScript
   {
      #region Nested types

      [Serializable]
      public struct ObjectEntry
      {
         public string Type;
         public uint[] Pos;
      }

      #endregion

      #region Public fields

      public List<ObjectEntry> Objects;

      #endregion
   }
}
