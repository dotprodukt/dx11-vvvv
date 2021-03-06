﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D11;

using VVVV.PluginInterfaces.V1;

using FeralTic.DX11;
using FeralTic.DX11.Resources;

namespace VVVV.DX11
{

    [Obsolete("This does access IPluginIO, which fails in case of multi core access, this will be removed in next release, use RenderTaskDelegate instead")]
    public delegate void RenderDelegate<T>(IPluginIO pin, DX11RenderContext context, T settings);

    public delegate void RenderTaskDelegate<T>(IPluginIO pin, DX11RenderContext context, T settings);

    public class DX11BaseLayer<T> : IDX11Resource
    {
        public RenderDelegate<T> Render;

        public bool PostUpdate
        {
            get { return true; }
        }

        public void Dispose()
        {
            
        }
    }

    /// <summary>
    /// DX11 Layer provide simple interface to tell which pin they need
    /// </summary>
    public class DX11Layer : DX11BaseLayer<DX11RenderSettings>
    {
    }

    public class DX11Shader: IDX11Resource
    {
        public DX11ShaderInstance Shader
        {
            get;
            private set;
        }

        public DX11Shader(DX11ShaderInstance instance)
        {
            this.Shader = instance;
        }

        public void Dispose()
        {
            //Owned, do nothing
        }
    }

    public class DX11Layout : IDX11Resource
    {
        public InputLayout Layout
        {
            get;
            private set;
        }

        public DX11Layout(InputLayout layout)
        {
            this.Layout = layout;
        }

        public void Dispose()
        {
            if (this.Layout != null)
            {
                this.Layout.Dispose();
                this.Layout = null;
            }
            
        }
    }
}
