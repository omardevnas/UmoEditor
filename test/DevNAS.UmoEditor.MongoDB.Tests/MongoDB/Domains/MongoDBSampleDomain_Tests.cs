using DevNAS.UmoEditor.Samples;
using Xunit;

namespace DevNAS.UmoEditor.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<UmoEditorMongoDbTestModule>
{

}
