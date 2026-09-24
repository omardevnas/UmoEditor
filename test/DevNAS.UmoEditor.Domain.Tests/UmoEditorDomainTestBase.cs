using Volo.Abp.Modularity;

namespace DevNAS.UmoEditor;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class UmoEditorDomainTestBase<TStartupModule> : UmoEditorTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
