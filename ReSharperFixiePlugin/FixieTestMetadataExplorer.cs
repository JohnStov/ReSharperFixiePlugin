using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Metadata.Reader.API;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Impl;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.ReSharper.UnitTestFramework;

namespace ReSharperFixiePlugin
{
    public class FixieTestMetadataExplorer
    {
        public FixieTestMetadataExplorer(FixieTestProvider provider, UnitTestElementFactory unitTestElementFactory)
        {
        }

        public void ExploreAssembly(IProject project, IMetadataAssembly assembly, IUnitTestElementsObserver observer,
            CancellationToken cancellationToken)
        {
            // No point going further if we dn't hold a Fixie reference
            if (!ProjectHasFixieReference(project))
                return;

            using (ReadLockCookie.Create())
            {
                foreach (var metadataTypeInfo in GetExportedTypes(assembly.GetTypes()))
                {
                    if (!cancellationToken.IsCancellationRequested)
                        ExploreType(project, assembly, observer, metadataTypeInfo);
                }
            }

        }

        private bool ProjectHasFixieReference(IProject project)
        {
            return project.GetModuleReferences(TargetFrameworkId.Default).Any(reference => reference.Name == "Fixie");
        }

        private void ExploreType(IProject project, IMetadataAssembly assembly, IUnitTestElementsObserver observer, IMetadataTypeInfo metadataTypeInfo)
        {
        }

        private static IEnumerable<IMetadataTypeInfo> GetExportedTypes(IMetadataTypeInfo[] types)
        {
            return (types ?? Enumerable.Empty<IMetadataTypeInfo>()).Where(IsPublic);
        }

        private static bool IsPublic(IMetadataTypeInfo type)
        {
            return (type.IsNested && type.IsNestedPublic) || type.IsPublic;
        }

    }
}