// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: AEntity.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS.World.Entity
{
   public abstract class AEntity : MonoBehaviour
   {
      #region Properties

      public AEntityAppearance Appreance
      {
         get { return GetComponentInChildren<AEntityAppearance>(); }
      }

      public abstract string Name { get; }

      public abstract EntityType Type { get; }

      public Team Team { get; set; }

      public Vector2 Position
      {
         get
         {
            var pos3D = transform.position;
            return new Vector2(pos3D.x, pos3D.y);
         }

         set { transform.position = value; }
      }

      #endregion

      #region Methods

      protected void Initialize(Team a_Team)
      {
         Team = a_Team;
      }

      #endregion
   }
}
