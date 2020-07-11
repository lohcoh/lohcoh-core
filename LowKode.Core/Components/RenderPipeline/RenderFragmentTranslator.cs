using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using System;

namespace LowKode.Core.Components
{
    internal class RenderFragmentTranslator
    {
        private RenderFragment childContent;
        private ArrayRange<RenderTreeFrame> frames;


        Action<RenderTreeBuilder> Translate(RenderFragment childContent)
        {
            var builder = new RenderTreeBuilder();
            childContent(builder);
            frames = builder.GetFrames();
            return BuildRenderTree;
        }

        void BuildRenderTree(RenderTreeBuilder builder)
        {
            BuildRenderTree(builder, frames.Array.AsSpan<RenderTreeFrame>());
        }

#pragma warning disable BL0006 // Do not use RenderTree types
        void BuildRenderTree(RenderTreeBuilder builder, Span<RenderTreeFrame> frames)
        {
            var aFrames = frames.ToArray();
            for (int iFrame = 0; iFrame < aFrames.Length; iFrame++)
            {
                var frame = aFrames[iFrame];
                switch (frame.FrameType)
                {
                    case RenderTreeFrameType.None:
                        break;
                    case RenderTreeFrameType.Element:
                        break;
                    case RenderTreeFrameType.Text:
                        break;
                    case RenderTreeFrameType.Attribute:
                        break;
                    case RenderTreeFrameType.Component:
                        builder.Ope
                        break;
                    case RenderTreeFrameType.Region:
                        builder.OpenRegion(frame.Sequence);
                        BuildRenderTree(builder, new ArrayRange(frames.Array.AsSpanframes.)
                        for (int iSubtree = 0; iSubtree < frame.RegionSubtreeLength; iSubtree++)
                        {

                        }
                        break;
                    case RenderTreeFrameType.ElementReferenceCapture:
                        break;
                    case RenderTreeFrameType.ComponentReferenceCapture:
                        break;
                    case RenderTreeFrameType.Markup:
                        builder.AddMarkupContent(frame.Sequence, frame.MarkupContent);
                        break;
                    default:
                        throw new Exception("Unknown frame type:" + frame.FrameType);

                }
            }
        }
#pragma warning restore BL0006 // Do not use RenderTree types

    }
}