﻿using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Metadata.Reader.API;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.UnitTestFramework;
using JetBrains.Util;

namespace ReSharperFixiePlugin
{
    [SolutionComponent]
    public class FixieTestElementsSource : IUnitTestElementsSource
    {
        public void ExploreSolution(IUnitTestElementsObserver observer)
        {
            throw new System.NotImplementedException();
        }

        public IUnitTestProvider Provider => null;

        public void ExploreFile(IFile psiFile, IUnitTestElementsObserver observer, Func<bool> interrupted)
        {
            throw new System.NotImplementedException();
        }

        public void ExploreProjects(IDictionary<IProject, FileSystemPath> projects, MetadataLoader loader, IUnitTestElementsObserver observer,
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}