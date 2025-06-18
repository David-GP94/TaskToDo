using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Domain.Events
{
    public record TaskCreated(int Id, string Title);
}
