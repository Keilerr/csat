﻿#region --- MIT License ---
/* Licensed under the MIT/X11 license.
 * Copyright (c) 2011 mjt
 * This notice may not be removed from any source distribution.
 * See license.txt for licensing details.
 */
#endregion
using System.Collections.Generic;
using System;
using System.Collections;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace CSatEng
{
    public class Model : SceneNode, ICloneable
    {
        public Vertex[] VertexBuffer;
        public ushort[] IndexBuffer; // tämä on 0,1,2,3,4,..
        public VBO Vbo;
        public BoundingSphere Boundings;
        public MaterialInfo Material = new MaterialInfo();
        public string MaterialName = "";

        public bool DoubleSided = false;
        public bool IsTransparent = false;
        public bool CastShadow = true;
        public bool Visible = true;

        public virtual void SetDoubleSided(string name, bool doublesided) { }

        public virtual void LoadMD5Animation(string animName, string fileName) { }
        public virtual void SetAnimation(string animName) { }
        public virtual void Update(float time) { }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public Model Clone()
        {
            Model clone = (Model)this.MemberwiseClone();
            // eri grouppi eli kloonattuihin objekteihin voi lisäillä muita objekteja sen vaikuttamatta alkuperäiseen.
            clone.Childs = new List<SceneNode>(Childs);
            return clone;
        }
    }
}
