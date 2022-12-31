using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Contracts.UserProfile;

public record GetUserProfileCommand(
    string UserId
    );
