using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Service
{
    /// <summary>
    /// 
    /// This class encapsulates any code that accesses non-public parts of the Blazor API.
    /// 
    /// In order to implement 'scopes' in Lowkoder, Lowkoder must be able to determine the 
    /// ancestoral relationships between components.
    /// Specifically, for any component passed in a call to ILowkoder.CreateSite(ComponentBase scopedComponent), 
    /// lowkoder must be able to find an ancestor of scopedComponent of type Lowkoder.Core.Components.Scope.
    /// The Scope component references an instance of IComponentSite, that instance is the parent site for 
    /// scopedComponent.
    /// 
    /// Anyway, Lowkoder uses a hidden reference to the underlying Renderer to determine these ancestral relationships.
    /// 
    /// </summary>
    class BlazorInterOp
    {
        /**
         * It's assumed that any instance of BlazorInterOp is only used in a context where there's 
         * only a single renderer.
         * So, since the process of fetching the rendere is based on reflection (SLOW), once 
         * the renderer is discovered it's reused for future calls.
         */
        private Renderer _renderer;

        Dictionary<int, object> _componentStateById;
        PropertyInfo _componentIdPropertyInfo;
        PropertyInfo _componentPropertyInfo;
        PropertyInfo _parentComponentPropertyInfo;
        /*
         *  public int ComponentId { get; }
        public IComponent Component { get; }
        public ComponentState ParentComponentState { get; }
         */

        /// <summary>
        /// Finds the closest ancestor of the specified type of the given component
        /// </summary>
        internal TComponent FindFirstAncestor<TComponent>(ComponentBase component)
        {
            var renderer = GetRenderer(component);
            var ancestor = FindFirstAncestor<TComponent>(renderer, component);
            return ancestor;
        }

#pragma warning disable BL0006 // Do not use RenderTree types
        private TComponent FindFirstAncestor<TComponent>(Renderer renderer, ComponentBase component)
#pragma warning restore BL0006 // Do not use RenderTree types
        {
            throw new NotImplementedException();
        }

        private Renderer GetRenderer(ComponentBase component)
        {
            if (_renderer != null)
                return _renderer;
            var renderHandle = GetRenderHandle(component);
            _renderer = GetRenderer(renderHandle);
            GetComponentStatePropertyInfo(_renderer);
            return _renderer;
        }

#pragma warning disable BL0006 // Do not use RenderTree types
        private void GetComponentStatePropertyInfo(Renderer renderer)
#pragma warning restore BL0006 // Do not use RenderTree types
        {
            throw new NotImplementedException();
        }

        private RenderHandle GetRenderHandle(ComponentBase component)
        {
            var componentBaseType = typeof(ComponentBase);
            var rhField = componentBaseType.GetField("_renderHandle", System.Reflection.BindingFlags.NonPublic);
            var rh= (RenderHandle)rhField.GetValue(component);
            return rh;
        }

        private Renderer GetRenderer(RenderHandle renderHandle)
        {
            var typ = typeof(RenderHandle);
            var field = typ.GetField("_renderer", System.Reflection.BindingFlags.NonPublic);
            var r = (Renderer)field.GetValue(renderHandle);
            return r;
        }

        int GetComponentId(object componentState)
        {

        }
        IComponent GetComponent(object componentState)
        {

        }
        public object GetParentComponentState(object componentState)
        {

        }

    }
}
