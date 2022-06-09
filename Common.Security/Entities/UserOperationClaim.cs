using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security.Entities
{
    public class UserOperationClaim:BaseEntity
    {
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
