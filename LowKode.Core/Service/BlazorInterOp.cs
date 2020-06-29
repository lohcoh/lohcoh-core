using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Collections;

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
        FieldInfo _rhComponentIdField;

        IDictionary _componentStateById;
        PropertyInfo _csComponentIdPropertyInfo;
        PropertyInfo _csComponentPropertyInfo;
        PropertyInfo _csParentComponentPropertyInfo;
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
        internal int GetComponentId(ComponentBase component)
        {
            var renderHandle = GetRenderHandle(component);
            return GetComponentId(renderHandle);
        }

#pragma warning disable BL0006 // Do not use RenderTree types
        private TComponent FindFirstAncestor<TComponent>(Renderer renderer, ComponentBase component)
#pragma warning restore BL0006 // Do not use RenderTree types
        {
            int componentId= GetComponentId(component);
            object ancestor= FindFirstAncestor<TComponent>(componentId);
            return (TComponent)ancestor;
        }

        /// <summary>
        ///   returns ComponentState of first ancestor with component type == TComponent
        /// </summary>
        private object FindFirstAncestor<TComponent>(int componentId)
        {
            object componentState= _componentStateById[componentId];
            if (componentState == null)
                throw new Exception("Unknown componentId: "+componentId);

            while(true)
            {
                var csParent = GetParentComponentState(componentState);
                if (csParent == null)
                    return null;
                object csComponent = GetComponent(csParent);
                if (csComponent.GetType().IsAssignableFrom(typeof(TComponent)))
                    return csParent;
                componentState= csParent;
            }
        }

        private Renderer GetRenderer(ComponentBase component)
        {
            if (_renderer != null)
                return _renderer;
            var renderHandle = GetRenderHandle(component);
            _rhComponentIdField = typeof(RenderHandle).GetField("_componentId", BindingFlags.Instance | BindingFlags.NonPublic);

            _renderer = GetRenderer(renderHandle);
            GetComponentStatePropertyInfo(_renderer);
            return _renderer;
        }

#pragma warning disable BL0006 // Do not use RenderTree types
        private void GetComponentStatePropertyInfo(Renderer renderer)
#pragma warning restore BL0006 // Do not use RenderTree types
        {

            /*
             * In order to make fetching hierarchy data less inefficient, save a reference to the 
             * renderer's internal component state dictionary.
             */
            var field = typeof(Renderer).GetField("_componentStateById", BindingFlags.Instance | BindingFlags.NonPublic);
            _componentStateById = (IDictionary)field.GetValue(renderer);


            /*
             * We also need to fetch property values from ComponentState objects
             */
            var e = _componentStateById.Values.GetEnumerator();
            e.MoveNext();
            var csInstance = e.Current;
            var csType = csInstance.GetType();
            _csComponentIdPropertyInfo = csType.GetProperty("ComponentId");
            _csComponentPropertyInfo = csType.GetProperty("Component");
            _csParentComponentPropertyInfo = csType.GetProperty("ParentComponentState");
        }

        private RenderHandle GetRenderHandle(ComponentBase component)
        {
            var componentBaseType = typeof(ComponentBase);
            var rhField = componentBaseType.GetField("_renderHandle", BindingFlags.Instance | BindingFlags.NonPublic);
            var rh= (RenderHandle)rhField.GetValue(component);
            return rh;
        }

        private Renderer GetRenderer(RenderHandle renderHandle)
        {
            var typ = typeof(RenderHandle);
            var field = typ.GetField("_renderer", BindingFlags.Instance | BindingFlags.NonPublic);
            var r = (Renderer)field.GetValue(renderHandle);
            return r;
        }
        int GetComponentId(RenderHandle renderHandle)
        {
            return (int)_rhComponentIdField.GetValue(renderHandle);
        }

        int GetComponentId(object componentState)
        {
            return (int)_csComponentIdPropertyInfo.GetValue(componentState);
        }
        IComponent GetComponent(object componentState)
        {
            return (IComponent)_csComponentPropertyInfo.GetValue(componentState);

        }
        public object GetParentComponentState(object componentState)
        {
            return _csParentComponentPropertyInfo.GetValue(componentState);
        }

    }
}
