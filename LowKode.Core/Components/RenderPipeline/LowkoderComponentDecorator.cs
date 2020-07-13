using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LowKode.Core.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LowKode.Core.Components
{
    public class LowkoderComponentDecorator : ComponentBase, IDisposable
    {
        [Parameter]
        public Type ComponentType {  get; set; }
        [Parameter]
        public Action<object> ComponentReferenceCaptureAction { get; set; }
        [Parameter]
        public object ComponentKey { get; set; }

        public ILowkoderService Lowkoder { get; set; }

        /// <summary>
        /// This is a reference to the decorated component.
        /// Blazor will call the CaptureComponentReference method when then decorated 
        /// component is rendered.
        /// </summary>
        IComponent ComponentInstance { get; set; }

        /// <summary>
        /// parameters meant for the decored component
        /// </summary>
        private Dictionary<string,object> parameterView;

        public LowkoderComponentDecorator()
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, ComponentType);
            builder.AddMultipleAttributes(1, parameterView);
            builder.AddComponentReferenceCapture(2, r => CaptureComponentReference((IComponent)r));           
            builder.CloseComponent();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            /*
             * The given parameters contain the original parameters meant for the 
             * decorated component *and* parameters for this component.
             * Separate this component's params from the decorated components params .
             * Save params meant for decorated component fr later.
             */
            var thisParams = new Dictionary<string, object>();
            thisParams[nameof(ComponentType)] = parameters.GetValueOrDefault<Type>(nameof(ComponentType));
            thisParams[nameof(ComponentReferenceCaptureAction)] = parameters.GetValueOrDefault<Action<object>>(nameof(ComponentReferenceCaptureAction));
            {
                object key;
                if (parameters.TryGetValue("@key", out key))
                {
                    thisParams["@key"] = key;
                }
            }


            var decorParams = new Dictionary<string,object>(parameters.ToDictionary());
            decorParams.Remove(nameof(ComponentType));
            decorParams.Remove(nameof(ComponentKey));
            decorParams.Remove(nameof(ComponentReferenceCaptureAction));
            parameterView = decorParams;

            return base.SetParametersAsync(ParameterView.FromDictionary(thisParams));
        }

        void CaptureComponentReference(IComponent component)
        {
            ComponentInstance= component;
            //ComponentReferenceCaptureAction?.Invoke(component);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override bool ShouldRender()
        {
            // todo: the ShouldRender method is protected.  Should I use reflection to access it?
            //if (ComponentInstance is ComponentBase)
            //    return ((ComponentBase)ComponentInstance).ShouldRender();

            return base.ShouldRender();
        }

        public void Dispose()
        {
            if (ComponentInstance is IDisposable)
            {
                ((IDisposable)ComponentInstance).Dispose();
            }
        }
    }
}