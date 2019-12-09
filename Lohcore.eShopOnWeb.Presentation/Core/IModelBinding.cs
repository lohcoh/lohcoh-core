using System;

namespace Lowkode.Client.Core
{
    public interface IModelBinding
    {
        Type ModelType {  get; set; }
        IModelPartSelector ModelPartSelector {  get; set; }
    }
}