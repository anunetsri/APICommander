using System.Collections.Generic;
using APICommander.Models;
//Using this we send some hardcoded values and test decoupling from Contract
namespace APICommander.Data
{
    public class MockCommanderRepo : IAPICommanderRepo
    {
        public void CreateCommand(APICommand cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(APICommand cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<APICommand> GetAllCommands()
        {
            var Commands = new List<APICommand>
            {
              new APICommand {Id=1, HowTo="Boil an egg", Line="Boil water",Platform="Kettle"},
              new APICommand {Id=2, HowTo="Cut Bread", Line="Get A Knife",Platform="Chop"},
              new APICommand {Id=3, HowTo="Make Tea", Line="Place Tea",Platform="Cup"}

            };
            return Commands;
        }

        public APICommand GetCommandById(int id)
        {
            return new APICommand {Id=1, HowTo="Boil an egg", Line="Boil water",Platform="Kettle"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(APICommand cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}