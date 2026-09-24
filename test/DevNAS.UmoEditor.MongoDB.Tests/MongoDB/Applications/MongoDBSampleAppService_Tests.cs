using DevNAS.UmoEditor.MongoDB;
using DevNAS.UmoEditor.Samples;
using Xunit;

namespace DevNAS.UmoEditor.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<UmoEditorMongoDbTestModule>
{

}
