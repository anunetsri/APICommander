using System.Collections.Generic;
using APICommander.Models;

namespace APICommander.Data
{
    public interface IAPICommanderRepo
    {

        bool SaveChanges();
        //Give ma list of all command objects
        IEnumerable<APICommand> GetAllCommands();
        APICommand GetCommandById(int id);

        void CreateCommand(APICommand cmd);
        //PUT MEthod
        void UpdateCommand(APICommand cmd);

        void DeleteCommand(APICommand cmd);

    }
}