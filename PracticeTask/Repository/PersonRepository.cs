using PracticeTask.Entities.Base;
using PracticeTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository
{
    internal class PersonRepository : BaseRepository<Person>, IPersonRepository<Person>
    {
    }
}
