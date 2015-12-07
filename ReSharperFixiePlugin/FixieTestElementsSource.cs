using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using JetBrains.Application;
using JetBrains.Metadata.Reader.API;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Search;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.UnitTestFramework;
using JetBrains.Util;
using JetBrains.Util.Logging;

namespace ReSharperFixiePlugin
{
    [SolutionComponent]
    public class FixieTestElementsSource : IUnitTestElementsSource
    {
        private readonly UnitTestElementFactory unitTestElementFactory;
        private readonly MetadataElementsSource metadataElementsSource;
        private readonly SearchDomainFactory searchDomainFactory;

        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public FixieTestElementsSource(FixieTestProvider provider, UnitTestElementFactory unitTestElementFactory, SearchDomainFactory searchDomainFactory, IShellLocks shellLocks)
        {
            this.unitTestElementFactory = unitTestElementFactory;
            this.searchDomainFactory = searchDomainFactory;
            metadataElementsSource = new MetadataElementsSource(Logger.GetLogger<FixieTestElementsSource>(), shellLocks);
            Provider = provider;
        }

        public void ExploreSolution(IUnitTestElementsObserver observer)
        {
        }

        public IUnitTestProvider Provider { get; }

        public void ExploreFile(IFile psiFile, IUnitTestElementsObserver observer, Func<bool> interrupted)
        {
            observer.OnCompleted();
        }

        public void ExploreProjects(IDictionary<IProject, FileSystemPath> projects, MetadataLoader loader, IUnitTestElementsObserver observer,
            CancellationToken cancellationToken)
        {
            var explorer = new FixieTestMetadataExplorer((FixieTestProvider)Provider, unitTestElementFactory);
            metadataElementsSource.ExploreProjects(projects, loader, observer, explorer.ExploreAssembly, cancellationToken);
            observer.OnCompleted();
        }

        private static bool IsProjectFile(IFile psiFile)
        {
            // Can return null for external sources
            var projectFile = psiFile.GetSourceFile().ToProjectFile();
            return projectFile != null;
        }
    }
}