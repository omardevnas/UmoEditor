using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class UmoEditorApplicationTestBase<TStartupModule> : UmoEditorTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
