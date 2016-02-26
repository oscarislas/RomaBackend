namespace RomaBackend.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RomaBackend.DataAccessLayer.BackendContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RomaBackend.DataAccessLayer.BackendContext context)
        {
        }
    }
}
