// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace triluatsoft.tls.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Added_ShouldChangePasswordOnNextLogin_To_AbpUser : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Added_ShouldChangePasswordOnNextLogin_To_AbpUser));
        
        string IMigrationMetadata.Id
        {
            get { return "201503220907591_Added_ShouldChangePasswordOnNextLogin_To_AbpUser"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
