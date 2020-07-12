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


        IComponent ComponentInstance { get; set; }
        private ParameterView parameterView;

        public LowkoderComponentDecorator()
        {
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(0, ComponentType);
            builder.AddComponentReferenceCapture(1, r => CaptureComponentReference((IComponent)r));
            if (ComponentKey != null)
            {
                builder.AddAttribute(2, "@key", ComponentKey);
            }

            var attribtes= new Dictionary<string,object>(parameterView.ToDictionary());
            attribtes.Remove(nameof(ComponentType));
            builder.AddMultipleAttributes(3, attribtes);

            builder.CloseComponent();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameterView = parameters;
            return base.SetParametersAsync(parameters);
        }

        void CaptureComponentReference(IComponent component)
        {
            ComponentInstance= component;
            ComponentReferenceCaptureAction?.Invoke(component);
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