// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: AUnit.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS.Unit
{
   public abstract class AUnit : MonoBehaviour
   {
      #region Properties

      public Vector2 Destination { get; set; }

      public Team Team { get; set; }

      public Color Color
      {
         get { return MainRenderer.material.color; }
         set { MainRenderer.material.color = value; }
      }

      public Color GlowColor
      {
         get { return GlowRenderer.material.color; }
         set { GlowRenderer.material.color = value; }
      }

      public abstract string UnitTypeName { get; }

      public Vector2 Position
      {
         get
         {
            var pos3D = transform.position;
            return new Vector2(pos3D.x, pos3D.y);
         }

         set { transform.position = value; }
      }

      private SpriteRenderer MainRenderer
      {
         get { return GetComponent<SpriteRenderer>(); }
      }

      private SpriteRenderer GlowRenderer
      {
         get { return transform.GetChild(0).GetComponentInChildren<SpriteRenderer>(); }
      }

      #endregion

      #region Methods

      protected void Initialize(Team a_Team, Sprite a_MainSprite, Sprite a_GlowSprite)
      {
         Team = a_Team;
         Color = a_Team.Color;
         MainRenderer.sprite = a_MainSprite;
         GlowRenderer.sprite = a_GlowSprite;
      }

      #endregion
   }
}
