// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: ASpriteEntity.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS.World.Entity
{
   public abstract class ASpriteEntity : AEntity
   {
      #region Properties

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

      protected SpriteRenderer MainRenderer
      {
         get { return GetComponent<SpriteRenderer>(); }
      }

      protected SpriteRenderer GlowRenderer
      {
         get { return transform.GetChild(0).GetComponentInChildren<SpriteRenderer>(); }
      }

      #endregion

      #region Methods

      protected void Initialize(Team a_Team, Sprite a_MainSprite, Sprite a_GlowSprite)
      {
         Initialize(a_Team);
         Color = a_Team.Color;
         MainRenderer.sprite = a_MainSprite;
         GlowRenderer.sprite = a_GlowSprite;
      }

      #endregion
   }
}
