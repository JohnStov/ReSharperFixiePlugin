using System.Threading;
using JetBrains.Metadata.Reader.API;
using JetBrains.ProjectModel;
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
            
        }
    }
}