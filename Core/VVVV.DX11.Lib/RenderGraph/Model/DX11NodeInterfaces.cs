﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VVVV.Hosting.Interfaces;
using VVVV.Hosting.IO;

namespace VVVV.DX11.RenderGraph.Model
{
    public class DX11NodeInterfaces
    {
        private readonly IInternalPluginHost hoster;
        private readonly IDX11ResourceProvider resourceProvider;
        private readonly IDX11RendererProvider rendererProvider;
        private readonly IDX11RenderWindow renderWindow;
        private readonly IDX11MultiResourceProvider multiResourceProvider;
        private readonly IDX11LayerProvider layerProvider;
        private readonly IDX11ResourceDataRetriever dataRetriever;
        private readonly IDX11UpdateBlocker updateBlocker;

        public DX11NodeInterfaces(IInternalPluginHost hoster)
        {
            this.hoster = hoster;
            this.resourceProvider = this.IsAssignable<IDX11ResourceProvider>() ? this.Instance<IDX11ResourceProvider>() : null;
            this.rendererProvider = this.IsAssignable<IDX11RendererProvider>() ? this.Instance<IDX11RendererProvider>() : null;
            this.renderWindow = this.IsAssignable<IDX11RenderWindow>() ? this.Instance<IDX11RenderWindow>() : null;
            this.multiResourceProvider = this.IsAssignable<IDX11MultiResourceProvider>() ? this.Instance<IDX11MultiResourceProvider>() : null;
            this.layerProvider = this.IsAssignable<IDX11LayerProvider>() ? this.Instance<IDX11LayerProvider>() : null;
            this.dataRetriever = this.IsAssignable<IDX11ResourceDataRetriever>() ? this.Instance<IDX11ResourceDataRetriever>() : null;
            this.updateBlocker = this.IsAssignable<IDX11UpdateBlocker>() ? this.Instance<IDX11UpdateBlocker>() : null;
        }

        public bool IsResourceProvider
        {
            get { return this.resourceProvider != null; }
        }

        public bool IsRendererProvider
        {
            get { return this.rendererProvider != null; }
        }

        public bool IsRenderWindow
        {
            get { return this.renderWindow != null; }
        }

        public bool IsMultiResourceProvider
        {
            get { return this.multiResourceProvider != null; }
        }

        public bool IsLayerProvider
        {
            get { return this.layerProvider != null; }
        }

        public bool IsDataRetriever
        {
            get { return this.dataRetriever != null; }
        }

        public bool IsUpdateBlocker
        {
            get { return this.updateBlocker != null; }
        }

        public IDX11ResourceProvider ResourceProvider
        {
            get { return this.resourceProvider; }
        }

        public IDX11RendererProvider RendererProvider
        {
            get { return this.rendererProvider; }
        }

        public IDX11RenderWindow RenderWindow
        {
            get { return this.renderWindow; }
        }

        public IDX11MultiResourceProvider MultiResourceProvider
        {
            get { return this.multiResourceProvider; }
        }

        public IDX11LayerProvider LayerProvider
        {
            get { return this.layerProvider; }
        }

        public IDX11ResourceDataRetriever DataRetriever
        {
            get { return this.dataRetriever; }
        }

        public IDX11UpdateBlocker UpdateBlocker
        {
            get { return this.updateBlocker; }
        }

        private T Instance<T>()
        {
            IInternalPluginHost iip = (IInternalPluginHost)this.hoster;

            if (iip.Plugin is PluginContainer)
            {
                PluginContainer plugin = (PluginContainer)iip.Plugin;
                return (T)plugin.PluginBase;
            }
            else
            {
                return (T)iip.Plugin;
            }
        }

        private bool IsAssignable<T>()
        {
            IInternalPluginHost iip = (IInternalPluginHost)this.hoster;

            if (iip.Plugin is PluginContainer)
            {
                PluginContainer plugin = (PluginContainer)iip.Plugin;
                return typeof(T).IsAssignableFrom(plugin.PluginBase.GetType());
            }
            else
            {
                return typeof(T).IsAssignableFrom(iip.Plugin.GetType());
            }

        }
    }
}
