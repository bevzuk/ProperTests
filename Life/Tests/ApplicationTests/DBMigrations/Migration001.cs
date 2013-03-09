using System.Data;
using Migrator.Framework;

namespace ApplicationTests.DBMigrations {
    [Migration(001)]
    public class Migration001 : Migration {
        public override void Up() {
            Database.AddTable("Game", 
                new Column("Id", DbType.Int32),
                new Column("Name", DbType.String)
                );
            Database.AddPrimaryKey("PK_Game", "Game", "Id");
        }

        public override void Down() {}
    }
}