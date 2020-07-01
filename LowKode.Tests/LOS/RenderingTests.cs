using LowKode.Core;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LowKode.Tests
{

    [TestClass]
    public class RenderingTests
    {

        /// <summary>
        /// This test reproduces a specific rendering example which, at the time this test was written, was not working.
        /// Here, editFieldsRoot is the root scope of a form that will display a Starship instance.
        /// Scopes (branches) are created for each property in Starship, and ComponentSiteSpecification.ModelMember is 
        /// assigned in each property scope.
        /// The problem is that later, when the components in each property site are rendered, the 
        /// ComponentSiteSpecification.ModelMember is always the value of the last property.
        /// </summary>
        [TestMethod]
        public void Test_EditFields()
        {
            var los = new LosObjectSystem();
            var master = los.Master;
            master.Put(new LowkoderRoot());

            var lowkoderRoot= master.Get<LowkoderRoot>();
            lowkoderRoot.Context.ComponentSiteSpecification.Model = new Starship();
            var modelMetadata = Core.Metadata.TypeDescriptor.ForSystemType(typeof(Starship));
            lowkoderRoot.Context.ComponentSiteSpecification.ModelType = modelMetadata;

            var propertyRoots= new List<ILosRoot>();
            var memberPaths = new Dictionary<ILosRoot, MemberPath>();
            foreach(var property in modelMetadata.Properties)
            {
                var memberPath = property.ToMemberPath();

                var propertyRoot = master.Branch();
                var lkRoot = propertyRoot.Get<LowkoderRoot>();
                lkRoot.Context.ComponentSiteSpecification.ModelMember = memberPath;

                propertyRoots.Add(propertyRoot);
                memberPaths.Add(propertyRoot, memberPath);
            }

            foreach (var propertyRoot in propertyRoots)
            {
                var originalPath = memberPaths[propertyRoot];
                var lkRoot = propertyRoot.Get<LowkoderRoot>();
                var savedPath= lkRoot.Context.ComponentSiteSpecification.ModelMember;
                Assert.AreEqual(originalPath.TargetProperty.Name, savedPath.TargetProperty.Name);
            }

        }
    }

    class Starship
    {
        public string Identifier { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
