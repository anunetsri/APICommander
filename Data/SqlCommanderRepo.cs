using System;
using System.Collections.Generic;
using System.Linq;
using APICommander.Models;

namespace APICommander.Data
{
    public class SqlCommanderRepo : IAPICommanderRepo
    {//Dependency injecttion of Context class
        private readonly APICommanderContext _context;

        public SqlCommanderRepo(APICommanderContext context)
        {
            _context=context;
        }

        public void CreateCommand(APICommand cmd)
        {
            if(cmd==null)
            {
            throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(APICommand cmd)
        {
             if(cmd==null)
            {
            throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
            
        }

        public IEnumerable<APICommand> GetAllCommands()
        {
            return _context.Commands.ToList();

        }

        public APICommand GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id ==id);
            
        }
        //Change on Db not concluded until this method is called no commit
        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCommand(APICommand cmd)
        {
            //Nothing
        }
    }
}