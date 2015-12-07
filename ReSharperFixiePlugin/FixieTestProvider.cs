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
            return false;
        }

        public bool IsElementOfKind(IUnitTestElement element, UnitTestElementKind elementKind)
        {
            return false;
        }

        public bool IsSupported(IHostProvider hostProvider)
        {
            return false;
        }

        public int CompareUnitTestElements(IUnitTestElement x, IUnitTestElement y)
        {
            return 0;
        }

        public string ID => "Fixie";
        public string Name => "FixiePlugin";
    }
}