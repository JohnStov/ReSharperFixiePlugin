using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.UnitTestFramework;

namespace ReSharperFixiePlugin
{
    [UnitTestProvider, UsedImplicitly]
    public class FixieTestProvider : IUnitTestProvider
    {
        public bool IsElementOfKind(IDeclaredElement declaredElement, UnitTestElementKind elementKind)
        {
            throw new System.NotImplementedException();
        }

        public bool IsElementOfKind(IUnitTestElement element, UnitTestElementKind elementKind)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSupported(IHostProvider hostProvider)
        {
            throw new System.NotImplementedException();
        }

        public int CompareUnitTestElements(IUnitTestElement x, IUnitTestElement y)
        {
            throw new System.NotImplementedException();
        }

        public string ID => "Fixie";
        public string Name => "FixiePlugin";
    }
}